using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rasterizer
{
    internal interface IModel
    {
        public List<Point3D> VertexList { get; }
    }
}
