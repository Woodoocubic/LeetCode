using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLRUCache
{
    class LRUCache1
    {
        Dictionary<int, int> keyAndValue = new Dictionary<int, int>();
        Dictionary<int, LinkedListNode<int>> keyAndNode = new Dictionary<int, LinkedListNode<int>>();
        LinkedList<int> linkedList = new LinkedList<int>();

        private int _capacity;

        public LRUCache1(int capacity)
        {
            _capacity = capacity;
        }

        public int Get(int key)
        {
            if (! keyAndValue.ContainsKey(key))
            {
                return -1;
            }

            var result = keyAndValue[key];
            var node = keyAndNode[key];
            linkedList.Remove(node);
            linkedList.AddFirst(node);
            return result;
        }

        public void Put(int key, int value)
        {
            if (!keyAndValue.ContainsKey(key))
            {
                if (_capacity == linkedList.Count)
                {
                    var last = linkedList.Last;
                    linkedList.RemoveLast();
                    keyAndValue.Remove(last.Value);
                    keyAndNode.Remove(last.Value);
                }

                linkedList.AddFirst(key);
                keyAndNode[key] = linkedList.First;
                keyAndValue[key] = value;
            }
            else
            {
                keyAndValue[key] = value;
                var node = keyAndNode[key];
                linkedList.Remove(node);
                linkedList.AddFirst(node);
            }

        }
    }
}
