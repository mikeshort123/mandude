using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using Wahh.States;

namespace Wahh
{
    public partial class Form1 : Form
    {

        Util.Handler handler;
        Util.Renderer renderer;

        public static int width = 400;
        public static int height = 225;

        public long time;

        public Form1()
        {
            InitializeComponent();

            this.ClientSize = new Size(width, height);

            handler = new Util.Handler();
            renderer = new Util.Renderer();

            StateManager.SetState(new GameState());

            time = DateTime.Now.Ticks;

            var timer = new Timer
            {
                Interval = 1
            };
            timer.Tick += OnTick;
            timer.Start();
        }

        private void OnTick(object sender, EventArgs e)
        {
            long newTime = DateTime.Now.Ticks;
            float dt = (newTime - time) / (1000f * TimeSpan.TicksPerMillisecond);
            time = newTime;
            handler.Tick(dt);

            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            renderer.Render(g);

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            handler.KeyDown(e.KeyCode);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            handler.KeyUp(e.KeyCode);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            handler.MouseButtonDown(e.Button);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            handler.MouseButtonUp(e.Button);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            handler.MouseMoved(e.X, e.Y);
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            width = ClientSize.Width;
            height = ClientSize.Height;
            renderer.UpdateRatios(width, height);
        }
    }
}
