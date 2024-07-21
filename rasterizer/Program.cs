namespace rasterizer
{
    /// <summary>
    /// エントリーポイント
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();

            // ウィンドウを作成してピクセルを描画する
            var outputWindow = new WindowOutput(800, 600);
            TestDraw(outputWindow);
            outputWindow.OutputImage();
        }

        private static void TestDraw(IImageOutput output)
        {
            for (int i = 0; i < 250; i++)
            {
                var pixel = new Pixel(2 * i + 100, i + 100, Color.White);
                output.SetPixel(pixel);
            }
        }
    }
}