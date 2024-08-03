using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rasterizer
{
    internal interface IModel
    {
        public List<Vector3> VertexList { get; }
    }
}
