using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjLoader;
using ObjLoader.Loader.Data.DataStore;
using ObjLoader.Loader.Loaders;

namespace rasterizer
{
    /// <summary>
    /// Objファイルを読み込むクラス
    /// </summary>
    internal class ObjFileLoader
    {
        public static void Load(string path)
        {
            // ObjLoaderインスタンスを作成
            var objLoaderFactory = new ObjLoaderFactory();
            var objLoader = objLoaderFactory.Create();

            // objファイルの読み込み
            try
            {
                using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    var res = objLoader.Load(fileStream);
                    Console.WriteLine(res.ToString());
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"ファイルが見つかりませんでした path: {path}");
                Console.WriteLine(ex.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ファイルが読み込めませんでした path: {path}");
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
