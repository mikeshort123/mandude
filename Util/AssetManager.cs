using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Wahh.Util
{
    class AssetManager
    {
        static Dictionary<string, Image> cache = new Dictionary<string, Image>();

        public static Image LoadImage(string path)
        {
            try
            {
                return cache[path];
            }
            catch (KeyNotFoundException)
            {
                Image image = new Bitmap(path);
                cache.Add(path, image);
                return image;
            }
        }

        public static void Clear()
        {
            cache.Clear();
        }
    }
}
