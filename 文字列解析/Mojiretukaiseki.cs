using System.Collections.Generic;

namespace 文字列解析
{
    internal class MojiretuKaiseki
    {
        private int pointer = 0;
        private List<Tag> tag = new List<Tag>();

        public MojiretuKaiseki(string str)
        {
            while (true)
            {
                if (str[pointer].Equals('<'))
                {
                    ++pointer;
                    tag.Add(new Tag(str, ref pointer));
                    if ((tag[tag.Count - 1].MType == Type.TYPE_END) && (pointer >= str.Length))
                    {
                        break;
                    }
                }
                else
                {
                    ++pointer;
                }
                if (pointer >= str.Length)
                {
                    break;
                }
            }
        }

        public List<Tag> GetTag()
        {
            return tag;
        }
    }
}