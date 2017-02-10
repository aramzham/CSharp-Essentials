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

        #region Удаление узла дерева

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

                    if (result > 0) parent.Left = current.Left;
                        // Если значение узла родителя больше чем значение удаляемого узла -                 
                        // сделать левого потомка текущего узла - левым потомком родительского узла.                 

                        

                    else if (result < 0)
                    {

                        // Если значение родительского узла меньше чем значение удаляемого узла -                  
                        // сделать левого потомка текущего узла - правым потомком родительского узла.                 

                        parent.Right = current.Left;

                    }
                }
            }

            // Второй вариант: удаляемый узел имеет правого потомка, у которого нет левого потомка.

            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;

                // Удаляем корень 
                if (parent == null)
                {
                    _head = current.Right;
                }

                else
                {
                    result = parent.CompareTo(current.Value);
                    if (result > 0)
                    {
                        // Если значение родительского узла больше чем значение удаляемого узла -                  
                        // сделать правого потомка текущего узла - левым потомком родительского узла. 

                        parent.Left = current.Right;
                    }
                    else if (result < 0)
                    {
                        // Если значение родительского узла меньше чем значение удаляемого узла -                  
                        // сделать правого потомка текущего узла - правым потомком родительского узла. 

                        parent.Right = current.Right;

                    }
                }
            }
            // Третий вариант: удаляемый узел имеет правого потомка, у которого есть левый потомок.

            else
            {

                BinaryTreeNode<T> leftmost = current.Right.Left;
                BinaryTreeNode<T> leftmostParent = current.Right;

                // поиск крайнего левого потомка 
                while (leftmost.Left != null)

                {
                    leftmostParent = leftmost;
                    leftmost = leftmost.Left;
                }

                // Правое поддерево крайнего левого узла, становится левым поддеревом его родительского узла.         
                leftmostParent.Left = leftmost.Right;

                // Присваиваем крайнему левому узлу в качестве левого потомка - левый потомок удаляемого узла,
                // а в качестве правого потомка - правый потомок удаляемого узла. 

                leftmost.Left = current.Left;
                leftmost.Right = current.Right;

                if (parent == null)
                {
                    _head = leftmost;
                }

                else

                {
                    result = parent.CompareTo(current.Value);

                    if (result > 0)
                    {

                        // Если значение родительского узла(parent), больше значения удаляемого узла (current) -                  
                        // сделать левого крайнего потомка удаляемого узла(leftmost)  - левым потомком его родителя(parent). 

                        parent.Left = leftmost;
                    }

                    else if (result < 0)

                    {

                        // Если значение родительского узла(parent), меньше значения удаляемого узла (current) -                  
                        // сделать левого крайнего потомка удаляемого узла(leftmost) - правым потомком его родителя(parent).

                        parent.Right = leftmost;
                    }
                }
            }

            return true;
        }

        #endregion

        #region Enumerator

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
