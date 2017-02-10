using System;
using System.Collections.Generic;

namespace Tree
{
    class BinaryTreeNode<TNode> : IComparable<TNode> where TNode : IComparable<TNode>
    {
        public BinaryTreeNode(TNode value)
        {
            Value = value;
        }
        public BinaryTreeNode<TNode> Left { get; set; }
        public BinaryTreeNode<TNode> Right { get; set; }

        public TNode Value { get; }

        public int CompareTo(TNode other)
        {
            return Value.CompareTo(other);
        }

    }
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private BinaryTreeNode<T> _head;

        public int Count { get; private set; }

        #region Add new node to tree

        public void Add(T value)
        {
            // if the tree is empty    

            if (_head == null) _head = new BinaryTreeNode<T>(value);

            // if the tree is not empty we will use recursion to find a place to add the node       

            else AddTo(_head, value);

            Count++;
        }

        private void AddTo(BinaryTreeNode<T> node, T value)
        {
            //if the value to add is inferior to the current

            if (value.CompareTo(node.Value) < 0)
            {
                // if there is no child node, add it      

                if (node.Left == null) node.Left = new BinaryTreeNode<T>(value);
                else AddTo(node.Left, value);   // turning again
            }

            // if the value to add if grater or equal to the current value   
            else
            {
                // if there is no right child, we'll add it       

                if (node.Right == null) node.Right = new BinaryTreeNode<T>(value);
                else AddTo(node.Right, value); // turn again
            }
        }

        #endregion

        #region Search for a node in tree

        public bool Contains(T value)
        {
            // returns first found node, if nothing found -> null, it finds also its parent node
            BinaryTreeNode<T> parent;
            return FindWithParent(value, out parent) != null;
        }

        private BinaryTreeNode<T> FindWithParent(T value, out BinaryTreeNode<T> parent)
        {
            var current = _head;
            parent = null;
            var result = 0;

            while (current != null)
            {
                result = current.CompareTo(value); //CompareTo returns us a positive integer if current>value, 0 if current=value, negative one if current<value
                if (result > 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (result < 0)
                {
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    // we've found what we were looking for             
                    break;
                }
            }
            return current;
        }

        #endregion

        #region Remove whole tree

        public void Clear()
        {
            _head = null;
            Count = 0;
        }

        #endregion

        #region Remove node from tree

        public bool Remove(T value)
        {
            BinaryTreeNode<T> current;
            BinaryTreeNode<T> parent;
            var result = 0;

            // find a node to remove
            current = FindWithParent(value, out parent);

            if (current == null) return false;

            Count--;

            // First version: node to be removed doesn't have a right child     

            if (current.Right == null)
            {
                // Remove the root
                if (parent == null) _head = current.Left;
                else
                {
                    result = parent.CompareTo(current.Value);

                    // if the parent node value is grater than removable node's, make current's left child node the left of the parent         
                    if (result > 0) parent.Left = current.Left;

                    // if the parent node value is grater than removable node's, make current's left node the right one of the parent
                    else if (result < 0) parent.Right = current.Left;
                }
            }

            // Second version: the removable node has a right child which doesn't have a left one

            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;

                // Removing the root
                if (parent == null) _head = current.Right;
                else
                {
                    result = parent.CompareTo(current.Value);

                    // if the parent node value is grater than removable node's, make current's right child node the left of the parent
                    if (result > 0) parent.Left = current.Right;

                    // if the parent node value is smaller than removable node's, make current's right child node the right of the parent
                    else if (result < 0) parent.Right = current.Right;
                }
            }
            // Third version: the removable node has a right child which has a left one

            else
            {
                var leftmost = current.Right.Left;
                var leftmostParent = current.Right;

                // finding the leftmost node
                while (leftmost.Left != null)
                {
                    leftmostParent = leftmost;
                    leftmost = leftmost.Left;
                }

                // Right node of leftmost node becomes left node of its parent one         
                leftmostParent.Left = leftmost.Right;

                // Assigning the leftmost node as the left child the left node of the removable one, and for the right child - the right one of the removable node
                leftmost.Left = current.Left;
                leftmost.Right = current.Right;

                if (parent == null) _head = leftmost;
                else
                {
                    result = parent.CompareTo(current.Value);

                    // if the value of the parent value is grater than the current one, make the leftmost child node the left node of its parent
                    if (result > 0) parent.Left = leftmost;

                    // if the value of parent node is inferior to removable node value, make the leftmost node of the removable one - the right child of its parent
                    else if (result < 0) parent.Right = leftmost;
                }
            }

            return true;
        }

        #endregion

        #region Enumerator

        public IEnumerator<T> GetEnumerator()
        {
            return PreOrderTraversal();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()

        {
            return GetEnumerator();
        }
        public IEnumerator<T> PreOrderTraversal() // need to be implemented
        {
            BinaryTreeNode<T> current = _head;

            yield return current.Value;
        }
        #endregion
    }
}
