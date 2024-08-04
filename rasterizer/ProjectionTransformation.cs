using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rasterizer
{
    /// <summary>
    /// 投影変換(カメラ座標系→投影座標系)
    /// </summary>
    internal class ProjectionTransformation : IVertexProcess
    {
        private Camera _camera;

        /// <summary>
        /// z軸を反転する変換行列
        /// </summary>
        private Matrix4x4 _zInverseMat;
        /// <summary>
        /// 透視投影の変換行列
        /// </summary>
        private Matrix4x4 _projectionMat;

        public ProjectionTransformation(Camera camera)
        {
            _camera = camera;

            _zInverseMat = new Matrix4x4(new float[4, 4]
            {
                {1, 0, 0, 0 },
                {0, 1, 0, 0 },
                {0, 0, -1, 0 },
                {0, 0, 0, 1}
            });

            var clipRatio = _camera.Near / _camera.Far;
            _projectionMat = new Matrix4x4(new float[4, 4]
            {
                {1, 0, 0, 0 },
                {0, 1, 0, 0 },
                {0, 0, 1 / (1 - clipRatio), -1 / (1-clipRatio) },
                {0, 0, 1, 0 }
            });
        }

        public List<Vector3> Transform(List<Vector3> vertexList)
        {
            var transformedList = new List<Vector3>();

            var harfWidth = _camera.Width / 2f;
            var harfHeight = _camera.Height / 2f;

            foreach (var vertice in vertexList)
            {
                // 正規化ビューボリュームに変換する行列
                var normalizeMat = new Matrix4x4(new float[4, 4]
                {
                    {vertice.z / (harfWidth * _camera.Far), 0, 0, 0},
                    {0, vertice.z / (harfHeight * _camera.Far), 0, 0 },
                    {0, 0, 1 / _camera.Far, 0 },
                    {0, 0, 0, 1 }
                });

                // 変換行列全体
                var transformMat = _zInverseMat.Multiply(normalizeMat).Multiply(_projectionMat);

                // 変換後の同次座標
                var x = transformMat[0, 0] * vertice.x + transformMat[0, 1] * vertice.y + transformMat[0, 2] * vertice.z + transformMat[0, 3];
                var y = transformMat[1, 0] * vertice.x + transformMat[1, 1] * vertice.y + transformMat[1, 2] * vertice.z + transformMat[1, 3];
                var z = transformMat[2, 0] * vertice.x + transformMat[2, 1] * vertice.y + transformMat[2, 2] * vertice.z + transformMat[2, 3];
                var w = transformMat[3, 0] * vertice.x + transformMat[3, 1] * vertice.y + transformMat[3, 2] * vertice.z + transformMat[3, 3];

                // デバイス座標にして登録
                transformedList.Add(new Vector3(
                    x: x / w,
                    y: y / w,
                    z: z / w));
            }
            return transformedList;
        }
    }
}
