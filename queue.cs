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

        /// <summary>
        /// 创建一个队列
        /// </summary>
        /// <param name="length">队列长度</param>
        public queue(int length)
        {
            queueArray = new object[length];
            frontIndex = 0;
            rearIndex = 0;
        }

        /// <summary>
        /// 移动指针
        /// </summary>
        /// <param name="index">指针</param>
        /// <param name="move">移动量</param>
        /// <returns></returns>
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

        /// <summary>
        /// 在队尾插入一个项
        /// </summary>
        /// <param name="item">插入项</param>
        /// <returns></returns>
        public int enQueue(object item)
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

        /// <summary>
        /// 在队头取出一个项
        /// </summary>
        /// <returns>取出项</returns>
        public object deQueue()
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
