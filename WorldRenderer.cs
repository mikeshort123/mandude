using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wahh
{
    class WorldRenderer
    {
        Util.Renderer renderer;
        Camera camera;
        Vec2 screenSize;

        public WorldRenderer(Util.Renderer renderer, Camera camera)
        {
            this.renderer = renderer;
            this.camera = camera;
            this.screenSize = new Vec2(renderer.defaultWidth, renderer.defaultHeight);
        }

        public void DrawRectangle(Vec2 pos, float w, float h, int r, int g, int b) 
        {
            Vec2 worldPos = camera.Zoom * (pos - camera.Pos) + screenSize / 2;
            renderer.DrawRectangle(
                worldPos.x,
                worldPos.y,
                w * camera.Zoom,
                h * camera.Zoom,
                r, g, b
            );
        }

        public void DrawCircle(Vec2 pos, float s, int r, int g, int b)
        {
            Vec2 worldPos = camera.Zoom * (pos - camera.Pos) + screenSize / 2;
            renderer.DrawCircle(
                worldPos.x,
                worldPos.y,
                s * camera.Zoom,
                r, g, b
            );
        }

        public void DrawWorld(bool[,] grid, int width, int height)
        {
            double cX = Math.Floor(camera.Pos.x - renderer.defaultWidth / (2 * camera.Zoom));
            double cY = Math.Floor(camera.Pos.y - renderer.defaultHeight / (2 * camera.Zoom));

            for (double i = 0; i <= Math.Ceiling(renderer.defaultWidth / camera.Zoom); i++)
            {
                float x = (float)(i + cX);
                if (0 > x || x >= width) continue;
                for (double j = 0; j <= Math.Ceiling(renderer.defaultHeight / camera.Zoom); j++)
                {
                    float y = (float)(j + cY);
                    if (0 > y || y >= height) continue;

                    if (grid[(int)x, (int)y])
                    {
                        DrawRectangle(new Vec2(x, y), 1, 1, 100, 100, 100);
                    }
                    else
                    {
                        DrawRectangle(new Vec2(x, y), 1, 1, 230, 255, 220);
                    }    

                }
            }
        }
    }
}
