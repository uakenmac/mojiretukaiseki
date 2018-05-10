using System.Collections.Generic;

namespace 文字列解析
{
    /*
     * ゲームプログラマになる前に読む本のほとんどそのまま
     */

    public enum Type
    {
        TYPE_BEGIN,
        TYPE_END,
    };

    internal class Tag
    {
        private List<Attribute> mAttributes = new List<Attribute>();
        public int mAttributesNum = 0;
        public string MName { get; }

        public Type MType { get; }

        private bool isNormalChar(char c)
        {
            if (c >= '0' && c <= '9')
            {
                return true;
            }
            if (c >= 'a' && c <= 'z')
            {
                return true;
            }
            if (c >= 'A' && c <= 'Z')
            {
                return true;
            }
            if (c == '_')
            {
                return true;
            }
            return false;
        }

        public Tag(string str, ref int pointer)
        {
            //属性の名前と値の一時的な格納場所
            string name = "";
            string value = "";

            int m = 0;
            bool end = false;
            while (pointer < str.Length)
            {
                char c = str[pointer];
                ++pointer; //ポインタ進める
                switch (m)
                {
                    case 0: //初期状態
                        switch (c)
                        {
                            case '/': MType = Type.TYPE_END; break; //終了タグ
                            default: MName += c; m = 1; break;
                        }
                        break;

                    case 1: //名前
                        if (c == '>')
                        {
                            end = true;
                        }
                        else if (isNormalChar(c))
                        {
                            MName += c;
                        }
                        else
                        {
                            m = 2; //名前を抜ける
                        }
                        break;

                    case 2: //名前の後の空白
                        if (c == '>')
                        {
                            end = true;
                        }
                        else if (isNormalChar(c))
                        {
                            name += c; //内部の属性名追加
                            m = 3;
                        }
                        else
                        {
                            ;
                        }
                        break;

                    case 3: //属性名
                        switch (c)
                        {
                            case '=': m = 4; break;
                            default: name += c; break;
                        }
                        break;

                    case 4: //属性値前の#
                        switch (c)
                        {
                            case '#': m = 5; break;
                            default: break; //何もしない
                        }
                        break;

                    case 5: //属性値
                        switch (c)
                        {
                            case '#':
                                m = 2; //名前名の後の空白
                                       //属性値追加
                                mAttributes.Add(new Attribute(name, value));
                                ++mAttributesNum;
                                //名前と値を初期化
                                name = "";
                                value = "";
                                break;

                            default: value += c; break;
                        }
                        break;
                }
                if (end)
                { //終了
                    break;
                }
            }
        }

        /// <summary>
        /// 属性ゲッター
        /// </summary>
        /// <returns></returns>
        public List<Attribute> Attributes()
        {
            return mAttributes;
        }
    }
}