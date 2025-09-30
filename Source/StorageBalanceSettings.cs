using Verse;
using UnityEngine;
using RimWorld;

namespace StorageBalance
{
    public class StorageBalanceSettings : ModSettings
    {
        public bool doResearch;
        public string researchTree;

        /// <summary>
        /// The part that writes our settings to file. Note that saving is by ref.
        /// </summary>
        public override void ExposeData()
        {
            Scribe_Values.Look(ref doResearch, "DoStorageResearch", true);
            Scribe_Values.Look(ref researchTree, "StorageResearchProjects", "Furniture");
            base.ExposeData();
        }
    }
    public class StorageBalanceMod : Mod
    {
        /// <summary>
        /// Mod Name
        /// </summary>
        public override string SettingsCategory() => "StorageBalanceModName".Translate();
        /// <summary>
        /// Settings
        /// </summary>
        public static StorageBalanceSettings settings;
        public static string[] researchTrees = { "Furniture", "Storage" };
        public StorageBalanceMod(ModContentPack content) : base(content)
        {
            settings = GetSettings<StorageBalanceSettings>();
        }

        /// <summary>
        /// Settings GUI
        /// </summary>
        /// <param name="inRect">A Unity Rect with the size of the settings window.</param>
        public override void DoSettingsWindowContents(Rect inRect)
        {
            Rect rectLeftColumn = inRect.LeftPart(0.46f).Rounded();
            Rect rectRightColumn = inRect.RightPart(0.46f).Rounded();

            Listing_Standard listLeft = new Listing_Standard();
            listLeft.ColumnWidth = rectLeftColumn.width;
            listLeft.Begin(rectLeftColumn);

            listLeft.CheckboxLabeled("StorageBalanceDoResearchLabel".Translate(), ref settings.doResearch, null);

            if (settings.doResearch)
            {
                listLeft.Gap();
                listLeft.Gap();
                listLeft.Label("StorageBalanceResearchTypeLabel".Translate());
                listLeft.Gap();
                foreach (var option in researchTrees)
                {
                    if (listLeft.RadioButton((option + "ResearchTypeLabel").Translate(), settings.researchTree == option, 0f, (option + "ResearchTypeDescription").Translate(), 0.1f))
                    {
                        settings.researchTree = option;
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
