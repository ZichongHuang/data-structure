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

        /// <summary>
        /// 创建一个栈
        /// </summary>
        /// <param name="mostLength">栈的长度</param>
        public stack(int mostLength)
        {
            stackArray = new ArrayList();
            stackArray.Capacity = mostLength;
        }

        /// <summary>
        /// 向栈顶添加一个项
        /// </summary>
        /// <param name="item">添加项</param>
        /// <returns></returns>
        public int push(object item)
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

        /// <summary>
        /// 强制向栈顶添加一个项
        /// </summary>
        /// <param name="item">添加项</param>
        /// <returns></returns>
        public int forcePush(object item)
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

        /// <summary>
        /// 从栈顶取出一个项
        /// </summary>
        /// <returns></returns>
        public object pop()
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

        /// <summary>
        /// 获取栈的长度
        /// </summary>
        /// <returns></returns>
        public int count()
        {
            return stackArray.Count;
        }

        /// <summary>
        /// 改变栈的最大长度
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
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
