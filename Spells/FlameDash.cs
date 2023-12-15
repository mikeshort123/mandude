using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Wahh.Spells
{
    class FlameDash : Spell
    {
        Image image;
        float cooldown;
        const float maxCooldown = 1;

        public FlameDash()
        {
            image = Util.AssetManager.LoadImage("res/DashIcon.png");
            cooldown = 0;
        }

        public void Tick(WorldHandler h)
        {
            if (cooldown > 0) cooldown -= h.Handler.Dt;
        }

        public void Render(WorldRenderer r) 
        {
        
        }

        public void Use(Entities.Player source, Vec2 targetPos) 
        {
            if (cooldown > 0) return;
            cooldown = maxCooldown;

            Vec2 d = Vec2.Normalize(targetPos - source.Pos);
            Vec2 n = new Vec2(d.y, -d.x);
            source.Accelerate(50 * d);


            Events.EventManager.AddEvent(
                new Events.ParticleScatterEvent(() =>
                {
                    return new Particles.Particle(
                        source.Pos + Util.RandomStuff.GetFloat(0, 5) * d + Util.RandomStuff.GetFloat(-0.5f, 0.5f) * n,
                        255, 220, 20,
                        0.2f,
                        Util.RandomStuff.GetFloat(0.5f, 1)
                    );
                }, 30)
            );
            Events.EventManager.AddEvent(
                new Events.DamageEvent(
                    source.Pos,
                    source.Pos + 5 * d,
                    0.5f,
                    0.2f
                )
            );
        }
    }
}
