using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rasterizer
{
    public static class Math
    {
        /// <summary>
        /// ベクトルの内積
        /// </summary>
        /// <param name="vec1"></param>
        /// <param name="vec2"></param>
        /// <returns></returns>
        public static float Dot(Vector3 vec1,  Vector3 vec2)
        {
            return vec1.x * vec2.x + vec1.y * vec2.y + vec1.z * vec2.z;
        }

        /// <summary>
        /// ベクトルの外積(vec1 x vec2)
        /// </summary>
        /// <param name="vec1"></param>
        /// <param name="vec2"></param>
        /// <returns></returns>
        public static Vector3 Cross(Vector3 vec1, Vector3 vec2)
        {
            var x = vec1.y * vec2.z - vec2.y * vec1.z;
            var y = vec1.z * vec2.x - vec2.z * vec1.x;
            var z = vec1.x * vec2.y - vec2.x * vec1.y;

            return new Vector3(x, y, z);
        }

        public static bool FloatEqual(float a, float b)
        {
            const float DELTA = 0.001f;
            return MathF.Abs(a - b) <= DELTA;
        }
    }
}
