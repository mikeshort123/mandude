using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wahh
{
    class World
    {
        bool[,] grid;
        int width, height;

        public World(int width, int height) {
            this.width = width;
            this.height = height;
            this.grid = new bool[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    float tx = 1 - 2 * i / (float)width;
                    float ty = 1 - 2 * j / (float)height;
                    this.grid[i, j] = (tx * tx + ty * ty >= 0.7);
                }
            }
        }

        public void Render(WorldRenderer r) 
        {    
            r.DrawWorld(grid, width, height);
        }

        public float CheckLine(Vec2 p, Vec2 d) 
        {
            float xt = 1;
            if (d.x > 0) {
                xt = PosXLine(p, d);
            }
            if (d.x < 0)
            {
                xt = NegXLine(p, d);
            }

            float yt = 1;
            if (d.y > 0)
            {
                yt = PosYLine(p, d);
            }
            if (d.y < 0)
            {
                yt = NegYLine(p, d);
            }

            float t = xt < yt ? xt : yt;
            return t;
        }

        private float PosXLine(Vec2 p, Vec2 d) {
            for (float l = (float)Math.Ceiling(p.x); l <= Math.Floor(p.x + d.x); l++)
            {
                float t = (l - p.x) / d.x;
                int i = (int)l;
                int j = (int)Math.Floor(p.y + t * d.y);
                if (grid[i, j])
                {
                    return t;
                }
            }
            return 1;
        }

        private float NegXLine(Vec2 p, Vec2 d)
        {
            for (float l = (float)Math.Floor(p.x); l >= Math.Ceiling(p.x + d.x); l--)
            {
                float t = (l - p.x) / d.x;
                int i = (int)l - 1;
                int j = (int)Math.Floor(p.y + t * d.y);
                if (grid[i, j])
                {
                    return t;
                }
            }
            return 1;
        }

        private float PosYLine(Vec2 p, Vec2 d)
        {
            for (float l = (float)Math.Ceiling(p.y); l <= Math.Floor(p.y + d.y); l++)
            {
                float t = (l - p.y) / d.y;
                int j = (int)l;
                int i = (int)Math.Floor(p.x + t * d.x);
                if (grid[i, j])
                {
                    return t;
                }
            }
            return 1;
        }

        private float NegYLine(Vec2 p, Vec2 d)
        {
            for (float l = (float)Math.Floor(p.y); l >= Math.Ceiling(p.y + d.y); l--)
            {
                float t = (l - p.y) / d.y;
                int j = (int)l - 1;
                int i = (int)Math.Floor(p.x + t * d.x);
                if (grid[i, j])
                {
                    return t;
                }
            }
            return 1;
        }

        public Vec2 HitboxMovement(Vec2 pos, float w, float h, Vec2 dp) 
        {
            float mag = dp * dp;
            if (mag > 1)
            {
                dp = dp / (float)Math.Sqrt(mag);
            }
            return new Vec2(CheckHorizontal(pos, w, h, dp), CheckVertical(pos, w, h, dp));
        }

        private float CheckHorizontal(Vec2 pos, float w, float h, Vec2 dp) 
        {

            float tx = (w - 1) / 2;
            float ty = (h - 1) / 2;

            int dl = (int)Math.Floor(pos.x + dp.x - tx);
            int dr = (int)Math.Ceiling(pos.x + dp.x + tx);

            for (int i = (int)Math.Floor(pos.y - ty); i <= (int)Math.Ceiling(pos.y + ty); i++)
            {
                if (i < 0 || i >= height) continue;
                if (dr >= 0 && dr < width && grid[dr, i]) return dr - tx - 1;
                if (dl >= 0 && dl < width && grid[dl, i]) return dl + tx + 1;
            }
            return pos.x + dp.x;
        }

        private float CheckVertical(Vec2 pos, float w, float h, Vec2 dp)
        {
            float tx = (w - 1) / 2;
            float ty = (h - 1) / 2;

            int dt = (int)Math.Floor(pos.y + dp.y - ty);
            int db = (int)Math.Ceiling(pos.y + dp.y + ty);

            for (int i = (int)Math.Floor(pos.x - tx); i <= (int)Math.Ceiling(pos.x + tx); i++)
            {
                if (i < 0 || i >= width) continue;
                if (db >= 0 && db < height && grid[i, db]) return db - ty - 1;
                if (dt >= 0 && dt < height && grid[i, dt]) return dt + ty + 1;
            }
            return pos.y + dp.y;
        }
    }
}
