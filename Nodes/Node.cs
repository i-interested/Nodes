namespace Nodes
{
    partial class Program
    {
        public class Node
        {
            public int Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public Node(int value)
            {
                Value = value;
            }
            public override string ToString()
             => Value.ToString();
        }
    }
}
