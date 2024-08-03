using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rasterizer
{
    /// <summary>
    /// 3Dモデルの頂点
    /// </summary>
    internal class Vector3
    {
        public float x { get; }
        public float y { get; }
        public float z { get; }

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override string ToString()
        {
            return $"x: {x} y: {y}, z: {z}";
        }
    }
}
