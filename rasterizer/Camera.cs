using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rasterizer
{
    /// <summary>
    /// カメラ
    /// </summary>
    public class Camera
    {
        public class SetupParam
        {
            public Vector3 Position { get; } = new Vector3 (0, 0, 0);
            public Vector3 LookAt { get; } = new Vector3(0, 0, 0);
            public Vector3 UpVector { get; } = new Vector3(0, 0, 0);

            // クリッピング
            public float Near { get; } = 2f;
            public float Far { get; } = 10f;

            // カメラサイズ
            public float Width { get; } = 1f;
            public float Height { get; } = 1f;
        }

        /// <summary>
        /// カメラの座標(ワールド座標)
        /// </summary>
        public Vector3 Position;

        /// <summary>
        /// カメラ座標系の基底
        /// </summary>
        public Vector3 BasisX;
        public Vector3 BasisY;
        public Vector3 BasisZ;

        /// <summary>
        /// クリッピング距離
        /// </summary>
        public float Near;
        public float Far;

        public float Width;
        public float Height;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="setupParam"></param>
        public Camera(SetupParam setupParam)
        {
            Position = setupParam.Position;

            // カメラ座標系の基底
            SetupBasis(setupParam);

            Near = setupParam.Near;
            Far = setupParam.Far;
            Width = setupParam.Width;
            Height = setupParam.Height;
        }

        /// <summary>
        /// カメラ座標系の基底をセットする
        /// </summary>
        /// <param name="setupParam"></param>
        private void SetupBasis(SetupParam setupParam)
        {
            BasisZ = (setupParam.LookAt - setupParam.Position).Normalize();
            BasisX = Math.Cross(setupParam.UpVector, BasisZ).Normalize();
            BasisY = Math.Cross(BasisZ, BasisX).Normalize();
        }
    }
}
