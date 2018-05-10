using System;

namespace 文字列解析
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //var str = Console.ReadLine();
            //string str = "aaaaaaaaaaa<String pos=#1:1#></String>bbbbbbbbbbbbb";
            //string str = "<String pos=#1:1# str=#aaaaaaaaaaaa#></String>";
            //string str = "<String pos=#1:1# str=#aaaaaaaaaaaa# col=#1111111#></String>";

            string str = "aaaaaaaaaaa<S str=#aaa#></S>cccccccccccccc<D pos=#bbb#></D>bbbbbbbbbbbb";
            //string str = "<String pos=#1:1# str=#aaaaaaaaaaaa#></String>  <Date pos=#2:2#></Date>";

            MojiretuKaiseki moji = new MojiretuKaiseki(str);
            foreach (var item in moji.GetTag())
            {
                Console.WriteLine(item.MName);
                foreach (var inner_item in item.Attributes())
                {
                    Console.WriteLine(inner_item.Name);
                    Console.WriteLine(inner_item.Value);
                }
            }
            var str2 = Console.ReadLine();
        }
    }
}