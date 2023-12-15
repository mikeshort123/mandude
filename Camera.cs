using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wahh
{
    class Camera
    {

        Vec2 pos;
        float zoom;

        static float pullStrength = 9;

        public Camera(float x, float y, float zoom) 
        {
            this.pos = new Vec2(x, y);
            this.zoom = zoom;
        }

        public void SetPos(Vec2 pos) 
        {
            this.pos = pos;
        }

        public void MoveTowards(WorldHandler h, Vec2 target)
        {
            float t = h.Handler.Dt * pullStrength;
            t = t > 1 ? 1 : t;
            pos += (target - pos) * t;
        }

        public Vec2 Pos { get { return pos; } }
        public float Zoom { get { return this.zoom; } }

    }
}
