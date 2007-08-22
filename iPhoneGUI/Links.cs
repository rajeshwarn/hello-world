using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Xml.Serialization;
using System.IO;

namespace iPhoneList
{
    public class LinkNode
    {
        [XmlElement("Name")]
        public String Name;
        [XmlElement("Location")]
        public String Location;
        [XmlElement("Description")]
        public String Description;
        [XmlElement("Parent")]
        public LinkNode Parent;
        [XmlElement("Nodes")]
        public LinkNodes Nodes;

        public LinkNode() { }

    }

    [XmlRoot("Links")]
    public class LinkNodes
    {
        [XmlIgnore]
        public LinkNode SelectedNode;
        [XmlIgnore]
        public Int32 SelectedIndex;
        private ArrayList nodes;
        public LinkNodes() {
            nodes = new ArrayList();
        }
        [XmlElement("Nodes")]
        public LinkNode[] Nodes {
            get {return (LinkNode[])nodes.ToArray(typeof(LinkNode));}
            set {
                nodes.Clear();
                foreach (LinkNode node in value){
                    nodes.Add(nodes);
                }
            }
        }
              
        public void Add(String Location) {
            if ( Location != null ) {
                LinkNode node = new LinkNode();
                node.Name = Location;
                node.Location = Location;
                Add(node);
            }
        }

        public void Add(String Name, String Location) {
            if ( Name != null ) {
                LinkNode node = new LinkNode();
                node.Name = Name;
                node.Location = Location;
                Add(node);
            }
        }
        public void Add(String Name, String Location, String Description) {
            if ( Name != null ) {
                LinkNode node = new LinkNode();
                node.Name = Name;
                node.Location = Location;
                node.Description = Description;
                Add(node);
            }
        }
        public void Add(LinkNode node) {
            if ( node != null ) {
                nodes.Add(node);
                SelectedIndex = nodes.Count - 1;
                SelectedNode = (LinkNode)nodes[SelectedIndex];
            }
        }
        public LinkNodes LoadConfig() {
            LinkNodes nodes = new LinkNodes();
            Boolean prefsLoaded = false;
            String fullPath = AppDomain.CurrentDomain.BaseDirectory + "iPhoneLinks.config";
            if ( File.Exists(fullPath) ) {
                try {
                    XmlSerializer xmlConfig = new XmlSerializer(typeof(LinkNodes));
                    using ( TextReader prefsFile = new StreamReader(fullPath) ) {
                        nodes = (LinkNodes)xmlConfig.Deserialize(prefsFile);
                    }
                    prefsLoaded = true;
                }
                catch ( Exception err ) {
                    Console.WriteLine(err.Message);
                }
            }
            if ( !prefsLoaded || (nodes.Nodes.Length == 0) ) {
                // Files
                nodes.Add("Media Library", "//var/root/Media", "Location of the Media folder");
            }
            return nodes;
        }

        public void SaveConfig() {
            XmlSerializer xmlConfig = new XmlSerializer(typeof(LinkNodes));
            String fullPath = AppDomain.CurrentDomain.BaseDirectory + "iPhoneLinks.config";
            using ( TextWriter prefsFile = new StreamWriter(fullPath) ) {
                xmlConfig.Serialize(prefsFile, this);
            }
        }
    }

    public class LinkTree
    {
        public LinkNodes Nodes;
        public LinkTree() {
            Nodes = new LinkNodes();
        }

    }
}
