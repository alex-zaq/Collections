using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class List2<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IList, ICollection, IReadOnlyList<T>, IReadOnlyCollection<T>
    {
        private class Element
        {
            public Element next;
            public T value;
            public Element prev;

        }

        private Element start;
        private Element end;

        private Element current;

        public int Count { get; private set; }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public bool IsFixedSize
        {
            get
            {
                return false;
            }
        }

        public object SyncRoot => throw new NotImplementedException();

        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        object IList.this[int index] 
        {
            get
            {
                return this[index];
            }
            set
            {
                this[index] = (T)value;
            }
        }

        //public T Current
        //{
        //    get
        //    {
        //        return this.current.value;
        //    }
        //}

        //object IEnumerator.Current
        //{
        //    get
        //    {
        //        return this.current.value;
        //    }
        //}

        private Element FindElementByValue(T value)
        {
            Element current = start;
            while (current != null)
            {
                if (current.value.Equals(value))
                {
                    return current;
                }
                current = current.next;
            }
            return null;
        }

        private Element FindElementByIndex(int index)
        {
            int count = 0;
            Element current = start;
            while (count != index)
            {
                count++;
                current = current.next;
            }
            return current;
        }

        public T this[int index]
        {
            get
            {
                Element current = FindElementByIndex(index);
                return current.value;
            }
            set
            {
                Element current = FindElementByIndex(index);
                current.value = value;
            }
        }

        public List2()
        {
            start = null;
            end = null;
            Count = 0;
            current = null;
        }

        public void Add(T value)
        {
            Element element = new Element();
            element.value = value;
            element.next = null;
            element.prev = end;

            if (start == null)
            {
                start = element;
            }
            else
            {
                end.next = element;
            }
            end = element;
            Count++;
        }

        public void AddToStart(T value)
        {
            Element element = new Element();
            element.value = value;
            element.next = start;
            element.prev = null;

            if (start == null)
            {
                end = element;
            }
            else
            {
                start.prev = element;
            }
            start = element;
            Count++;
        }

        public void Insert(int index, T value)
        {
            if (index == 0)
            {
                AddToStart(value);
            }
            else
                if (index == Count)
                {
                    Add(value);
                }
                else
                {
                Element current = FindElementByIndex(index - 1);

                Element element = new Element();
                    element.value = value;
                    element.prev = current;
                    element.next = current.next;

                    Element next = current.next;

                    current.next = element;
                    next.prev = element;
                    Count++;
                }

            
        }

        

        private bool Remove(Element element)
        {
            if (element == start) // удаляем первый элемент
            {
                if (Count == 1) // удаляем единственный элемент
                {
                    start = null;
                    end = null;
                }
                start = start.next;
                start.prev = null;
            }
            else
                if (element == end) // удаляем последний элемент
            {
                end = end.prev;
                end.next = null;
            }
            else // удаляем элемент
            {
                Element previous = element.prev;
                Element next = element.next;

                previous.next = next;
                next.prev = previous;
            }
            Count--;
            return true;
        }

        public bool Remove(T value)
        {
            Element current = FindElementByValue(value);
            if (current == null)
            {
                return false;
            }
            return Remove(current);
        }

        public bool RemoveAt(int index)
        {
            Element current = FindElementByIndex(index);
            if (current == null || this.Count == 0 || index > this.Count -1 || index < 0)
            {
                return false;
            }
            return Remove(current);

        }



        public void WriteToConsole()
        {
            Element current = start;
            while (current != null)
            {
                Console.WriteLine(current.value);
                current = current.next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {

            return (IEnumerator<T>)this;
            //Element current = start;
            //while (current != null)
            //{
            //    yield return current.value;
            //    //current = current.next;
            //}
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        void IList<T>.RemoveAt(int index)
        {
            RemoveAt(index);
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Add(object value)
        {
            throw new NotImplementedException();
        }

        public bool Contains(object value)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(object value)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, object value)
        {
            Insert(index, (T)value);
        }

        public void Remove(object value)
        {
            Remove(value);
        }

        void IList.RemoveAt(int index)
        {
            RemoveAt(index);
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        /*public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            if (current == null)
            {
                current = start;
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
        }*/
    }
}
