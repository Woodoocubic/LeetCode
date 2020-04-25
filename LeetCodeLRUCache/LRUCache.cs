using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLRUCache
{
    public class LRUCache
    {
        internal class Node
        {
            public Node next, prev;
            public int key, val;

            public Node(int key, int val)
            {
                this.key = key;
                this.val = val;
                prev = null;
                next = null;
            }
        }

        private Dictionary<int, Node> _mapToNode;
        private Node _dummyHead; 
        private Node _dummyTail;
        private int Capacity;
        private int used;

        public LRUCache(int capacity)
        {
            this.Capacity = capacity;
            used = 0;
            this._dummyHead = new Node(-1, -1);
            this._dummyTail = new Node(-1, -1);

            _dummyHead.next = _dummyTail;
            _dummyTail.prev = _dummyHead;

            _mapToNode = new Dictionary<int, Node>();
        }

        public int Get(int key)
        {
            if (_mapToNode.ContainsKey(key))
            {
                BumpPriority(key);
                return _mapToNode[key].val;
            }
            else
            {
                return -1;
            }
        }

        public void Put(int key, int value)
        {
            if (this._mapToNode.Count == this.Capacity && !this._mapToNode.ContainsKey(key))
            {
                RemoveLeastUsed();
            }

            if (this._mapToNode.ContainsKey(key))
            {
                this._mapToNode[key].val = value;
            }
            else
            {
                Node node = new Node(key, value);
                this._mapToNode[key] = node;
            }
            BumpPriority(key);
        }

        private void BumpPriority(int key)
        {
            Node nodeToBump = this._mapToNode[key];
            Node tempPrev, tempNext, temp;

            tempPrev = nodeToBump.prev;
            tempNext = nodeToBump.next;

            if (tempNext !=null)
            {
                tempPrev.next = tempNext;
            }

            if (nodeToBump.next != null)
            {
                tempNext.prev = tempPrev;
            }

            temp = this._dummyHead.next;
            this._dummyHead.next = nodeToBump;
            nodeToBump.next = temp;
            temp.prev = nodeToBump;
            nodeToBump.prev = this._dummyHead;

        }

        private void RemoveLeastUsed()
        {
            Node leastUsed = this._dummyTail.prev;
            this._mapToNode.Remove(leastUsed.key);
            Node prevNode = leastUsed.prev;
            prevNode.next = leastUsed.next;
            this._dummyHead = prevNode;
        }
    }
}
