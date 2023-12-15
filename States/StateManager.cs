using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wahh.States
{
    class StateManager
    {
        static State activeState;

        public static State GetState() {
            return activeState;
        }

        public static void SetState(State state) {
            Events.EventManager.Clear();
            activeState = state;

        }
    }
}
