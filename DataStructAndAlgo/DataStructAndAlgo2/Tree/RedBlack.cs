using System.Collections;
using System.Text;
using System;
using System.Reflection;

namespace Tree
{
	public class RedBlack : object
	{
		// the number of nodes contained in the tree
		private int             intCount;
        private int             intHashCode;
		private string          strIdentifier;
		// the tree
		private RedBlackNode	rbTree;
        // a leaf node.
        public static RedBlackNode sentinelNode;          
        // the node that was last found; used to optimize searches
		private RedBlackNode	lastNodeFound;			
		private Random          rand	= new Random();

		public RedBlack() 
        {
            strIdentifier       = base.ToString() + rand.Next();
            intHashCode         = rand.Next();
            sentinelNode        = new RedBlackNode();
            sentinelNode.Left   = null;
            sentinelNode.Right  = null;
            sentinelNode.Parent = null;
            sentinelNode.Color  = RedBlackNode.BLACK;
            rbTree              = sentinelNode;
            lastNodeFound       = sentinelNode;
        }
		
		public RedBlack(string strIdentifier) 
        {
			intHashCode         = rand.Next();
			this.strIdentifier  = strIdentifier;
		}
		
		public void Add(IComparable key)
		{
			if(key == null)
				throw(new RedBlackException("RedBlackNode key and data must not be null"));
			
			// traverse tree - find where node belongs
			int result			=	0;
			// create new node
			RedBlackNode node	=	new RedBlackNode();
			RedBlackNode temp	=	rbTree;				// grab the rbTree node of the tree

			while(temp != sentinelNode)
			{	// find Parent
				node.Parent	= temp;
				result		=  key.CompareTo(temp.Key);
				if(result == 0)
					throw(new RedBlackException("A Node with the same key already exists"));
				if(result > 0)
					temp = temp.Right;
				else
					temp = temp.Left;
			}
			
            // setup node
			node.Key			=	key;
            node.Left           =   sentinelNode;
			node.Right          =   sentinelNode;

			// insert node into tree starting at parent's location
			if(node.Parent != null)	
			{
				result	=  node.Key.CompareTo(node.Parent.Key);
				if(result > 0)
					node.Parent.Right = node;
				else
					node.Parent.Left = node;
			}
			else
				rbTree = node;					// first node added

            RestoreAfterInsert(node);           // restore red-black properities

			lastNodeFound = node;
			
			intCount = intCount + 1;
		}


		private void RestoreAfterInsert(RedBlackNode x)
		{   
			RedBlackNode y;

			while(x != rbTree && x.Parent.Color == RedBlackNode.RED)
			{
				if(x.Parent == x.Parent.Parent.Left)			
				{
					y = x.Parent.Parent.Right;
					if(y!= null && y.Color == RedBlackNode.RED)
					{
						x.Parent.Color			= RedBlackNode.BLACK;
						y.Color					= RedBlackNode.BLACK;
						x.Parent.Parent.Color	= RedBlackNode.RED;	
						x						= x.Parent.Parent;
					}	
					else
					{
						if(x == x.Parent.Right) 
						{
							x = x.Parent;
							RotateLeft(x);
						}
						x.Parent.Color			= RedBlackNode.BLACK;
						x.Parent.Parent.Color	= RedBlackNode.RED;
						RotateRight(x.Parent.Parent);
					}
				}
				else
				{
					y = x.Parent.Parent.Left;
					if(y!= null && y.Color == RedBlackNode.RED)
					{
						x.Parent.Color			= RedBlackNode.BLACK;
						y.Color					= RedBlackNode.BLACK;
						x.Parent.Parent.Color	= RedBlackNode.RED;
						x						= x.Parent.Parent;
					}
					else
					{
						if(x == x.Parent.Left)
						{
							x = x.Parent;
							RotateRight(x);
						}
						x.Parent.Color			= RedBlackNode.BLACK;
						x.Parent.Parent.Color	= RedBlackNode.RED;
						RotateLeft(x.Parent.Parent);
					}
				}																													
			}
			rbTree.Color = RedBlackNode.BLACK;
		}
		
		public void RotateLeft(RedBlackNode x)
		{
			RedBlackNode y = x.Right;			
			x.Right = y.Left;

			if(y.Left != sentinelNode) 
				y.Left.Parent = x;				
            if(y != sentinelNode)
			    y.Parent = x.Parent;			
			if(x.Parent != null)		
			{	
				if(x == x.Parent.Left)			
					x.Parent.Left = y;			
				else
					x.Parent.Right = y;			
			} 
			else 
				rbTree = y;						
			y.Left = x;							 
			if(x != sentinelNode)						
				x.Parent = y;		
		}

		public void RotateRight(RedBlackNode x)
		{
			
			RedBlackNode y = x.Left;			
			x.Left = y.Right;					
			if(y.Right != sentinelNode) 
				y.Right.Parent = x;	
            if(y != sentinelNode)
                y.Parent = x.Parent;
			if(x.Parent != null)
			{	
				if(x == x.Parent.Right)			
					x.Parent.Right = y;	
				else
					x.Parent.Left = y;
			} 
			else 
				rbTree = y;	
			y.Right = x;
			if(x != sentinelNode)
				x.Parent = y;		
		}		
		public IComparable GetMinKey()
		{
			RedBlackNode treeNode = rbTree;
			
            if(treeNode == null || treeNode == sentinelNode)
				throw(new RedBlackException("RedBlack tree is empty"));
			while(treeNode.Left != sentinelNode)
				treeNode = treeNode.Left;
			
			lastNodeFound = treeNode;
			
			return treeNode.Key;
			
		}
		
		public RedBlackEnumerator Keys()
		{
			return Keys(true);
		}

		public RedBlackEnumerator Keys(bool ascending)
		{
			return new RedBlackEnumerator(rbTree, true, ascending);
		}

		public void Remove(IComparable key)
		{
            if(key == null)
                throw(new RedBlackException("RedBlackNode key is null"));
		
			// find node
			int	result;
			RedBlackNode node;

			// see if node to be deleted was the last one found
			result = key.CompareTo(lastNodeFound.Key);
			if(result == 0)
				node = lastNodeFound;
			else
			{	// not found, must search		
				node = rbTree;
				while(node != sentinelNode)
				{
					result = key.CompareTo(node.Key);
					if(result == 0)
						break;
					if(result < 0)
						node = node.Left;
					else
						node = node.Right;
				}

				if(node == sentinelNode)
					return;				// key not found
			}

			Delete(node);
			
			intCount = intCount - 1;
		}
		
		private void Delete(RedBlackNode z)
		{
			RedBlackNode x = new RedBlackNode();
			RedBlackNode y;

			if(z.Left == sentinelNode || z.Right == sentinelNode) 
				y = z;
			else 
			{
				y = z.Right;
				while(y.Left != sentinelNode)
					y = y.Left;
			}

            if(y.Left != sentinelNode)
                x = y.Left;					
            else
                x = y.Right;			
			x.Parent = y.Parent;
			if(y.Parent != null)
				if(y == y.Parent.Left)
					y.Parent.Left = x;
				else
					y.Parent.Right = x;
			else
				rbTree = x;
			if(y != z) 
			{
				z.Key	= y.Key;
			}

			if(y.Color == RedBlackNode.BLACK)
				RestoreAfterDelete(x);

			lastNodeFound = sentinelNode;
		}

		private void RestoreAfterDelete(RedBlackNode x)
		{
			RedBlackNode y;

			while(x != rbTree && x.Color == RedBlackNode.BLACK) 
			{
				if(x == x.Parent.Left)
				{
					y = x.Parent.Right;
					if(y.Color == RedBlackNode.RED) 
					{
						y.Color			= RedBlackNode.BLACK;
						x.Parent.Color	= RedBlackNode.RED;
						RotateLeft(x.Parent);
						y = x.Parent.Right;
					}
					if(y.Left.Color == RedBlackNode.BLACK && 
						y.Right.Color == RedBlackNode.BLACK) 
					{
						y.Color = RedBlackNode.RED;
						x = x.Parent;
					} 
					else 
					{
						if(y.Right.Color == RedBlackNode.BLACK) 
						{
							y.Left.Color	= RedBlackNode.BLACK;
							y.Color			= RedBlackNode.RED;
							RotateRight(y);
							y				= x.Parent.Right;
						}
						y.Color			= x.Parent.Color;
						x.Parent.Color	= RedBlackNode.BLACK;
						y.Right.Color	= RedBlackNode.BLACK;
						RotateLeft(x.Parent);
						x = rbTree;
					}
				} 
				else 
				{
					y = x.Parent.Left;
					if(y.Color == RedBlackNode.RED) 
					{
						y.Color			= RedBlackNode.BLACK;
						x.Parent.Color	= RedBlackNode.RED;
						RotateRight (x.Parent);
						y = x.Parent.Left;
					}
					if(y.Right.Color == RedBlackNode.BLACK && 
						y.Left.Color == RedBlackNode.BLACK) 
					{
						y.Color = RedBlackNode.RED;
						x		= x.Parent;
					} 
					else 
					{
						if(y.Left.Color == RedBlackNode.BLACK) 
						{
							y.Right.Color	= RedBlackNode.BLACK;
							y.Color			= RedBlackNode.RED;
							RotateLeft(y);
							y				= x.Parent.Left;
						}
						y.Color			= x.Parent.Color;
						x.Parent.Color	= RedBlackNode.BLACK;
						y.Left.Color	= RedBlackNode.BLACK;
						RotateRight(x.Parent);
						x = rbTree;
					}
				}
			}
			x.Color = RedBlackNode.BLACK;
		}
		
		
		public void RemoveMin()
		{
            if(rbTree == null)
                throw(new RedBlackException("RedBlackNode is null"));
            
             Remove(GetMinKey());
		}
		
		public int Size()
		{
			// number of keys
			return intCount;
		}
		
		public override int GetHashCode()
		{
			return intHashCode;
		}
		
		public override string ToString()
		{
			return strIdentifier.ToString();
		}
	}
}
