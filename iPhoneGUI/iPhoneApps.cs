using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Xml;
using System.IO;
using CoreFoundation;

namespace iPhoneList
{
    public class iPhoneApp
    {
        public String Name;
        public String Version;
        public String Description;
        public String Identifier;
        public String Category;
        public String Contact;
        public String AppHome;
        public String Maintainer;
        public String Source;
        public String URL;
        public iPhoneApp(){
        }
    }

    public class iPhoneApps
    {
        private ArrayList apps;
        private Int32 index;
        public PListNodeType Last;
        private String key;
        public String Value;
        public iPhoneApps() {
            apps = new ArrayList();
            Last = PListNodeType.PLDict;
        }

        public iPhoneApp[] Applications {
            get { return (iPhoneApp[])apps.ToArray(typeof(iPhoneApp)); }
            set {
                apps.Clear();
                foreach ( iPhoneApp app in value ) {
                    apps.Add(app);
                }
            }
        }

        public void Add(String Name){
            Add();
            Selected.Name = Name;
        }

        public void Add() {
            iPhoneApp newApp = new iPhoneApp();
            apps.Add(newApp);
            index = apps.Count - 1;
        }

        public void ApplyKey(){
            switch (Key){
                case "Name":
                    ((iPhoneApp)apps[index]).Name = Value;
                    break;
                case "Version":
                    ((iPhoneApp)apps[index]).Version = Value;
                    break;
                case "Description":
                    ((iPhoneApp)apps[index]).Description = Value;
                    break;
                case "Identifier":
                    ((iPhoneApp)apps[index]).Identifier = Value;
                    break;
                case "Category":
                    ((iPhoneApp)apps[index]).Category = Value;
                    break;
                case "Contact":
                    ((iPhoneApp)apps[index]).Contact = Value;
                    break;
                case "AppHome":
                    ((iPhoneApp)apps[index]).AppHome = Value;
                    break;
                case "Maintainer":
                    ((iPhoneApp)apps[index]).Maintainer = Value;
                    break;
                case "Source":
                    ((iPhoneApp)apps[index]).Source = Value;
                    break;
                case "URL":
                    ((iPhoneApp)apps[index]).URL = Value;
                    break;
            }
            key = null;
            Value = null;
        }

        public String Key{
            get {return key;}
            set {
                switch (value.ToLower()){
                    case "name":
                        key = "Name";
                        break;
                    case "bundleidentifier":
                        key = "Identifier";
                        break;
                    case "contact":
                        key = "Contact";
                        break;
                    case "category":
                        key = "Category";
                        break;
                    case "description":
                        key = "Description";
                        break;
                    case "location":
                        key = "Location";
                        break;
                    case "maintainer":
                        key = "Maintainer";
                        break;
                    case "version":
                        key = "Version";
                        break;
                    case "source":
                        key = "Source";
                        break;
                    case "url":
                        key = "URL";
                        break;
                }
            }
        }

        public iPhoneApp Selected{
            get {return (iPhoneApp)apps[index];}
        }

        public void Select(Int32 Index){
            if (Index < apps.Count){
                index = Index;
            }
        }

        public iPhoneApp Select(String Name) {
            foreach (iPhoneApp app in apps) {
                if (app.Name.Equals(Name)) {
                    return (iPhoneApp)app;
                }
            }
            return null;
        }
    }

    public class SpringBoardNode
    {
        private String name;
        private String identifier;

    }

    public class 
    public class NodeCount
    {
        private XmlNodeType type;
        private Int32 count;
        public override string  ToString()
        {
 	         return Type.ToString();
        }
        public NodeCount(XmlNodeType Type){
            type = Type;
            Count = 0;
        }
        public XmlNodeType Type {
            get { return type; }
            set { type = value; }
        }
        public Int32 Count {
            get { return count; }
            set { count = value; }
        }
    }

    public class NodeCounts
    {
        public ArrayList nodes;
        public Int32 index;
        public NodeCounts(){
            nodes = new ArrayList();
        }
        public void Add(XmlNodeType Type) {
            NodeCount node = null;
            Boolean foundNode = false;
            for (Int32 i = 0; i < nodes.Count; i++) {
                node = (NodeCount)nodes[i];
                if (node.Type == Type) {
                    index = i;
                    foundNode = true;
                    break;
                }
            }
            if (!foundNode) {
                node = new NodeCount(Type);
                nodes.Add(node);
                index = nodes.Count - 1;
            }
        }
        public void Inc(XmlNodeType Type){
            Add(Type); //Only Adds the node if it doesn't already exist
            ((NodeCount)nodes[index]).Count++;
        }
        public NodeCount[] Nodes {
            get {
                NodeCount[] outNodes = new NodeCount[nodes.Count];
                outNodes = ((NodeCount[])nodes.ToArray(typeof(NodeCount)));
                return outNodes;
            }
        }
        public Int32 Count {
            get { return nodes.Count; }
        }
    }

    public class AppList
    {
        public static iPhoneApps ReadNullSoftPList(String fullPath){
            return null;
        }

        public static iPhoneApps ReadXmlStream(Stream inStream) {
            iPhoneApps appList = new iPhoneApps();
            NodeCounts nodes = new NodeCounts();
            XmlTextReader textReader = null;
            textReader = new XmlTextReader(inStream);
            textReader.Normalization = true;
            textReader.MoveToContent();
            Boolean inDict = false;
            while (textReader.Read()) {
                XmlNodeType nType = textReader.NodeType;
                String type = nType.ToString();
                String name = textReader.Name;
                String value = textReader.Value.ToString();
                nodes.Inc(nType);
                switch (nType) {
                    case XmlNodeType.Element:
                        Console.WriteLine(nType.ToString() + ": " + textReader.Name.ToString());
                        switch (name) {
                            case "dict":
                                if (!inDict) {
                                    appList.Add();
                                    inDict = true;
                                }
                                break;
                            case "key":
                                appList.Last = PListNodeType.PLKey;
                                break;
                            case "string":
                                appList.Last = PListNodeType.PLString;
                                break;
                        }
                        break;
                    case XmlNodeType.Text:
                        //Console.WriteLine(nType.ToString() + ": " + textReader.Value.ToString());
                        switch (appList.Last) {
                            case PListNodeType.PLKey:
                                appList.Key = value;
                                break;
                            case PListNodeType.PLString:
                                appList.Value = value;
                                appList.ApplyKey();
                                break;
                        }
                        break;
                    case XmlNodeType.EndElement:
                        switch (name) {
                            case "dict":
                                inDict = false;
                                break;
                            case "key":
                                //appList.ApplyKey();
                                break;
                        }
                        break;
                    case XmlNodeType.Whitespace:
                        break;
                    default:
                        //Console.WriteLine(nType.ToString() + ": " + textReader.Name.ToString());
                        break;
                }
            }
            for (Int32 i = 0; i < nodes.Count; i++ ) {
                NodeCount node = nodes.Nodes[i];
                Console.WriteLine(node.ToString() + ": " + node.Count.ToString());
            }
            return appList;
        }
    }
}
