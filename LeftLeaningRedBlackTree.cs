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
        public Node<T> RotateRight(Node<T> node)
        {
            Node<T> temporary = node.Left;
            node.Left = temporary.Right;
            temporary.Right = node;

            temporary.IsBlack = node.IsBlack;
            node.IsBlack = false;

            return temporary;
        }

        public Node<T> RotateLeft(Node<T> node)
        {
            Node<T> temporary = node.Right;
            node.Right = temporary.Left;
            temporary.Left = node;

            temporary.IsBlack = node.IsBlack;
            node.IsBlack = false;

            return temporary;
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

        public Node<T> Minimum(Node<T> node)
        {
            Node<T> temporary = node;
            while (temporary.Left != null)
            {
                temporary = temporary.Left;
            }
            return temporary;
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
                    node = RotateRight(node);
                }

                if (value.CompareTo(node.Value) == 0 && node.Right == null)
                {
                    Count--;
                    return null;
                }

                if (node.Right != null)
                {
                    if (!IsRed(node.Right) && !IsRed(node.Right.Left))
                    {
                        //Move Red Right (Node)
                    }

                    if (value.CompareTo(node.Value) == 0)
                    {
                        Node<T> min = Minimum(node.Right);
                        node.Value = min.Value;
                        node.Right = Remove(node.Right, min.Value);
                    }
                    else
                    {
                        node.Right = Remove(node.Right, value);
                    }
                }
            }
            return node;
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
            else
            {
                throw new Exception("This thing already exists. EXCEPTION !!!!");
            }

            if (IsRed(node.Right))
            {
                node = RotateLeft(node);
            }

            if (IsRed(node.Left) && IsRed(node.Left.Left))
            {
                node = RotateRight(node);
            }

            return node;
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
