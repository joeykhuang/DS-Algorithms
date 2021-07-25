using System;
namespace DataStructures.LinkedList.SinglyLinkedList
{
    public class SinglyLinkedListNode<T>
    {
        public SinglyLinkedListNode(T value)
        {
            Value = value;
            Next = null;
        }

        public T Value { get; }

        public SinglyLinkedListNode<T> Next { get; set; }
    }
}
