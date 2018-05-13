using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Node
    {
        public Node(int value)
        {
            this.data = value;
        }
        public Node left { get; set; }
        public Node right { get; set; }
        public int data { get; set; }
    }

    public class TreeOperations
    {
        public void InorderTraversal(Node root)
        {
             if(root == null)
            {
                return;
            }

            InorderTraversal(root.left);
            Console.WriteLine(root.data + " ");
            InorderTraversal(root.right);
        }

        public void PreOrderTraversal(Node root)
        {
            if (root == null)
            {
                return;
            }

            Console.WriteLine(root.data + " ");
            PreOrderTraversal(root.left);
            PreOrderTraversal(root.right);
        }

        public void PostOrderTraversal(Node root)
        {
            if (root == null)
            {
                return;
            }

            Console.WriteLine(root.data + " ");
            PostOrderTraversal(root.left);
            PostOrderTraversal(root.right);
        }


    }

}
