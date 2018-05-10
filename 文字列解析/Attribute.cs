namespace 文字列解析
{
    internal class Attribute
    {
        public string Name { get; }
        public string Value { get; }

        public Attribute(string p1, string p2)
        {
            this.Name = p1;
            this.Value = p2;
        }
    }
}