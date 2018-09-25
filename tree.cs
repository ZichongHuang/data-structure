using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    class tree
    {
        private List<List<node>> treeList;

        /// <summary>
        /// 创建一颗树并自动添加一个根节点
        /// </summary>
        public tree()
        {
            treeList = new List<List<node>>();
            List<node> layer = new List<node>();
            treeList.Add(layer);
            node rootNode = new node("root");
            rootNode.setLayerNum(0);
            treeList[0].Add(rootNode);
        }

        /// <summary>
        /// 在树表中添加一个节点
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="layerNum">层数</param>
        private void addNode2Layer(node node)
        {
            int layerNum = node.readLayerNum();
            if(treeList.Count<=layerNum)
            {
                //第一次到达该层
                treeList.Add(new List<node>());
                //新建一个层
                treeList[layerNum].Add(node);
                //向层中添加节点
            }
            else
            {
                //已经有该层
                treeList[layerNum].Add(node);
            }
        }

        /// <summary>
        /// 创建并添加一个节点
        /// </summary>
        /// <param name="parent">父节点</param>
        /// <param name="name">节点名</param>
        /// <returns>新节点</returns>
        public node addNode(node parent,string name)
        {
            int layerNum = parent.readLayerNum() + 1;
            //获得这个节点的层数
            node node = new node(name);
            //创建节点
            node.setLayerNum(layerNum);
            //设置层数
            node.setParent(parent);
            //添加父节点
            parent.addChildNode(node);
            //向父节点添加
            addNode2Layer(node);
            //向树表添加
            return node;
        }

        /// <summary>
        /// 在整颗树中查找节点
        /// </summary>
        /// <param name="name">节点名</param>
        /// <returns>节点</returns>
        public node findNode(string name)
        {
            foreach (List<node> layer in treeList)
            {
                foreach (node node in layer)
                {
                    if(node.readName()==name)
                    {
                        return node;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 在指定层查找结点
        /// </summary>
        /// <param name="name">节点名</param>
        /// <param name="layerNum">层数</param>
        /// <returns>节点</returns>
        public node findNode(string name,int layerNum)
        {
            if (layerNum < treeList.Count)
            {
                foreach (node node in treeList[layerNum])
                {
                    if (node.readName() == name)
                    {
                        return node;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 在指定区间查找结点
        /// </summary>
        /// <param name="name">节点名</param>
        /// <param name="minLayer">起点层数</param>
        /// <param name="maxLayer">终点层数</param>
        /// <returns>节点</returns>
        public node findNode(string name,int minLayer,int maxLayer)
        {
            if ((maxLayer < treeList.Count)&&(minLayer>0))
            {
                for (int i = minLayer; i <= maxLayer; i++)
                {
                    List<node> layer = treeList[i];
                    foreach (node node in layer)
                    {
                        if (node.readName() == name)
                        {
                            return node;
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 从树表中删除节点
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="layerNum">层数</param>
        public void deleteNodeInTreeList(node node)
        {
            int layerNum = node.readLayerNum();
            treeList[layerNum].Remove(node);
        }

        /// <summary>
        /// 彻底删除节点及其所有子节点
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="layerNum">层数</param>
        public void deleteNode(node node)
        {
            node.delete(this);
            node.getParent().removeChildNode(node);
            node = null;
        }

        /// <summary>
        /// 输出树结构
        /// </summary>
        /// <returns>包含树结构的字符串</returns>
        public string printTree()
        {
            StringBuilder treeNode=new StringBuilder(20);
            foreach (List<node> layer in treeList)
            {
                foreach (node node in layer)
                {
                    treeNode.Append(node.readName());
                    treeNode.Append("  ");
                }
                //层读取结束
                treeNode.Append("\n");
            }
            return treeNode.ToString();
        }

        /// <summary>
        /// 保存树为文件
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public int save(string path)
        {

            XmlW XmlFile = new XmlW();
            foreach (List<node> layer in treeList)
            {
                foreach (node node in layer)
                {
                    if (node.getParent() != null)
                    {
                        XmlFile.enNode(node.readName(), node.getParent().readName(), node.readLayerNum());
                    }
                    else
                    {
                        XmlFile.enNode(node.readName(),"null", node.readLayerNum());
                    }
                }
            }
            XmlFile.save(path);
            return 0;
        }

        /// <summary>
        /// 从文件读取树
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public int load(string path)
        {
            XmlR xmlR = new XmlR(path);
            string[] temp = new string[3];
            for (; ; )
            {
                temp = xmlR.getNodeInfo();
                if (temp == null)
                {
                    break;
                }
                else
                {
                    if (temp[0] != "root")
                    {
                        addNode(findNode(temp[1], int.Parse(temp[2]) - 1), temp[0]);
                    }
                }
            }
            return 0;
        }
    }
}
