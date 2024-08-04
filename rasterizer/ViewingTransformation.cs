using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rasterizer
{
    /// <summary>
    /// ビュー変換(ワールド座標系→カメラ座標系)
    /// </summary>
    internal class ViewingTransformation : IVertexProcess
    {
        private Camera _camera;
        private Matrix4x4 _viewMat;

        public ViewingTransformation(Camera camera) 
        {
            _camera = camera;

            // カメラの位置を原点とするように平行移動する変換行列
            var translationMat = new Matrix4x4(new float[4, 4]
            {
                { 1, 0, 0, -_camera.Position.x },
                { 0, 1, 0, -_camera.Position.y },
                { 0, 0, 1, -_camera.Position.z },
                { 0, 0, 0, 1 }
             });

            // カメラ座標系の基底に合わせて回転する変換行列
            var rotationMat = new Matrix4x4(new float[4, 4]
            {
                { _camera.BasisX.x, _camera.BasisX.y, _camera.BasisX.z, 0},
                { _camera.BasisY.x, _camera.BasisY.y, _camera.BasisY.z, 0},
                { _camera.BasisZ.x, _camera.BasisZ.y, _camera.BasisZ.z, 0},
                { 0, 0, 0, 1 }
            });

            _viewMat = rotationMat.Multiply(translationMat);

            Console.WriteLine("ビュー変換の変換行列を作成");
            Console.WriteLine(_viewMat);
        }

        public List<Vector3> Transform(List<Vector3> vertexList)
        {
            var transformedList = new List<Vector3>();
            foreach (var vertice in vertexList)
            {
                transformedList.Add(new Vector3(
                    x: _viewMat[0, 0] * vertice.x + _viewMat[0, 1] * vertice.y + _viewMat[0, 2] * vertice.z + _viewMat[0, 3],
                    y: _viewMat[1, 0] * vertice.x + _viewMat[1, 1] * vertice.y + _viewMat[1, 2] * vertice.z + _viewMat[1, 3],
                    z: _viewMat[2, 0] * vertice.x + _viewMat[2, 1] * vertice.y + _viewMat[2, 2] * vertice.z + _viewMat[2, 3]));
            }

            return transformedList;
        }
    }
}
