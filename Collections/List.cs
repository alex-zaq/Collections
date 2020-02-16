using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    class List<T> : IEnumerable<T>, IEnumerator<T>,IList<T>
    {


        class Element
        {

            public Element prev;
            public Element next;
            public T data;


        }


        Element start;
        Element end;

        private Element current;

        public int Count { get; private set; }

        public T Current => this.current.data;

        object IEnumerator.Current => this.current.data;

        public bool IsReadOnly => false;

        public T this[int index]
        {

            get
            {

                Element elem = FindElementByIndex(index);

                if (elem!=null)
                {
                    return elem.data;

                }
                else
                {
                    throw new Exception("Out of range");
                }



            }

            set
            {

                Element elem = FindElementByIndex(index);

                if (elem!=null)
                {
                    elem.data = value;

                }
                else
                {
                    throw new Exception("Out of range");
                }


            } 
        
        
        }

        public List()
        {
            start = null;
            end = null;
            Count = 0;
            current = null;
        }

        private Element FindElementByValue(T value)
        {

            Element current = start;

            while (current != null)
            {
                if (current.data.Equals(value))
                {

                    return current;

                }

                current = current.next;
            }

            return null;

        }

        private Element FindElementByIndex(int index)
        {

            if ((index < 0) || (index > Count - 1))  //!
            {
                return null;
            }


            Element current = start;
            int count = 0;

            while (count != index) //!
            {
                current = current.next;
                count++;
            }

            return current;




        }



        public void Add(T value)
        {

            Element elem = new Element();
            elem.data = value;
            elem.next = null;
            elem.prev = end; //!


            if (start == null)
            {
                start = elem;

            }
            else
            {
                end.next = elem; //!
            }

            end = elem;
            Count++;

        }

        public void AddToStart(T value)
        {

            Element elem = new Element();
            elem.data = value;
            elem.next = start;
            elem.prev = null;//!


            if (start == null)
            {
                end = elem;
            }
            else
            {
                start.prev = elem;
            }

            start = elem;
            Count++;

        }



        public void Insert(int index, T value)
        {

            if (index == 0)   //!
            {

                AddToStart(value);

            }
            else
            if (index == Count) //!
            {
                Add(value);

            }
            else
            {

                Element current = new Element();
                int count = 0;

                while (count < index - 1)  //!
                {
                    count++;
                    current = current.next;
                }

                current.prev.next = current.next;
                current.next.prev = current.prev;
                Count++;

            }


        }


        private bool Remove(Element elem) //!
        {

            if (elem == start)
            {
                if (Count == 1)
                {
                    start = null;
                    end = null;
                    Count = 0;
                    return true;
                }

                start = start.next;
                start.prev = null;
                Count--;


            }
            else
                if (elem == end)
            {
                end = end.prev;
                end.next = null;
                Count--;

            }
            else
            {



                elem.prev.next = elem.next;
                elem.next.prev = elem.prev;
                Count--;

            }

            return true;

        }

        public bool Remove(T value) //!
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

            if ((current == null) || (index < 0) || (index > Count - 1))
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
                System.Console.WriteLine(current.data);
                current = current.next;

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
        }






        public int IndexOf(T value)
        {
            Element elem = FindElementByValue(value);

            if (elem!=null)
            {

                int count = 0;

                while (!elem.data.Equals(value))
                {
                    count++;

                }

                return count;

            }
            else
            {
                return -1;
            }

        }

        void IList<T>.RemoveAt(int index)
        {
            RemoveAt(index);
        }

        public void Clear()
        {

            start = null;
            end = null;
            Count = 0;
            current = null;

        }

        public bool Contains(T value)
        {
            Element elem = FindElementByValue(value);
            return elem != null;

        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }


        public void Dispose()
        {

        }
    }




}
