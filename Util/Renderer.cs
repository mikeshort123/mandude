using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Wahh.Util
{
    class Renderer
    {

        public int defaultWidth = 1920;
        public int defaultHeight = 1080;

        float minRatio;
        float maxRatio;

        Graphics currentGraphics;

        public void Render(Graphics g)
        {
            currentGraphics = g;

            States.StateManager.GetState().Render(this);
        }

        public void DrawCircle(float x, float y, float s, int r, int g, int b) 
        { 
            Brush brush = new System.Drawing.SolidBrush(Color.FromArgb(255, r, g, b));
            Vec2 pos = GetScreenPos(new Vec2(x, y));
            float size = s / minRatio;
            currentGraphics.FillEllipse(brush, pos.x - size / 2, pos.y - size / 2, size, size);
        }

        public void DrawRectangle(float x, float y, float w, float h, int r, int g, int b) 
        {
            Brush brush = new System.Drawing.SolidBrush(Color.FromArgb(255, r, g, b));
            Vec2 pos = GetScreenPos(new Vec2(x, y));
            float width = w / minRatio;
            float height = h / minRatio;
            currentGraphics.FillRectangle(brush, pos.x - width/2, pos.y - height/2, width, height);
        }

        public void UpdateRatios(int width, int height)
        {
            float xRatio = (float)defaultWidth / (float)width;
            float yRatio = (float)defaultHeight / (float)height;

            minRatio = xRatio > yRatio ? yRatio : xRatio;
            maxRatio = xRatio > yRatio ? xRatio : yRatio;
        }

        private Vec2 GetScreenPos(Vec2 UIPos)
        {
            float xOffset = 0.5f * (minRatio * Form1.width - defaultWidth);
            float yOffset = 0.5f * (minRatio * Form1.height - defaultHeight);

            return (new Vec2(xOffset, yOffset) + UIPos) / minRatio;
        }
    }
}
