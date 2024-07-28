using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rasterizer
{
    /// <summary>
    /// Objファイルから読み込んだ3Dモデル
    /// </summary>
    internal class Model : IModel
    {
        /// <summary>
        /// 頂点
        /// </summary>
        public List<Point3D> VertexList => _vertexList;
        private List<Point3D> _vertexList;

        public Model(List<Point3D> vertexList)
        {
            _vertexList = vertexList;
        }
    }

    internal class NullModel : IModel
    {
        public List<Point3D> VertexList { get
            {
                if (_vertexList == null)
                {
                    _vertexList = new List<Point3D>();
                }
                return _vertexList;
            }
        }
        private List<Point3D> _vertexList = null;
    }
}
