using System.Xml;
using System.Xml.Linq;
using Verse;
using Verse.AI;

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
        public string techDef;

        protected override bool ApplyWorker(XmlDocument xml)
        {
            XmlNodeList thingNodes = xml.SelectNodes(xpath);
            // Build the xpath dynamically
            if (techLevel != null) {
                techDef = xml.SelectSingleNode($"Defs/StorageBalance.ResearchLevelDef[defName=\"{techLevel}\"]/targetDef").InnerText;
            }
            else if (techDef != "")
            {
                techDef = xml.SelectSingleNode($"Defs/StorageBalance.ResearchLevelDef[defName=\"{techDef}\"]/targetDef").InnerText;
            }
            if (techDef != null && thingNodes != null)
            {
                foreach (XmlNode thingNode in thingNodes)
                {
                    // remove all researchPrerequisites nodes entirely
                    XmlNodeList oldResearchNodes = thingNode.SelectNodes("researchPrerequisites");
                    if (oldResearchNodes != null)
                    {
                        foreach (XmlNode node in oldResearchNodes)
                        {
                            node.ParentNode.RemoveChild(node);
                        }
                    }
                    // then create a new researchPrerequisites node
                    XmlNode newResearchNode = xml.CreateElement(null, "researchPrerequisites", null);
                    // set Inherit = "False"
                    XmlAttribute attr = xml.CreateAttribute("Inherit");
                    attr.Value = "False";
                    newResearchNode.Attributes.SetNamedItem(attr);
                    // Set desired tech list item
                    newResearchNode.AppendChild(xml.CreateElement(null, "li", null)).InnerText = techDef;
                    // Add to item
                    thingNode.AppendChild(newResearchNode);
                }
                return true;
            }
            else return false;
        }
    }
}
