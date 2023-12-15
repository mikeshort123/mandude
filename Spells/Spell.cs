using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Wahh.Spells
{
    interface Spell
    {

        void Tick(WorldHandler h);
        void Render(WorldRenderer r);
        void Use(Entities.Player source, Vec2 targetPos);
    }
}
