using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjLoader;
using ObjLoader.Loader.Data.DataStore;
using ObjLoader.Loader.Data.VertexData;
using ObjLoader.Loader.Loaders;

namespace rasterizer
{
    /// <summary>
    /// Objファイルを読み込むクラス
    /// </summary>
    internal class ObjFileLoader
    {
        public static IModel Load(string path)
        {
            // ObjLoaderインスタンスを作成
            var objLoaderFactory = new ObjLoaderFactory();
            var objLoader = objLoaderFactory.Create();

            // objファイルの読み込み
            try
            {
                using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    var loadResult = objLoader.Load(fileStream);

                    // 読み込んだ結果からModelを生成
                    return CreateModelData(loadResult);
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"ファイルが見つかりませんでした path: {path}");
                Console.WriteLine(ex.ToString());
                return new NullModel();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ファイルが読み込めませんでした path: {path}");
                Console.WriteLine(ex.ToString());
                return new NullModel();
            }
        }

        /// <summary>
        /// ObjLoaderの読み込み結果からModelを生成する
        /// </summary>
        /// <param name="loadResult"></param>
        /// <returns></returns>
        private static IModel CreateModelData(LoadResult loadResult)
        {
            // 頂点情報が無ければNullオブジェクトを返す
            if (loadResult == null || loadResult.Vertices.Count == 0)
            {
                return new NullModel();
            }

            return new Model(CreatePointList(loadResult.Vertices));
        }

        /// <summary>
        /// ObjLoaderで読み込んだ頂点データをPoint3Dのリストに変換する
        /// </summary>
        /// <param name="vertexList"></param>
        /// <returns></returns>
        private static List<Point3D> CreatePointList(IList<Vertex> vertexList)
        {
            var pointList = new List<Point3D>();

            foreach (var vertex in vertexList)
            {
                var point = new Point3D(vertex.X, vertex.Y, vertex.Z);
                pointList.Add(point);
            }

            return pointList;
        }
    }
}
