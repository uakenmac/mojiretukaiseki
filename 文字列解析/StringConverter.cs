using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 文字列解析
{
    class StringConverter
    {
        public StringConverter(string henkoumaemojiretu)
        {
            MojiretuKaiseki moji = new MojiretuKaiseki(henkoumaemojiretu);
            foreach (var item in moji.GetTag())
            {
                Console.WriteLine(item.MName);
                foreach (var inner_item in item.Attributes())
                {
                    Console.WriteLine(inner_item.Name);
                    Console.WriteLine(inner_item.Value);
                }
            }

        }


    }
}
