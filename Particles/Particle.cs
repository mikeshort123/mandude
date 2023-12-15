using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wahh.Particles
{
    class Particle
    {
        Vec2 pos;
        int r, g, b;
        float size;
        float lifeSpan;

        public Particle(Vec2 pos, int r, int g, int b, float size, float lifeSpan) 
        {
            this.pos = pos;
            this.r = r;
            this.g = g;
            this.b = b;
            this.size = size;
            this.lifeSpan = lifeSpan;
        }

        public void Tick(WorldHandler h) 
        {
            this.lifeSpan -= h.Handler.Dt;
        }

        public void Render(WorldRenderer renderer)
        {
            renderer.DrawRectangle(pos, size, size, r, g, b);
        }

        public bool IsAlive { get { return lifeSpan > 0; } }


    }
}
