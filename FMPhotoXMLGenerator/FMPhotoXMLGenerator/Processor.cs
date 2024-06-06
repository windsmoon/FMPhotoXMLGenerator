using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace FMPhotoXMLGenerator
{
    public class Processor
    {
        #region events
        public Action<string> MessageBoxEvent;
        public Action<float> ProgressEvent;
        #endregion
        
        #region fields
        private const string ConfigXmlFileName = "config.xml";
        private const string StartString = "graphics/pictures/person/";
        private const string StartRandomPlayerString = "graphics/pictures/person/r-";
        private const string EndString = "/portrait";

        // private string _xmlPath;
        // private string[] _images;
        // private XmlDocument _xmlDocument;
        // private Dictionary<int, string> _mappingDict;
        private Data _data;
        private Random _random;
        #endregion

        #region constructors
        public Processor(Data data)
        {
            _data = data;
            DateTime now = DateTime.UtcNow;
            DateTime before = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            _random = new Random(Convert.ToInt32((now - before).TotalSeconds));
        }

        #endregion
        
        #region methods
        public bool GenNewXml()
        {
            if (CollectImages(out string[] images) == false)
            {
                FireMessageBoxEvent(Messages.CollectImagesFail);
                return false;
            }

            if (GenMapping(images, out Dictionary<long, string> mappingDict) == false)
            {
                FireMessageBoxEvent(Messages.GenMappingFail);
                return false;
            }

            if (CreateXmlDocument(out XmlNode listNode) == false)
            {
                FireMessageBoxEvent(Messages.CreateXmlDocumentFail);
                return false;
            }

            if (AppendXmlNodes(mappingDict, listNode) == false)
            {
                FireMessageBoxEvent(Messages.AppendXmlNodesFail);
                return false;
            }

            if (WriteXmlToFile(listNode.OwnerDocument) == false)
            {
                FireMessageBoxEvent(Messages.WriteXmlFileFail);
                return false;
            }
            
            return true;
        }
        
        public bool AppendId()
        {
            if (ParseXML(out XmlDocument xmlDocument) == false)
            {
                FireMessageBoxEvent(Messages.ParseXmlFail);
                return false;
            }

            if (CollectImages(out string[] images) == false)
            {
                FireMessageBoxEvent(Messages.CollectImagesFail);
                return false;
            }
            
            if (ParseMapping(xmlDocument, out Dictionary<long, string> originalMappingDict) == false)
            {
                FireMessageBoxEvent(Messages.ParseMappingFail);
                return false;
            }
            
            if (GenMapping(images, out Dictionary<long, string> newMappingDict) == false)
            {
                FireMessageBoxEvent(Messages.GenMappingFail);
                return false;
            }

            Dictionary<long, string> resultMapping = GetDiffMapping(originalMappingDict, newMappingDict);

            if (resultMapping.Count == 0)
            {
                FireMessageBoxEvent(Messages.NoDiffIdWhenAppend);
                return false;
            }

            if (GetListNode(xmlDocument, out XmlNode listNode) == false)
            {
                FireMessageBoxEvent(Messages.GetListNodeFail);
                return false;
            }

            if (AppendXmlNodes(resultMapping, listNode) == false)
            {
                FireMessageBoxEvent(Messages.AppendXmlNodesFail);
                return false;
            }
            
            if (WriteXmlToFile(listNode.OwnerDocument) == false)
            {
                FireMessageBoxEvent(Messages.WriteXmlFileFail);
                return false;
            }
            
            return true;
        }

        public bool Remapping()
        {
            if (ParseXML(out XmlDocument xmlDocument) == false)
            {
                FireMessageBoxEvent(Messages.ParseXmlFail);
                return false;
            }

            if (ParseMapping(xmlDocument, out Dictionary<long, string> mappingDict) == false)
            {
                FireMessageBoxEvent(Messages.ParseMappingFail);
            }

            if (CollectImages(out string[] images) == false)
            {
                FireMessageBoxEvent(Messages.CollectImagesFail);
                return false;
            }

            if (GenMapping(images, mappingDict.Keys.ToArray(), out Dictionary<long, string> newMappingDict) == false)
            {
                FireMessageBoxEvent(Messages.RemappingFail);
                return false;
            }
            
            if (CreateXmlDocument(out XmlNode listNode) == false)
            {
                FireMessageBoxEvent(Messages.CreateXmlDocumentFail);
                return false;
            }

            if (AppendXmlNodes(newMappingDict, listNode) == false)
            {
                FireMessageBoxEvent(Messages.AppendXmlNodesFail);
                return false;
            }

            if (WriteXmlToFile(listNode.OwnerDocument) == false)
            {
                FireMessageBoxEvent(Messages.WriteXmlFileFail);
                return false;
            }

            return true;
        }
        

        public bool CopyXmlFile()
        {
            if (File.Exists(ConfigXmlFileName) == false)
            {
                FireMessageBoxEvent(Messages.NoConfigInExeDirector);
                return false;
            }

            try
            {
                File.Copy(ConfigXmlFileName, GetComfigXmlFilePathInDirector(), true);
                return true;
            }
            catch (Exception e)
            {
                FireMessageBoxEvent(e.Message);
                return false;
            }
        }

        private bool GenMapping(string[] images, out Dictionary<long, string> mappingDict)
        {
            int idCount = (int)(_data.toId - _data.fromId + 1);
            int imageCount = images.Length;
            mappingDict = new Dictionary<long, string>(idCount);

            if (_data.IsRandomOrder)
            {
                for (long id = _data.fromId; id <= _data.toId; id++)
                {
                    int imageIndex = GetNextRandomInt(0, imageCount);
                    mappingDict.Add(id, images[imageIndex]);
                }
                
            }
            else
            {
                int imageIndex = 0;
                
                for (long id = _data.fromId; id <= _data.toId; id++)
                {
                    mappingDict.Add(id, images[imageIndex]);
                    imageIndex++;

                    if (imageIndex >= imageCount)
                    {
                        imageIndex = 0;
                    }
                }
            }
            
            return true;
        }

        private bool GenMapping(string[] images, long[] ids, out Dictionary<long, string> mappingDict)
        {
            int imageCount = images.Length;
            mappingDict = new Dictionary<long, string>(ids.Length);

            if (_data.IsRandomOrder)
            {
                foreach (long id in ids)
                {
                    int imageIndex = GetNextRandomInt(0, imageCount);
                    mappingDict.Add(id, images[imageIndex]);
                }
            }
            else
            {
                int imageIndex = 0;
                
                foreach (long id in ids)
                {
                    mappingDict.Add(id, images[imageIndex]);
                    imageIndex++;

                    if (imageIndex >= imageCount)
                    {
                        imageIndex = 0;
                    }
                }
            }

            return true;
        }
        
        private Dictionary<long, string> GetDiffMapping(Dictionary<long, string> originalMapping, Dictionary<long, string> newMapping)
        {
            var enumerator = newMapping.Keys.Except(originalMapping.Keys);
            Dictionary<long, string> result = new Dictionary<long, string>();
            
            foreach (long id in enumerator)
            {
                result.Add(id, newMapping[id]);
            }

            return result;
        }

        private bool CreateXmlDocument(out XmlNode listNode)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlDeclaration xmlDeclaration = xmlDocument.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlDocument.AppendChild(xmlDeclaration);
            XmlElement rootElement = xmlDocument.CreateElement("record");
            XmlNode rootNode = xmlDocument.AppendChild(rootElement);
            XmlElement element = xmlDocument.CreateElement("boolean");
            element.SetAttribute("id", "preload");
            element.SetAttribute("value", "false");
            rootElement.AppendChild(element);
            element = xmlDocument.CreateElement("boolean");
            element.SetAttribute("id", "amap");
            element.SetAttribute("value", "false");
            rootNode.AppendChild(element);
            element = xmlDocument.CreateElement("list");
            element.SetAttribute("id", "maps");
            listNode = rootNode.AppendChild(element);
            return true;
        }

        private bool GetListNode(XmlDocument xmlDocument, out XmlNode listNode)
        {
            listNode = xmlDocument.SelectSingleNode("/record/list");
            return listNode != null;
        }
        
        private bool AppendXmlNodes(Dictionary<long, string> mappingDict, XmlNode listNode)
        {
            XmlDocument xmlDocument = listNode.OwnerDocument;
            string resultStartString = _data.IsRandomPlayer ? StartRandomPlayerString : StartString;
            float totalCount = mappingDict.Count;
            float currentCount = 0;
            
            foreach (var pair in mappingDict)
            {
                XmlElement record = xmlDocument.CreateElement("record");
                record.SetAttribute("from", pair.Value);
                record.SetAttribute("to", $"{resultStartString}{pair.Key.ToString()}{EndString}");
                listNode.AppendChild(record);
                currentCount++;
                ProgressEvent?.Invoke(currentCount / totalCount);
            }

            return true;
        }

        private bool WriteXmlToFile(XmlDocument xmlDocument)
        {
            XmlTextWriter xmlTextWriter = new XmlTextWriter(ConfigXmlFileName, Encoding.UTF8);
            
            try
            {
                xmlTextWriter.Formatting = Formatting.Indented;
                xmlTextWriter.Indentation = 4;
                xmlDocument.WriteTo(xmlTextWriter);
            }
            catch (Exception e)
            {
                FireMessageBoxEvent(e.Message);
                return false;
            }
            finally
            {
                xmlTextWriter.Close();
            }
            
            return true;
        }

        private bool IsConfigXmlFileExistInDirector(out string xmlPath)
        {
            xmlPath = GetComfigXmlFilePathInDirector();

            if (File.Exists(xmlPath) == false)
            {
                return false;
            }

            return true;
        }

        private string GetComfigXmlFilePathInDirector()
        {
            return _data.DirectorPath + $"\\{ConfigXmlFileName}";
        }
        
        private bool ParseXML(out XmlDocument xmlDocument)
        {
            if (IsConfigXmlFileExistInDirector(out string xmlPath) == false)
            {
                FireMessageBoxEvent(Messages.NoConfig);
                xmlDocument = null;
                return false;
            }
            
            try
            {
                using (FileStream fileStream = new FileStream(xmlPath, FileMode.Open))
                {
                    xmlDocument = new XmlDocument();
                    xmlDocument.Load(fileStream);
                }
            }
            catch (Exception e)
            {
                // TODO 修改
                FireMessageBoxEvent(e.Message);
                xmlDocument = null;
                return false;
            }
            
            return true;
        }
        
        private bool ParseMapping(XmlDocument xmlDocument, out Dictionary<long, string> mappingDict)
        {
            var recordRoot = xmlDocument.DocumentElement;
            XmlNodeList xmlNodeList = recordRoot.GetElementsByTagName("record");
            mappingDict = new Dictionary<long, string>(xmlNodeList.Count * 2);

            for (int i = 0; i < xmlNodeList.Count; i++)
            {
                XmlNode xmlNode = xmlNodeList[i];
                XmlElement record = xmlNode as XmlElement;
                string imageName = record.GetAttribute("from");
                string toString = record.GetAttribute("to");
                string pattern = _data.IsRandomPlayer ? $@"(?<={StartRandomPlayerString}).+?(?={EndString})" :
                    $@"(?<={StartString}).+?(?={EndString})";
                Match match = Regex.Match(toString, pattern);

                if (match.Success == false)
                {
                    FireMessageBoxEvent(Messages.RegexMatchFail);
                    return false;
                }

                // TODO 抛异常
                string playerIdString = match.Value;
                
                if (match.Value.StartsWith("r-"))
                {
                    playerIdString = match.Value.Replace("r-", string.Empty);
                }

                long playerId = long.Parse(playerIdString);
                mappingDict.Add(playerId, imageName);
            }

            return true;
        }

        private bool CollectImages(out string[] images)
        {
            images = Directory.GetFiles(_data.DirectorPath, "*.png", SearchOption.TopDirectoryOnly);

            if (images.Length == 0)
            {
                FireMessageBoxEvent(Messages.NoImage);
                return false;
            }
            
            for (int i = 0; i < images.Length; i++)
            {
                images[i] = Path.GetFileNameWithoutExtension(images[i]);
            }

            return true;
        }

        private void FireMessageBoxEvent(string message)
        {
            MessageBoxEvent?.Invoke(message);
        }
        
        private int GetNextRandomInt(int from, int to)
        {
            return _random.Next(from, to);
        }
        #endregion
    }
}