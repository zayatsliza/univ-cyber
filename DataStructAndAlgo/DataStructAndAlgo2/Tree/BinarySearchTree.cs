using System;
namespace Tree
{
    public class BinarySearchTree
    {
        public Node Root { get; set; }

        public bool Add(int value)
        {
            Node before = null, after = this.Root;

            while (after != null)
            {
                before = after;
                if (value < after.Data) //Is new node in left tree? 
                    after = after.LeftNode;
                else if (value > after.Data) //Is new node in right tree?
                    after = after.RightNode;
                else
                {
                    //Exist same value
                    return false;
                }
            }

            Node newNode = new Node();
            newNode.Data = value;

            if (this.Root == null)//Tree ise empty
                this.Root = newNode;
            else
            {
                if (value < before.Data)
                    before.LeftNode = newNode;
                else
                    before.RightNode = newNode;
            }

            return true;
        }

        public void PreOrder(Node parent)
        {
            if (parent != null)
            {
                Console.Write(parent.Data + " ");
                PreOrder(parent.LeftNode);
                PreOrder(parent.RightNode);
            }
        }

        public void InOrder(Node parent)
        {
            if (parent != null)
            {
                InOrder(parent.LeftNode);
                Console.Write(parent.Data + " ");
                InOrder(parent.RightNode);
            }
        }

        public void PostOrder(Node parent)
        {
            if (parent != null)
            {
                PostOrder(parent.LeftNode);
                PostOrder(parent.RightNode);
                Console.Write(parent.Data + " ");
            }
        }
    }
}
