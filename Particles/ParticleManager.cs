using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wahh.Particles
{
    class ParticleManager
    {

        List<Particle> particles;

        public ParticleManager()
        {
            particles = new List<Particle>();
        }

        public void AddParticle(Particle p) 
        {
            particles.Add(p);
        }

        public void Tick(WorldHandler h) 
        {
            for (int i = 0; i < particles.Count; i++)
            {
                particles[i].Tick(h);
                if (particles[i].IsAlive == false)
                {
                    particles.RemoveAt(i--);
                }
            }
        }

        public void Render(WorldRenderer renderer) 
        {
            for (int i = 0; i < particles.Count; i++)
            {
                particles[i].Render(renderer);
            }
        }

        public void HandleParticleEvent(Events.ParticleEvent e) 
        {
            AddParticle(e.Particle);
        }

        public void HandleParticleScatterEvent(Events.ParticleScatterEvent e)
        {
            while (true)
            {
                Particles.Particle p = e.NextParticle();
                if (p == null) break;
                AddParticle(p);
            }
        }

    }
}
