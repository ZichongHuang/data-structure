using System.Collections.Generic;

namespace DataStructure
{
    class node
    {
        private string name;
        private int layerNum;
        private object content;
        private List<node> childs;
        private node parent;

        /// <summary>
        /// 创建一个节点
        /// </summary>
        /// <param name="name">节点名</param>
        public node(string name)
        {
            this.name = name;
            layerNum = -1;
            childs = new List<node>();
            parent = null;
        }

        /// <summary>
        /// 重命名节点
        /// </summary>
        /// <param name="name">节点名</param>
        public void resetName(string name)
        {
            this.name = name;
        }

        public string readName()
        {
            return name;
        }

        /// <summary>
        /// 设置节点所在层数
        /// </summary>
        /// <param name="layerNum">层数</param>
        public void setLayerNum(int layerNum)
        {
            this.layerNum = layerNum;
        }

        /// <summary>
        /// 设置父节点
        /// </summary>
        /// <param name="parent">父节点</param>
        public void setParent(node parent)
        {
            this.parent = parent;
        }

        /// <summary>
        /// 获取父节点
        /// </summary>
        /// <returns>父节点</returns>
        public node getParent()
        {
            return parent;
        }
        /// <summary>
        /// 读取节点所在层数
        /// </summary>
        /// <returns>层数</returns>
        public int readLayerNum()
        {        
                return layerNum;
        }

        /// <summary>
        /// 向节点添加内容
        /// </summary>
        /// <param name="content">内容类</param>
        public void addContent(object content)
        {
            this.content = content;
        }

        /// <summary>
        /// 向节点添加子节点
        /// </summary>
        /// <param name="child">子节点</param>
        /// <returns>重复状态</returns>
        public int addChildNode(node child)
        {
            if (childs.Contains(child))
            {
                return -1;
            }
            else
            {
                this.childs.Add(child);
                return 0;
            }
        }

        /// <summary>
        /// 从节点删除子节点
        /// </summary>
        /// <param name="child">子节点</param>
        public void removeChildNode(node child)
        {
            this.childs.Remove(child);
        }

        /// <summary>
        /// 获取所有子节点
        /// </summary>
        /// <returns>所有子节点</returns>
        public List<node> getChildNode()
        {
            return childs;
        }

        /// <summary>
        /// 删除这个节点下的所有子节点
        /// 从树表中删除这个节点及其子节点
        /// </summary>
        /// <param name="tree">树</param>
        public void delete(tree tree)
        {
            tree.deleteNodeInTreeList(this);
            //从树表中将自己删除
            foreach (node child in childs)
            {
                child.delete(tree);
            }
            //调用子节点的删除方法
            for (int i = 0; i < childs.Count; i++)
            {
                childs[i] = null;
            }
            //释放所有子节点的实例
            childs.Clear();
            //从表中删除所有子节点
        }

    }
}
