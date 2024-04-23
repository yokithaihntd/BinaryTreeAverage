using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical10
{
    internal class Program
    {
        public class Node
        {
            public int Key;
            public Node Left, Right;

            public Node(int item)
            {
                Key = item;
                Left = Right = null;
            }
        }

        public class BinaryTree
        {
            private Node root;

            public BinaryTree()
            {
                root = null;
            }

            private float GetAverageUtil(Node node, ref int sum, ref int count)
            {
                if (node == null)
                    return 0;

                sum += node.Key;
                count++;

                float leftSum = GetAverageUtil(node.Left, ref sum, ref count);
                float rightSum = GetAverageUtil(node.Right, ref sum, ref count);

                return leftSum + rightSum + node.Key;
            }

            public float GetAverage()
            {
                int sum = 0;
                int count = 0;
                float average = GetAverageUtil(root, ref sum, ref count);

                if (count == 0)
                    return 0;

                return sum / (float)count;
            }

            public void Insert(int key)
            {
                root = InsertRec(root, key);
            }

            private Node InsertRec(Node root, int key)
            {
                if (root == null)
                {
                    root = new Node(key);
                    return root;
                }

                if (key < root.Key)
                    root.Left = InsertRec(root.Left, key);
                else if (key > root.Key)
                    root.Right = InsertRec(root.Right, key);

                return root;
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            BinaryTree tree = new BinaryTree();

            tree.Insert(4);
            tree.Insert(2);
            tree.Insert(6);
            tree.Insert(1);
            tree.Insert(3);
            tree.Insert(5);
            tree.Insert(7);

            float average = tree.GetAverage();
            Console.WriteLine("Середнє значення ключів у бінарному дереві: " + average);
        }
    }
}
