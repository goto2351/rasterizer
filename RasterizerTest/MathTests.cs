using Microsoft.VisualStudio.TestTools.UnitTesting;
using rasterizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rasterizer.Tests
{
    [TestClass()]
    public class MathTests
    {
        [TestMethod()]
        public void 通常の内積()
        {
            var vec1 = new Vector3(1f, 2f, 3f);
            var vec2 = new Vector3(4f, 5f, 6f);

            Assert.IsTrue(Math.FloatEqual(Math.Dot(vec1, vec2), 32f));
        }

        [TestMethod()]
        public void ゼロベクトルとの内積()
        {
            var vec1 = new Vector3(1f, 2f, 3f);
            var vec2 = new Vector3(0f, 0f, 0f);

            Assert.IsTrue(Math.FloatEqual(Math.Dot(vec1, vec2), 0f));
        }

        [TestMethod()]
        public void 直交するベクトルとの内積()
        {
            var vec1 = new Vector3(1f, 0f, 0f);
            var vec2 = new Vector3(0f, 1f, 0f);

            Assert.IsTrue(Math.FloatEqual(Math.Dot(vec1, vec2), 0f));
        }

        [TestMethod()]
        public void 逆向きのベクトルとの内積()
        {
            var vec1 = new Vector3(1f, 2f, 3f);
            var vec2 = new Vector3(-1f, -2f, -3f);

            Assert.IsTrue(Math.FloatEqual(Math.Dot(vec1, vec2), -14f));
        }

        [TestMethod()]
        public void 通常の外積()
        {
            var vec1 = new Vector3(1f, 2f, 3f);
            var vec2 = new Vector3(4f, 5f, 6f);

            var expected = new Vector3(-3f, 6f, -3f);

            Assert.AreEqual(expected, Math.Cross(vec1, vec2));
        }

        [TestMethod()]
        public void ゼロベクトルとの外積()
        {
            var vec1 = new Vector3(1f, 2f, 3f);
            var vec2 = new Vector3(0f, 0f, 0f);

            var expected = new Vector3(0f, 0f, 0f);

            Assert.AreEqual(expected, Math.Cross(vec1, vec2));
        }

        [TestMethod()]
        public void 直交するベクトルとの外積()
        {
            var vec1 = new Vector3(1f, 0f, 0f);
            var vec2 = new Vector3(0f, 1f, 0f);

            var expected = new Vector3(0f, 0f, 1f);

            Assert.AreEqual(expected, Math.Cross(vec1, vec2));
        }

        [TestMethod()]
        public void 同じベクトルとの外積()
        {
            var vec1 = new Vector3(1f, 2f, 3f);
            var vec2 = new Vector3(1f, 2f, 3f);

            var expected = new Vector3(0f, 0f, 0f);

            Assert.AreEqual(expected, Math.Cross(vec1, vec2));
        }
    }
}