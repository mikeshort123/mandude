using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wahh
{
    class WorldHandler
    {
        Util.Handler handler;
        Camera camera;

        public WorldHandler(Util.Handler handler, Camera camera) 
        {
            this.handler = handler;
            this.camera = camera;
        }

        public Util.Handler Handler { get { return handler; } }

        public Vec2 GetMouseWorldPos() {
            Vec2 mousePos = new Vec2(handler.MouseX, handler.MouseY);
            Vec2 screenSize = new Vec2(Form1.width, Form1.height);

            return camera.Pos + (mousePos - screenSize / 2) / camera.Zoom;
        }
    }
}
