using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    class PriorityCtl
    {
        queue[] queueArray;

        /// <summary>
        /// 新建一个任务管理器
        /// </summary>
        /// <param name="levelCount">优先级数量</param>
        /// <param name="length">队列长度</param>
        public PriorityCtl(int levelCount,int length)
        {
            queueArray = new queue[levelCount];
            for (int i = 0; i < levelCount; i++)
            {
                queueArray[i] = new queue(length);
            }
        }

        /// <summary>
        /// 新建任务
        /// </summary>
        /// <param name="task">新任务</param>
        /// <param name="level">优先级</param>
        /// <returns></returns>
        public int newTask(object task,int level)
        {
            if(level>0&&level<=queueArray.Length)
            {
                queueArray[level - 1].enQueue(task);
                return 0;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 获得最高优先级任务
        /// </summary>
        /// <returns></returns>
        public object getTask()
        {
            object task;
            for (int i = 0; i < queueArray.Length; i++)
            {
                task = queueArray[i].deQueue();
                if(task != null)
                {
                    return task;
                }
            }  
            return null;
        }

    }
}
