using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Wahh.Spells
{
    class FlameAttack : Spell
    {
        Image image;
        float cooldown;
        const float maxCooldown = 0.2f;

        public FlameAttack()
        {
            image = Util.AssetManager.LoadImage("res/AttackIcon.png");
            cooldown = 0;
        }

        public void Tick(WorldHandler h)
        {
            if (cooldown > 0) cooldown -= h.Handler.Dt;
        }

        public bool Ready { get { return cooldown <= 0; } }

        public void Render(WorldRenderer r) 
        {
        
        }

        public void Use(Entities.Player source, Vec2 targetPos) 
        {
            if (cooldown > 0) return;
            cooldown = maxCooldown;

            Vec2 d = Vec2.Normalize(targetPos - source.Pos);
            Vec2 n = new Vec2(d.y, -d.x);

            Events.EventManager.AddEvent(
                new Events.ParticleScatterEvent(() =>
                {
                    return new Particles.Particle(
                        source.Pos + Util.RandomStuff.GetFloat(1, 1.5f) * d + Util.RandomStuff.GetFloat(-1, 1) * n,
                        255, 220, 20,
                        0.2f,
                        Util.RandomStuff.GetFloat(0.5f, 1)
                    );
                }, 30)
            );
            Events.EventManager.AddEvent(
                new Events.DamageEvent(
                    source.Pos + d * 1.25f + n,
                    source.Pos + d * 1.25f - n,
                    0.25f,
                    0.1f
                )
            );
        }
    }
}
