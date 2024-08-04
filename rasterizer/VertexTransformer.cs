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

        public void Transform()
        {
            var viewingTransformation = new ViewingTransformation(_camera);
            var cameraCoordinateVertex = viewingTransformation.Transform(_vertexList);
            Console.WriteLine("頂点処理: ビュー変換");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{_vertexList[i]} → {cameraCoordinateVertex[i]}");
            }
        }
    }
}
