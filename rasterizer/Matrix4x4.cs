using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rasterizer
{
    /// <summary>
    /// 4x4行列
    /// </summary>
    public class Matrix4x4
    {
        private float[,] _elements { get; } = new float[4, 4];

        public Matrix4x4(float[, ] elements)
        {
            if (elements.GetLength(0) != 4 || elements.GetLength(1) != 4)
            {
                throw new ArgumentException("コンストラクタの引数のサイズが4x4になっていません");
            }

            _elements = elements;
        }

        /// <summary>
        /// インデクサ
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public float this[int row, int column]
        {
            get
            {
                if (row < 0 || row >= 4) throw new ArgumentOutOfRangeException("行列のサイズを超えた要素にアクセスしようとしています");
                if (column < 0 || column>= 4) throw new ArgumentOutOfRangeException("行列のサイズを超えた要素にアクセスしようとしています");

                return _elements[row, column];
            }
        }

        /// <summary>
        /// 右から行列を掛ける
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public Matrix4x4 Multiply(Matrix4x4 mat)
        {
            var ret = new float[4, 4];
            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    ret[i, j] = 0f;
                    for (var k = 0; k < 4; k++)
                    {
                        ret[i, j] += _elements[i, k] * mat[k, j];
                    }
                }
            }

            return new Matrix4x4(ret);
        }

        public override string ToString()
        {
            return $"({_elements[0, 0]}, {_elements[0, 1]}, {_elements[0, 2]}, {_elements[0, 3]}\n" +
                $"{_elements[1, 0]}, {_elements[1, 1]}, {_elements[1, 2]}, {_elements[1, 3]}\n" +
                $"{_elements[2, 0]}, {_elements[2, 1]}, {_elements[2, 2]}, {_elements[2, 3]}\n" +
                $"{_elements[3, 0]}, {_elements[3, 1]}, {_elements[3, 2]}, {_elements[3, 3]})";
        }
    }
}
