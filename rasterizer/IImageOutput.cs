using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rasterizer
{
    /// <summary>
    /// 描画結果を出力するインターフェース
    /// </summary>
    internal interface IImageOutput
    {
        public void Initialize(int width, int height);

        public void SetPixel(Pixel pixel);

        public void OutputImage();
    }
}
