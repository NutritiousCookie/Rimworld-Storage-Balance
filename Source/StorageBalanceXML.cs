using System;
using System.Xml;
using Verse;

namespace StorageBalance
{
    // Def to store research projects
    public class ResearchLevelDef : Def
    {
        public ResearchProjectDef targetDefFurniture;
        public string targetDefDedicated; // may be removed, string avoids errors
    }
    // PatchOperation to replace research dynamically
    public class PatchOperationStorageResearch : PatchOperation
    {
        public string xpath;
        public string techLevel;
        public string researchDefName;

        protected override bool ApplyWorker(XmlDocument xml)
        {
            if (StorageBalanceMod.settings.doResearch)
            {
                XmlNodeList thingNodes = xml.SelectNodes(xpath);
                // Find the researchProject name
                if (techLevel != null)
                {
                    if (StorageBalanceMod.settings.useDedicatedResearch) researchDefName = xml.SelectSingleNode($"Defs/StorageBalance.ResearchLevelDef[defName=\"{techLevel}\"]/targetDefDedicated")?.InnerText;
                    if (string.IsNullOrEmpty(researchDefName)) researchDefName = xml.SelectSingleNode($"Defs/StorageBalance.ResearchLevelDef[defName=\"{techLevel}\"]/targetDefFurniture")?.InnerText;
                }
                if (string.IsNullOrEmpty(researchDefName)) researchDefName = "";
                if (thingNodes != null)
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
                        if (!String.IsNullOrEmpty(researchDefName))
                        {
                            newResearchNode.AppendChild(xml.CreateElement(null, "li", null)).InnerText = researchDefName;
                        }
                        // Add to item
                        thingNode.AppendChild(newResearchNode);
                    }
                    return true;
                }
                else return false;
            }
            else return true;
        }
    }
}
