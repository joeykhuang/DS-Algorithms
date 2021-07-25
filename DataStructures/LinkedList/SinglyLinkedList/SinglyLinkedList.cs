using System;
using System.Collections.Generic;

namespace DataStructures.LinkedList.SinglyLinkedList
{
    public class SinglyLinkedList<T>
    {
        private int _length = 0;
        private SinglyLinkedListNode<T> Head { get; set; }

        /// <summary>
        ///     Adds a <c>Node</c> to the beginning of the Linked List
        /// </summary>
        /// <param name="value"> Contents of the new <c>Node</c> </param>
        /// <returns> The newly added <c>Node</c> </returns>
        public SinglyLinkedListNode<T> InsertHead(T value)
        {
            _length++;
            var newElement = new SinglyLinkedListNode<T>(value)
            {
                Next = Head
            };

            Head = newElement;
            return newElement;
        }

        /// <summary>
        ///     Adds a <c>Node</c> to the end of the Linked List
        /// </summary>
        /// <param name="value"> Contents of the new <c>Node</c> </param>
        /// <returns> The newly added <c>Node</c> </returns>
        public SinglyLinkedListNode<T> InsertTail(T value)
        {
            _length++;
            var newElement = new SinglyLinkedListNode<T>(value);

            if (Head == null) {
                Head = newElement;
                return newElement;
            }

            var tempHead = Head;
            while (tempHead.Next != null)
            {
                tempHead = tempHead.Next;
            }

            tempHead.Next = newElement;
            return newElement;
        }

        /// <summary>
        ///     Returns the <c>Node</c> at some index <paramref name="index"/>
        /// </summary>
        /// <param name="index"> The index to query at </param>
        /// <returns> The <c>Node</c> at index <paramref name="index"/></returns>
        public SinglyLinkedListNode<T> GetNode(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            var tempHead = Head;
            for (var i = 0; tempHead != null && i < index; i++)
            {
                tempHead = tempHead.Next;
            }

            return tempHead;
        }

        /// <summary>
        ///     Returns the value of the <c>Node</c> at some index <paramref name="index"/>
        /// </summary>
        /// <param name="index"> The index to query at </param>
        /// <returns> The value of the <c>Node</c> at index <paramref name="index"/></returns>
        public T GetValueAtNode(int index)
        {
            return GetNode(index).Value;
        }

        /// <summary>
        ///     Returns the length of the Linked List
        /// </summary>
        /// <returns> The length </returns>
        public int GetLength()
        {
            return _length;
        }

        /// <summary>
        ///     Returns an <typeparamref name="IEnumerable<T>"/> iterator over the Linked List
        /// </summary>
        /// <returns>An <typeparamref name="IEnumerable<T>"/> iterator</returns>
        public IEnumerable<T> GetIterator()
        {
            var tempElement = Head;

            while (tempElement != null)
            {
                yield return tempElement.Value;
                tempElement = tempElement.Next;
            }
        }

        /// <summary>
        ///     Deletes the first <c>Node</c> of the Linked List
        /// </summary>
        /// <returns>True if deleted; False if Linked List is empty</returns>
        public bool DeleteHead()
        {
            if (Head == null)
            {
                return false;
            }

            _length--;
            Head = Head.Next;
            return true;
        }

        /// <summary>
        ///     Deletes the last <c>Node</c> of the Linked List
        /// </summary>
        /// <returns>True if deleted; False if Linked List is empty</returns>
        public bool DeleteTail()
        {
            if (Head == null)
            {
                return false;
            }

            _length--;
            var tempHead = Head;
            if (tempHead.Next == null)
            {
                Head = null;
                return true;
            }

            while (tempHead.Next != null && tempHead.Next.Next != null)
            {
                tempHead = tempHead.Next;
            }
            tempHead.Next = null;
            return true;
        }


        /// <summary>
        ///     Deletes the first <c>Node</c> with value <paramref name="element"/>
        /// </summary>
        /// <param name="element">The value to delete</param>
        /// <returns>True if deleted; False if Linked List is empty or element not found</returns>
        public bool DeleteElement(T element)
        {
            var tempHead = Head;
            SinglyLinkedListNode<T> previousNode = Head;

            if (Head == null)
            {
                return false;
            }

            if (tempHead.Value.Equals(element))
            {
                Head = tempHead.Next;
                _length--;
                return true;
            }

            do
            {
                tempHead = tempHead.Next;
                if (tempHead.Value.Equals(element))
                {
                    previousNode.Next = tempHead.Next;
                    _length--;
                    return true;
                }
                previousNode = previousNode.Next;
            } while (tempHead.Next != null);

            return false;
        }
    }
}
