using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wahh.Entities
{
    class Zombie
    {
        Vec2 pos;
        Vec2? target;
        float health;

        float speed = 1;

        

        public Zombie(float x, float y) {
            pos = new Vec2(x, y);
            target = null;
            health = 1;
        }

        public Vec2 Pos { get { return pos; } }
        public bool IsAlive { get { return health > 0; } }

        public void ApplyDamage(float damage)
        {
            health -= damage;
        }

        public void Tick(WorldHandler h, World w, Player p)
        {

            target = p.Pos;

            if (target.HasValue) {
                Vec2 ds = target.Value - pos;
                float mag = (float)Math.Sqrt(ds * ds);
                if (mag > 0)
                {
                    ds *= speed / mag;
                    pos += h.Handler.Dt * ds;
                }
            }
            

            
        }

        public void Render(WorldRenderer r)
        {
            r.DrawCircle(pos, 1, 70, 140, 40);
        }
    }
}
