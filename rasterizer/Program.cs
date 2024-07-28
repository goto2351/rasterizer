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

            if (args[0] != null)
            {
                LoadModel(args[0]);
            }

            // ウィンドウを作成してピクセルを描画する
            var outputWindow = new WindowOutput(800, 600);
            TestDraw(outputWindow);
            outputWindow.OutputImage();
        }

        private static void LoadModel(string filePath)
        {
            Console.WriteLine($"objファイル読み込み: {filePath}");
            var model = ObjFileLoader.Load(filePath);

            if (model != null)
            {
                Console.WriteLine($"読み込んだモデル: {Path.GetFileName(filePath)}, 頂点数: {model.VertexList.Count}");
                foreach (var vertex in model.VertexList.GetRange(0, 5))
                {
                    Console.WriteLine(vertex.ToString());
                }
            }
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