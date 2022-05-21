using System;
using System.Text;

namespace Tree
{
	public class RedBlackNode
	{
        // tree node colors
		public static int	RED		= 0;
		public static int	BLACK	= 1;

		// key provided by the calling class
		private IComparable ordKey;
		// color - used to balance the tree
		private int intColor;
		// left node 
		private RedBlackNode rbnLeft;
		// right node 
		private RedBlackNode rbnRight;
        // parent node 
        private RedBlackNode rbnParent;
		
		
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
		public int Color
		{
			get
            {
				return intColor;
			}
			
			set
			{
				intColor = value;
			}
		}
		
		public RedBlackNode Left
		{
			get
            {
				return rbnLeft;
			}
			
			set
			{
				rbnLeft = value;
			}
		}
		
		public RedBlackNode Right
		{
			get
            {
				return rbnRight;
			}
			
			set
			{
				rbnRight = value;
			}
		}
        public RedBlackNode Parent
        {
            get
            {
                return rbnParent;
            }
			
            set
            {
                rbnParent = value;
            }
        }

		public RedBlackNode()
		{
			Color = RED;
		}
	}
}
