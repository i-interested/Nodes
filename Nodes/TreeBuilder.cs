using System;
using System.Linq;

namespace Nodes
{
    partial class Program
    {
        public static class TreeBuilder
        {
            private static Random random = new Random();
            private static Node parent;

            public static Node GetRandomTree(int count)
            {
                parent = null;

                var values = Enumerable.Range(1, count).ToArray();

                Mix(values);

                foreach (var value in values)
                    Add(value);

                return parent;
            }

            private static void Mix(int[] values)
            {
                for (int i = values.Length - 1; i >= 1; i--)
                {
                    int j = random.Next(i + 1);

                    var tmp = values[j];
                    values[j] = values[i];
                    values[i] = tmp;
                }
            }

            private static void Add(int value)
            {
                if (parent == null)
                {
                    parent = new Node(value);
                    return;
                }

                var current = parent;
                while (true)
                    if (value >= current.Value)
                    {
                        if (current.Right != null)
                            current = current.Right;
                        else
                        {
                            current.Right = new Node(value);
                            break;
                        }
                    }
                    else
                    {
                        if (current.Left != null)
                            current = current.Left;
                        else
                        {
                            current.Left = new Node(value);
                            break;
                        }
                    }
            }

            public static Node GetSimpleTree()
            {
                var node = new Node(1);

                var left1 = new Node(2);
                var right1 = new Node(3);

                var left21 = new Node(4);
                var right21 = new Node(5);

                var left22 = new Node(6);
                var right22 = new Node(7);

                node.Left = left1;
                node.Right = right1;

                left1.Left = left21;
                left1.Right = right21;

                right1.Left = left22;
                right1.Right = right22;

                return node;
            }
        }
    }
}
