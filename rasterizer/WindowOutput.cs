using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace rasterizer
{
    /// <summary>
    /// ウィンドウを表示して描画する
    /// </summary>
    internal class WindowOutput : Form, IImageOutput
    {
        private Bitmap canvas;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public WindowOutput(int width, int height)
        {
            Initialize(width, height);
        }

        public void Initialize(int width, int height)
        {
            // ウィンドウとcanvasのサイズを設定
            this.Width = width;
            this.Height = height;
            canvas = new Bitmap(width, height);
            this.BackColor = Color.Black;

            // 描画イベントを登録
            this.Paint += new PaintEventHandler(RefreshCanvas);
        }

        private void RefreshCanvas(object sender, PaintEventArgs e)
        {
            // canvasをウィンドウに描画する
            e.Graphics.DrawImage(canvas, 0, 0);
        }

        public void SetPixel(Pixel pixel)
        {
            Console.WriteLine($"pixelを描画: {pixel.x}, {pixel.y}");
            if (pixel == null) return;
            // 指定された座標がcanvasの中なら描画する
            if (pixel.x < 0 || pixel.x >= this.Width) return;
            if (pixel.y <0 || pixel.y >= this.Height) return;

            canvas.SetPixel(pixel.x, pixel.y, pixel.Color);
        }

        public void OutputImage()
        {
            // ピクセルを描画する
            this.Invalidate();
            // ウィンドウを表示する
            Application.Run(this);
        }
    }
}
