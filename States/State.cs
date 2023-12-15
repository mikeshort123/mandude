using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wahh.States
{
    interface State
    {

        void Tick(Util.Handler h);
        void Render(Util.Renderer r);

    }
}
