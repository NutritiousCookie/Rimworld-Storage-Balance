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
                        researchNode.AppendChild(xml.CreateElement(null,"li",null)).InnerText = techPath.InnerText;
                    }
                    // create researchPrerequisites if it doesn't
                    else
                    {
                        node.AppendChild(xml.CreateElement(null, "researchPrerequisites", null)).AppendChild(xml.CreateElement(null, "li", null)).InnerText = techPath.InnerText;
                    }
                }
                return true;
            }
            else return false;
        }
    }
}
