using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace stackApp
{
    class queue
    {
        private object[] queueArray;
        private int frontIndex;
        private int rearIndex;

        public queue(int length)
        {
            queueArray = new object[length];
            frontIndex = 0;
            rearIndex = 0;
        }

        private int moveFlag(int index,int move)
        {
            int tempIndex;
            tempIndex = index + move;
            if(tempIndex>=queueArray.Length)
            {
                tempIndex = tempIndex - queueArray.Length;
            }
            else if(tempIndex<=0)
            {
                tempIndex = tempIndex + queueArray.Length;
            }
            return tempIndex;
        }

        public int itemIn(object item)
        {
            if (queueArray[rearIndex]==null)
            {
                queueArray[rearIndex] = item;
                rearIndex=moveFlag(rearIndex,1);
                return 0;
            }
            else
            {
                return -1;
            }
        }

        public object itemOut()
        {
            if(!(queueArray[frontIndex]==null))
            {
                object item;
                item = queueArray[frontIndex];
                queueArray[frontIndex] = null;
                frontIndex = moveFlag(frontIndex, 1);
                return item;
            }
            else
            {
                return -1;
            }
        }






    }
}
