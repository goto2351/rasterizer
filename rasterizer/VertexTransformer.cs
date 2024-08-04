using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rasterizer
{
    /// <summary>
    /// 頂点処理をするクラス
    /// </summary>
    public class VertexTransformer
    {
        public Camera _camera;
        public List<Vector3> _vertexList;

        public VertexTransformer(Camera camera, List<Vector3> vertexList)
        {
            _camera = camera;
            _vertexList = vertexList;
        }

        public List<Pixel> Transform()
        {
            var viewingTransformation = new ViewingTransformation(_camera);
            var cameraCoordinateVertex = viewingTransformation.Transform(_vertexList);
            Console.WriteLine("頂点処理: ビュー変換");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{_vertexList[i]} → {cameraCoordinateVertex[i]}");
            }

            var projectionTransformation = new ProjectionTransformation(_camera);
            var deviceCoordinateVertex = projectionTransformation.Transform(cameraCoordinateVertex);
            Console.WriteLine("頂点処理: 投影変換");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{cameraCoordinateVertex[i]} → {deviceCoordinateVertex[i]}");
            }

            // ビューポート変換
            var harfScreenWidth = Program.SCREEN_WIDTH / 2f;
            var harfScreenHeight = Program.SCREEN_HEIGHT / 2f;
            var viewPortCoordinateVertex = new List<Vector3>();
            foreach(var vertice in deviceCoordinateVertex)
            {
                viewPortCoordinateVertex.Add(new Vector3(
                    x: vertice.x * harfScreenWidth + harfScreenWidth,
                    y: -vertice.y * harfScreenHeight + harfScreenHeight,
                    z: vertice.z * 0.5f + 0.5f));
            }

            Console.WriteLine("頂点処理: ビューポート変換");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{deviceCoordinateVertex[i]} → {viewPortCoordinateVertex[i]}");
            }

            return viewPortCoordinateVertex.Select(v => new Pixel((int)v.x, (int)v.y, Color.White)).ToList();
        }
    }
}
