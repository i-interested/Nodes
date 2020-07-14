using System;

namespace Nodes
{
    partial class Program
    {
        /*******************************
         * Дано: бинарное дерево 
         * Необходимо: поменять местами листья на всю глубину
        ********************************/
        static void Main(string[] args)
        {
            var node = TreeBuilder.GetRandomTree(7);//GetSimpleTree();

            Console.WriteLine("tree before:");
            BypassingTreeInDepth(node, 0, Print);

            BypassingTreeInDepth(node, 0, Rotate);

            Console.WriteLine("\r\ntree after:");
            BypassingTreeInDepth(node, 0, Print);

            Console.ReadKey();
        }
        private static void BypassingTreeInDepth(Node node, int level, Action<Node, int> doSomething)
        {
            if (node == null)
                return;

            doSomething(node, level);

            BypassingTreeInDepth(node.Left, level + 1, doSomething);
            BypassingTreeInDepth(node.Right, level + 1, doSomething);
        }

        private static void Print(Node node, int level)
        {
            var leftLeaf = node.Left?.ToString() ?? "null";
            var rightLeaf = node.Right?.ToString() ?? "null";
            Console.WriteLine($"{new string(' ', level * 2)}{node}({leftLeaf},{rightLeaf})");
        }

        private static void Rotate(Node node, int level)
        {
            var newRight = node.Left;
            node.Left = node.Right;
            node.Right = newRight;
        }
    }
}
