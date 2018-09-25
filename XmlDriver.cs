using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace stackApp
{
    /// <summary>
    /// Xml写入器
    /// </summary>
    class XmlW
    {
        XmlDocument Document;

        public XmlW()
        {
            Document = new XmlDocument();
            XmlElement rootElement = Document.CreateElement("tree");
            Document.AppendChild(rootElement);
        }

        /// <summary>
        /// 向Xml添加节点
        /// </summary>
        /// <param name="name">节点名称</param>
        /// <param name="parentName">属性</param>
        /// <param name="layerNum">属性</param>
        public void enNode(string name,string parentName,int layerNum)
        {
            XmlElement node = Document.CreateElement(name);
            node.SetAttribute("parent", parentName);
            node.SetAttribute("layerNum", layerNum.ToString());
            Document.DocumentElement.AppendChild(node);
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="path">文件路径</param>
        public void save(string path)
        {
            Document.Save(path);
        }
    }

    class XmlR
    {
        private XmlDocument document;
        private XmlNodeList NodeList;
        private int index;

        public XmlR(string path)
        {
            document = new XmlDocument();
            document.Load(path);
            NodeList = document.DocumentElement.ChildNodes;
            index = 0;
        }

        /// <summary>
        /// 获取节点信息
        /// </summary>
        /// <returns></returns>
        public string[] getNodeInfo()
        {
            if (index < NodeList.Count)
            {
                XmlNode node = NodeList[index];
                string[] nodeInfo = new string[node.Attributes.Count + 1];
                nodeInfo[0] = node.Name;
                XmlAttributeCollection xmlAttribute = node.Attributes;
                for (int i = 0; i < xmlAttribute.Count; i++)
                {
                    nodeInfo[i + 1] = xmlAttribute[i].Value;
                }
                index++;
                return nodeInfo;
            }
            else
            {
                return null;
            }  
        }
    }
}
