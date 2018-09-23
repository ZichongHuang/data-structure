using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace stackApp
{
    class stack
    {
        private ArrayList stackArray;

        public stack(int mostLength)
        {
            stackArray = new ArrayList();
            stackArray.Capacity = mostLength;
        }

        public int itemIn(object item)
        {
            if (stackArray.Count < stackArray.Capacity)
            {
                stackArray.Add(item);
                return 0;
            }
            else
            {
                return -1;
            }
        }

        public int itemForceIn(object item)
        {
            if (stackArray.Count < stackArray.Capacity)
            {
                stackArray.Add(item);
                return 0;
            }
            else
            {
                stackArray.Capacity++;
                stackArray.Add(item);
                return -1;
            }
        }

        public object itemOut()
        {
            if (stackArray.Count != 0)
            {
                object temp = stackArray[stackArray.Count - 1];
                stackArray.RemoveAt(stackArray.Count - 1);
                return temp;
            }
            else
            {
                return -1;
            }
        }

        public int count()
        {
            return stackArray.Count;
        }

        public int changeLength(int length)
        {
            if(length>stackArray.Count)
            {
                stackArray.Capacity = length;
                return 0;
            }
            else
            {
                return -1;
            }
        }

    }
}
