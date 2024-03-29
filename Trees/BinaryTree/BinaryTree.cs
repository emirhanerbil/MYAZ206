﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees.BinaryTree
{
    public class BinaryTree<T> :IEnumerable
    {
        public Node<T> Root { get; set; }
        public int Count { get; set; }
        public BinaryTree()
        {
            Count = 0;
        }
        public BinaryTree(IEnumerable<T> collection):this()
        {
            foreach (T item in collection) 
            { 
                Insert(item);
            }  
        }

        public T Insert(T value)
        {
            var newNode = new Node<T>(value);

            if (Root is null)
            {
                Root = newNode;
                Count++;
                return value;
            }
            
            
            var list = new List<Node<T>>();
            var q = new Queue<Node<T>>();
            q.Enqueue(Root);
            while (q.Count>0)
            {
                var temp = q.Dequeue();
                list.Add(temp);
                if(temp.Left != null) q.Enqueue(temp.Left);
                else
                {
                    temp.Left = newNode;
                    Count++;
                    return value;
                }
                if(temp.Right!= null) q.Enqueue(temp.Right);
                else
                {
                    temp.Right = newNode;
                    Count++;
                    return value;
                }
            }
            throw new Exception("Fail");
            
        }
        public static List<Node<T>> LevelOrderTraverse<T>(Node<T> root)
        {
            var list = new List<Node<T>>();
            if (root!=null)
            {
                var q = new Queue<Node<T>>();
                q.Enqueue(root);
                while (q.Count>0)
                {
                    var temp = q.Dequeue();
                    list.Add(temp);
                    if (temp.Left!=null)
                    {
                        q.Enqueue(temp.Left);
                    }
                    if (temp.Right!=null) q.Enqueue(temp.Right);
                }
            }
            return list;
        }

        public IEnumerator GetEnumerator()
        {
            return LevelOrderTraverse(this.Root).GetEnumerator();
        }
        public T Delete(T value)
        {
            throw new Exception();
        }
        public T Delete()
        {
            throw new Exception();
        }
    }
}
