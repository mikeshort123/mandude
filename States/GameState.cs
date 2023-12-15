using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wahh.States
{
    class GameState : State
    {
        Camera camera;
        Entities.Player player;
        World world;

        List<Entities.Zombie> zombies;
        Particles.ParticleManager particleManager;

        public GameState()
        {
            particleManager = new Particles.ParticleManager();

            player = new Entities.Player(10, 10);
            camera = new Camera(player.Pos.x, player.Pos.y, 150);
            world = new World(20, 20);
            zombies = new List<Entities.Zombie>();
            zombies.Add(new Entities.Zombie(10, 10));
        }

        public void Tick(Util.Handler h) 
        {
            WorldHandler worldHandler = new WorldHandler(h, camera);
            player.Tick(worldHandler, world);

            for (int i = 0; i < zombies.Count; i++ )
            {
                Entities.Zombie zombie = zombies[i];
                zombie.Tick(worldHandler, world, player);
                if (zombie.IsAlive == false) zombies.RemoveAt(i--);
            }
            particleManager.Tick(worldHandler);

            float camLead = 0.2f;
            camera.MoveTowards(worldHandler, player.Pos + camLead*player.Vel);

            while (Events.EventManager.Empty == false) 
            {
                Events.Event e = Events.EventManager.GetEvent();

                switch (e.Type) {
                    case Events.EventType.Particle:
                        particleManager.HandleParticleEvent(e as Events.ParticleEvent);
                        break;
                    case Events.EventType.ParticleScatter:
                        particleManager.HandleParticleScatterEvent(e as Events.ParticleScatterEvent);
                        break;
                    case Events.EventType.Damage:
                        HandleDamageEvent(e as Events.DamageEvent);
                        break;
                }

            }
        }

        private void HandleDamageEvent(Events.DamageEvent e)
        {
            foreach (Entities.Zombie zombie in zombies) 
            {
                if (e.CheckHit(zombie.Pos)) zombie.ApplyDamage(e.Damage);
            }
        }

        public void Render(Util.Renderer r) 
        {
            WorldRenderer worldRenderer = new WorldRenderer(r, camera);
            world.Render(worldRenderer);
            
            foreach (Entities.Zombie zombie in zombies)
            {
                zombie.Render(worldRenderer);
            }

            player.Render(worldRenderer);
            particleManager.Render(worldRenderer);
            
        }
    }
}
