using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rasterizer
{
    /// <summary>
    /// 座標と対応する色を表すクラス
    /// </summary>
    public class Pixel
    {
        // 座標
        public int x { get; }
        public int y { get; }

        public Color Color { get; }

        public Pixel(int x, int y, Color color)
        {
            this.x = x;
            this.y = y;
            this.Color = color;
        }
    }
}
