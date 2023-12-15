using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wahh.Entities
{
    class Player
    {
        Vec2 pos, vel;

        Spells.Spell spell1;
        Spells.Spell spell2;

        static float InitialAcceleration = 40f;
        static float MaxSpeed = 4;

        public Player(float x, float y) {
            pos = new Vec2(x, y);
            vel = new Vec2(0, 0);
            spell1 = new Spells.FlameAttack();
            spell2 = new Spells.FlameDash();
        }

        public void Tick(WorldHandler h, World w) {

            Vec2 move = new Vec2(0, 0);
            if (h.Handler.GetActionHeld(Util.KeyAction.MOVE_UP)) move.y -= 1;
            if (h.Handler.GetActionHeld(Util.KeyAction.MOVE_DOWN)) move.y += 1;
            if (h.Handler.GetActionHeld(Util.KeyAction.MOVE_LEFT)) move.x -= 1;
            if (h.Handler.GetActionHeld(Util.KeyAction.MOVE_RIGHT)) move.x += 1;

            float m = (float)Math.Sqrt(move * move);
            if (m > 0) move /= m;

            Vec2 acc = InitialAcceleration * (move - vel / MaxSpeed);
            vel += acc * h.Handler.Dt;

            pos = w.HitboxMovement(pos, 1, 1, vel * h.Handler.Dt);

            if (h.Handler.GetActionPressed(Util.KeyAction.ATTACK1)) spell1.Use(this, h.GetMouseWorldPos());
            if (h.Handler.GetActionPressed(Util.KeyAction.ATTACK2)) spell2.Use(this, h.GetMouseWorldPos());
            
            spell1.Tick(h);
            spell2.Tick(h);
        }

        public void Render(WorldRenderer r) {
            r.DrawCircle(pos, 1, 255, 0, 0);
        }

        public Vec2 Pos { get { return pos; } }
        public Vec2 Vel { get { return vel; } }

        public void Accelerate(Vec2 a) { vel += a; }
    }
}
