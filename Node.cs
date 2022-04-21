using System;
using System.Collections.Generic;
using System.Text;

namespace RedBlackTree
{
    class Node<T>
    {
        public T Value;
        public Node<T> Left;
        public Node<T> Right;

        public bool IsBlack;

        public Node (T value)
        {
            this.Value = value;
            IsBlack = false;
            Left = null;
            Right = null;
        }
    }
}
