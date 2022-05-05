using System;
using System.Collections.Generic;
using System.Text;

namespace RedBlackTree
{
    class LeftLeaningRedBlackTree<T> where T : IComparable<T>
    {
        //TODO: Make rotate right and rotate left
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
            int firstCount = Count;
            if (rootNode != null)
            {
                rootNode = Remove(rootNode, value);
                if (rootNode != null)
                {
                    rootNode.IsBlack = true;
                }
            }

            return firstCount != Count;
        }
        
        private Node<T> Remove(Node<T> node, T value)
        {
            if (value.CompareTo(node.Value) < 0)
            {
                if (node.Left != null)
                {
                    if (!IsRed(node.Left) && !IsRed(node.Left.Left))
                    {
                        ///node = //make like a swap red function
                    }

                    node.Left = Remove(node.Left, value);
                }
            }

            else
            {
                if (IsRed(node.Left))
                {
                    // need to rotate right 
                }

                if (value.CompareTo(node.Value) == 0 && node.Right == null)
                {
                    Count--;
                    return null;
                }

                if(node.Right != null)
                {
                    if (IsRed(node.Left) && IsRed(node.Left.Left))
                    {
                        //Rotate Right
                    }
                }
                    
            }
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

   

        }
        private void FlipColor(Node<T> node)
        {
            node.IsBlack = !node.IsBlack;
            node.Left.IsBlack = !node.Left.IsBlack;
            node.Right.IsBlack = !node.Right.IsBlack;
        }

        bool IsRed(Node<T> node)
        {
            if (node == null)
            {
                return false;
            }

            return !node.IsBlack;
        }
    }
}
