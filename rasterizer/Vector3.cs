using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rasterizer
{
    /// <summary>
    ///　3次元ベクトル
    /// </summary>
    public class Vector3
    {
        public float x { get; }
        public float y { get; }
        public float z { get; }

        /// <summary>
        /// ベクトルのノルム
        /// </summary>
        public float Norm { 
            get
            {
                return MathF.Sqrt(x * x + y * y + z * z);
            }
        }

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// 正規化したベクトルを取得する
        /// </summary>
        /// <returns></returns>
        public Vector3 Normalize()
        {
            var x = this.x / this.Norm;
            var y = this.y / this.Norm;
            var z = this.z / this.Norm;

            return new Vector3(x, y, z);
        }

        public override string ToString()
        {
            return $"x: {x} y: {y}, z: {z}";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || this.GetType() != obj.GetType()) return false;

            Vector3 vec = obj as Vector3;
            if (vec == null) return false;

            return Math.FloatEqual(this.x, vec.x) && Math.FloatEqual(this.y, vec.y) && Math.FloatEqual(this.z, vec.z);
        }
    }
}
