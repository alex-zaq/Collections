using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Queue<T>: IEnumerable<T>, IEnumerator<T>,IEnumerable,ICollection
    {

        class Element
        {

            public T data;
            public Element next;
            
        }

        Element head;
        Element tail;

        private Element current;

        public int Count { get; private set; }

        public T Current
        {

            get
            {

                return current.data;

            }


        }

        object IEnumerator.Current => current.data;

        public object SyncRoot => false;

        public bool IsSynchronized => false;

        public Queue()
        {

            head = null;
            tail = null;
            Count = 0;

        }


        public void Enqueue(T data)
        {

            Element elem = new Element();
            elem.data = data;
            elem.next = null;

            if (head==null)
            {
                head = elem;

            }
            else
            {
                tail.next = elem;
            }

            tail = elem;

            Count++;

        }  
        
        public T Dequeue()
        {
            if (head!=null)
            {

            T data = head.data;
            head = head.next;
            Count--;
            return data;

            }
            else
            {
                return default(T);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {

            if (current==null)
            {
                current = head;
            }
            else
            {
                current = current.next;
            }

            return current != null;


        }

        public void Reset()
        {

            current = null;
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }
    }
}
