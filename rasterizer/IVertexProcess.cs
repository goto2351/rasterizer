using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rasterizer
{
    /// <summary>
    /// 頂点処理のインターフェース
    /// </summary>
    public interface IVertexProcess
    {
        public List<Vector3> Transform(List<Vector3> vertexList);
    }
}
