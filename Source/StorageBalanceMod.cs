using System.Xml;
using RimWorld;
using UnityEngine;
using Verse;

namespace StorageBalance
{    
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
            XmlNodeList nodes = xml.SelectNodes($"{xpath}/research");
            if (techPath != null && nodes[0] != null)
            {
                foreach (XmlNode node in nodes)
                {
                    node.InnerText = $"<li>{techPath.InnerText}</li>";
                }
                return true;
            }
            else return false;
        }
    }

    //[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class StorageBalanceMod : Mod
    {
        // Mod Name
        public override string SettingsCategory() => "StorageBalanceModName".Translate();


        // Settings
        public static StorageBalanceSettings settings;
        public static string[] researchTypes = { "Furniture", "Storage" };
        public StorageBalanceMod(ModContentPack content) : base(content)
        {
            settings = GetSettings<StorageBalanceSettings>();
        }
        // Settings GUI
        public override void DoSettingsWindowContents(Rect inRect)
        {
            Rect rectLeftColumn = inRect.LeftPart(0.46f).Rounded();
            Rect rectRightColumn = inRect.RightPart(0.46f).Rounded();

            Listing_Standard list = new Listing_Standard();
            list.Begin(inRect);
            list.CheckboxLabeled("StorageBalanceDoResearchLabel".Translate(), ref settings.doResearch, null);
            list.End();

            Listing_Standard listLeft = new Listing_Standard();
            listLeft.ColumnWidth = rectLeftColumn.width;
            listLeft.Begin(rectLeftColumn);
            if (settings.doResearch)
            {
                listLeft.Gap();
                listLeft.Gap();
                listLeft.Label("StorageBalanceResearchTypeLabel".Translate());
                listLeft.Gap();
                foreach (var option in researchTypes)
                {
                    if (listLeft.RadioButton((option + "ResearchTypeLabel").Translate(), settings.researchType == option, 0f, (option + "ResearchTypeDescription").Translate(), 0.1f))
                    {
                        settings.researchType = option;
                    }
                }
            }
            listLeft.End();

            Listing_Standard listRight = new Listing_Standard();
            listRight.ColumnWidth = rectRightColumn.width;
            listRight.Begin(rectRightColumn);
            listRight.End();

            settings.Write();
        }
    }
}
