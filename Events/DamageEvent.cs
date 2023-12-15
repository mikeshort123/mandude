using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wahh.Events
{
    class DamageEvent : Event
    {

        public EventType Type { get { return EventType.Damage; } }

        Vec2 start, norm, span;
        float width;
        float damage;

        public DamageEvent(Vec2 start, Vec2 end, float width, float damage)
        {
            this.start = start;

            this.span = end - start;
            this.norm = new Vec2(span.y, -span.x);

            this.width = width;
            this.damage = damage;
        }

        public float Damage { get { return damage; } }

        public bool CheckHit(Vec2 pos) 
        {
            float l = span * span;
            float t = (pos - start) * span;
            float k = (pos - start) * norm;

            if ((k < -width*l) || (k > width*l)) return false;
            if ((t < 0) || (t > l)) return false;
            return true;
        }
    }
}
