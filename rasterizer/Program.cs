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

            if (args[0] == null) return;

            var model = LoadModel(args[0]);
            var camera = CreateCamera();

            // 頂点処理
            var vertexTransformer = new VertexTransformer(camera, model.VertexList);
            vertexTransformer.Transform();

            // ウィンドウを作成してピクセルを描画する
            var outputWindow = new WindowOutput(800, 600);
            TestDraw(outputWindow);
            outputWindow.OutputImage();
        }

        private static IModel LoadModel(string filePath)
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

            return model;
        }

        /// <summary>
        /// カメラを生成
        /// </summary>
        /// <returns></returns>
        private static Camera CreateCamera()
        {
            var setupParam = new Camera.SetupParam()
            {
                Position = new Vector3(0f, 6f, 28f),
                LookAt = new Vector3(-0.2f, 1.6f, 0f),
                UpVector = new Vector3(0f, 1f, 0f),
            };
            
            return new Camera(setupParam);
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