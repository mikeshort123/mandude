using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wahh.Events
{
    class ParticleScatterEvent : Event
    {

        public EventType Type { get { return EventType.ParticleScatter; } }

        int amount;
        Func<Particles.Particle> generator;

        public ParticleScatterEvent(Func<Particles.Particle> generator, int amount) 
        {
            this.generator = generator;
            this.amount = amount;
        }

        public Particles.Particle NextParticle() 
        {
            if (amount == 0) return null;
            amount--;
            return generator();
        }
    }
}
