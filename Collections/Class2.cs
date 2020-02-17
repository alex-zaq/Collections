using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Stack<T>
    {

        class Element
        {

            public Element prev;
            public T data;

        }

        Element top;

        public int Count { get; private set; }

        public Stack()
        {
            top = null;
            Count = 0;

        }


        public void Push(T data)
        {

            Element elem = new Element();
            elem.data = data;
            elem.prev = top;
            top = elem;
            Count++;


        }


        public T Pop()
        {
            if (top!=null)
            {

            T data = top.data;
            top = top.prev;
            Count--;
            return data;

            }
            else
            {
                return default(T);
            }

        }


    }
}
