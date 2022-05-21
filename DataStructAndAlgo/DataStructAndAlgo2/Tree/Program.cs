using System;

namespace Tree
{
    public class Tree
    {
        public static void Main()
        {
            BinarySearchTree binaryTree = new BinarySearchTree();
            Random random = new Random();
            for(int i = 0; i < 16; i++) { 
                binaryTree.Add(random.Next(0, 100));
            }

            Console.WriteLine("Binary Tree PreOrder:");
            binaryTree.PreOrder(binaryTree.Root);
            Console.WriteLine();

            Console.WriteLine("Binary Tree InOrder:");
            binaryTree.InOrder(binaryTree.Root);
            Console.WriteLine();

            Console.WriteLine("Binary Tree PostOrder:");
            binaryTree.PostOrder(binaryTree.Root);
            Console.WriteLine();


            RedBlack redBlack = new RedBlack();

            for (int i = 0; i < 16; i++)
            {
                redBlack.Add(random.Next(0, 100));
            }

            redBlack.Add(56);

            Console.WriteLine("Red Black Keys ");
            RedBlackEnumerator k = redBlack.Keys();
            while (k.MoveNext())
                Console.Write(k.Key + " ");

            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Red Black after adding");
            RedBlackEnumerator k1 = redBlack.Keys();
            while (k1.MoveNext())
                Console.Write(k1.Key + " ");
            Console.WriteLine(Environment.NewLine);

            redBlack.Remove(56);
            Console.WriteLine("Red Black after deletion 56 element");
            RedBlackEnumerator k2 = redBlack.Keys();
            while (k2.MoveNext())
                Console.Write(k2.Key + " ");
            Console.WriteLine(Environment.NewLine);

            Console.ReadLine();

        }
    }
}
