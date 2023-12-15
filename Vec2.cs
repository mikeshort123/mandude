using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wahh
{
    struct Vec2
    {
        public float x, y;
        public Vec2(float x, float y) 
        {
            this.x = x;
            this.y = y;
        }

        public static Vec2 operator -(Vec2 v) { return new Vec2(-v.x, -v.y); }
        public static Vec2 operator +(Vec2 a, Vec2 b) { return new Vec2(a.x + b.x, a.y + b.y); }
        public static Vec2 operator -(Vec2 a, Vec2 b) { return new Vec2(a.x - b.x, a.y - b.y); }
        public static Vec2 operator *(Vec2 v, float s) { return new Vec2(s * v.x, s * v.y); }
        public static Vec2 operator *(float s, Vec2 v) { return new Vec2(s * v.x, s * v.y); }
        public static float operator *(Vec2 a, Vec2 b) { return a.x * b.x + a.y * b.y; }
        public static Vec2 operator /(Vec2 v, float s) { return new Vec2(v.x / s, v.y / s); }
        public static Vec2 Normalize(Vec2 v) { return v / (float)Math.Sqrt(v * v); }
    }
}
