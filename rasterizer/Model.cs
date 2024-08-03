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
        public List<Vector3> VertexList => _vertexList;
        private List<Vector3> _vertexList;

        public Model(List<Vector3> vertexList)
        {
            _vertexList = vertexList;
        }
    }

    internal class NullModel : IModel
    {
        public List<Vector3> VertexList { 
            get
            {
                if (_vertexList == null)
                {
                    _vertexList = new List<Vector3>();
                }
                return _vertexList;
            }
        }
        private List<Vector3> _vertexList = null;
    }
}
