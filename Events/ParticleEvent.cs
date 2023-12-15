using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wahh.Events
{
    class ParticleEvent : Event
    {

        public EventType Type { get { return EventType.Particle; } }

        Particles.Particle particle;

        public ParticleEvent(Particles.Particle p) 
        {
            particle = p;
        }

        public Particles.Particle Particle { get { return particle; } }
    }
}
