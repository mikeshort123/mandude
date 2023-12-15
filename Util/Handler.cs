using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Wahh.Util
{
    class Handler
    {

        private Dictionary<KeyAction, bool> keyHeldStates;
        private Dictionary<KeyAction, bool> keyPressedStates;
        private Dictionary<Keys, KeyAction> keyMap;
        private Dictionary<MouseButtons, KeyAction> mouseMap;
        private int mousex, mousey;
        private float dt;

        public Handler() 
        {
            keyHeldStates = new Dictionary<KeyAction, bool>();
            keyPressedStates = new Dictionary<KeyAction, bool>();
            keyMap = new Dictionary<Keys, KeyAction>();
            mouseMap = new Dictionary<MouseButtons, KeyAction>();
            LoadKeyStates();
        }

        public void Tick(float dt)
        {
            this.dt = dt;
            States.StateManager.GetState().Tick(this);
            ResetPressedStates();
        }

        public float Dt { get { return dt; } }

        public void KeyDown(Keys key)
        {
            try
            {
                KeyAction action = keyMap[key];
                keyHeldStates[action] = true;
                keyPressedStates[action] = true;
            }
            catch (KeyNotFoundException) { }
        }

        public void KeyUp(Keys key)
        {
            try
            {
                KeyAction action = keyMap[key];
                keyHeldStates[action] = false;
            }
            catch (KeyNotFoundException) { }
        }

        public void MouseButtonDown(MouseButtons button)
        {
            try
            {
                KeyAction action = mouseMap[button];
                keyHeldStates[action] = true;
                keyPressedStates[action] = true;
            }
            catch (KeyNotFoundException) { }
        }

        public void MouseButtonUp(MouseButtons button)
        {
            try
            {
                KeyAction action = mouseMap[button];
                keyHeldStates[action] = false;
            }
            catch (KeyNotFoundException) { }
        }

        public void MouseMoved(int x, int y) 
        {
            mousex = x;
            mousey = y;
        }

        public bool GetActionHeld(KeyAction action) {
            try
            {
                return keyHeldStates[action];
            }
            catch (KeyNotFoundException) {
                return false;
            }
        }

        public bool GetActionPressed(KeyAction action)
        {
            try
            {
                return keyPressedStates[action];
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
        }

        public int MouseX { get { return mousex; } }
        public int MouseY { get { return mousey; } }

        private void LoadKeyStates() 
        {

            foreach (KeyAction action in Enum.GetValues(typeof(KeyAction)))
            {
                keyHeldStates.Add(action, false);
                keyPressedStates.Add(action, false);
            }
            keyMap.Add(Keys.W, KeyAction.MOVE_UP);
            keyMap.Add(Keys.S, KeyAction.MOVE_DOWN);
            keyMap.Add(Keys.A, KeyAction.MOVE_LEFT);
            keyMap.Add(Keys.D, KeyAction.MOVE_RIGHT);

            mouseMap.Add(MouseButtons.Left, KeyAction.ATTACK1);
            keyMap.Add(Keys.Space, KeyAction.ATTACK2);
            mouseMap.Add(MouseButtons.Right, KeyAction.ATTACK3);
        }

        private void ResetPressedStates()
        {
            foreach (KeyAction action in Enum.GetValues(typeof(KeyAction)))
            {
                keyPressedStates[action] = false;
            }
        }

    }
}
