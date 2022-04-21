using System;
using System.Collections.Generic;
using System.Text;

namespace RedBlackTree
{
    class LeftLeaningRedBlackTree<T> where T: IComparable<T>
    {
        public int Count { get; private set; }
        Node<T> rootNode;
      public LeftLeaningRedBlackTree()
        {
            Count = 0;
            rootNode = null;

        }

        public void Add(T value)
        {
            rootNode = Add(rootNode, value);
            rootNode.IsBlack = true;
        }

        public bool Remove(T value)
        {

        }


        private Node<T> Add(Node<T> node, T value)
        {
            if (node == null)
            {
                Count++;
                return new Node<T>(value);
            }

            if (IsRed(node.Left) && IsRed(node.Right))
            {
                FlipColor(node);
            }

            if (value.CompareTo(node.Value) < 0)
            {
                node.Left = Add(node.Left, value);
            }
            else if (value.CompareTo(node.Value) > 0)
            {
                node.Right = Add(node.Right, value);
            }
            /*
               else
               {
                   throw new Exception("This thing already exists. EXCEPTION !!!!")
               }
            */

            if (IsRed(node.Right))
            {
                //rotate
            }


            if (IsRed(node.Left) && IsRed(node.Left.Left))
            {
                //Rotate Right
            }

        }
        private void FlipColor(Node<T> node)
        {
            node.IsBlack = !node.IsBlack;
            node.Left.IsBlack = !node.Left.IsBlack;
            node.Right.IsBlack = !node.Right.IsBlack;
        }

        bool IsRed(Node<T> node)
        {
            if(node == null)
            {
                return false;
            }

            return !node.IsBlack;
        }
    }
}
