using System;
using System.Collections;
	
namespace Tree
{
	public class RedBlackEnumerator
	{
		private Stack stack;
		// return the keys
		private bool keys;
		// return in ascending order (true) or descending (false)
		private bool ascending;
		
		// key
		private IComparable ordKey;

        public  string  Color;
        public  IComparable parentKey;

		public IComparable Key
		{
			get
            {
				return ordKey;
			}
			
			set
			{
				ordKey = value;
			}
		}
		public RedBlackEnumerator() 
        {
		}
		
		public RedBlackEnumerator(RedBlackNode tnode, bool keys, bool ascending) 
        {
			
			stack           = new Stack();
			this.keys       = keys;
			this.ascending  = ascending;
			
            if(ascending)
			{
				while(tnode != RedBlack.sentinelNode)
				{
					stack.Push(tnode);
					tnode = tnode.Left;
				}
			}
			else
			{
				while(tnode != RedBlack.sentinelNode)
				{
					stack.Push(tnode);
					tnode = tnode.Right;
				}
			}
			
		}
		public bool HasMoreElements()
		{
			return (stack.Count > 0);
		}
		
		public object NextElement()
		{
			if(stack.Count == 0)
				throw(new RedBlackException("Element not found"));
			RedBlackNode node = (RedBlackNode) stack.Peek();
			
            if(ascending)
            {
                if(node.Right == RedBlack.sentinelNode)
                {
                    RedBlackNode tn = (RedBlackNode) stack.Pop();
                    while(HasMoreElements()&& ((RedBlackNode) stack.Peek()).Right == tn)
                        tn = (RedBlackNode) stack.Pop();
                }
                else
                {
                    RedBlackNode tn = node.Right;
                    while(tn != RedBlack.sentinelNode)
                    {
                        stack.Push(tn);
                        tn = tn.Left;
                    }
                }
            }
            else 
            {
                if(node.Left == RedBlack.sentinelNode)
                {
                    RedBlackNode tn = (RedBlackNode) stack.Pop();
                    while(HasMoreElements() && ((RedBlackNode)stack.Peek()).Left == tn)
                        tn = (RedBlackNode) stack.Pop();
                }
                else
                {
                    RedBlackNode tn = node.Left;
                    while(tn != RedBlack.sentinelNode)
                    {
                        stack.Push(tn);
                        tn = tn.Right;
                    }
                }
            }
			
			Key     = node.Key;

            return keys == true ? node.Key : node.Key;			
		}
		
		public bool MoveNext()
		{
			if(HasMoreElements())
			{
				NextElement();
				return true;
			}
			return false;
		}
	}
}
