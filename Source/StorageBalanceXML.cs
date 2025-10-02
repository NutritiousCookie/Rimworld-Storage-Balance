using System.Xml;
using System.Xml.Linq;
using Verse;

namespace StorageBalance
{
    // Def to store research projects
    public class ResearchLevelDef : Def
    {
        public ResearchProjectDef targetDef;
    }
    // PatchOperation to replace research dynamically
    public class PatchOperationStorageResearch : PatchOperation
    {
        public string xpath;
        public string techLevel;
        protected override bool ApplyWorker(XmlDocument xml)
        {
            // Build the xpath dynamically
            XmlNode techPath = xml.SelectSingleNode($"Defs/StorageBalance.ResearchLevelDef[defName=\"{techLevel}\"]/targetDef");
            XmlNodeList nodes = xml.SelectNodes(xpath);
            if (techPath != null && nodes != null)
            {
                foreach (XmlNode node in nodes)
                {
                    // check researchPrerequisites exists and replace InnerText
                    XmlNode researchNode = node.SelectSingleNode("researchPrerequisites");
                    if (researchNode != null)
                    {
                        researchNode.RemoveAll();
                        XmlAttribute attr = xml.CreateAttribute("Inherit");
                        attr.Value = "False";
                        researchNode.Attributes.SetNamedItem(attr);
                        researchNode.AppendChild(xml.CreateElement(null,"li",null)).InnerText = techPath.InnerText;
                    }
                    // create researchPrerequisites if it doesn't
                    else
                    {
                        researchNode = xml.CreateElement(null, "researchPrerequisites", null);
                        XmlAttribute attr = xml.CreateAttribute("Inherit");
                        attr.Value = "False";
                        researchNode.Attributes.SetNamedItem(attr);
                        researchNode.AppendChild(xml.CreateElement(null, "li", null)).InnerText = techPath.InnerText;
                        node.AppendChild(researchNode);
                    }
                }
                return true;
            }
            else return false;
        }
    }
}
