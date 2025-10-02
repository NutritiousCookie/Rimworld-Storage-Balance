using RimWorld;
using UnityEngine;
using Verse;

namespace StorageBalance
{    
    public class StorageBalanceMod : Mod
    {
        // Mod Name
        public override string SettingsCategory() => "StorageBalanceModName".Translate();


        // Settings
        public static StorageBalanceSettings settings;
        public StorageBalanceMod(ModContentPack content) : base(content)
        {
            settings = GetSettings<StorageBalanceSettings>();
        }
        // Settings GUI
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
                if (listLeft.RadioButton(("FurnitureResearchTypeLabel").Translate(), settings.researchTypeFurniture, 0f, ("FurnitureResearchTypeDescription").Translate(), 0.1f))
                {
                    settings.researchTypeFurniture = true;
                    settings.researchTypeStorage = false;
                }
                if (listLeft.RadioButton(("StorageResearchTypeLabel").Translate(), settings.researchTypeStorage, 0f, ("StorageResearchTypeDescription").Translate(), 0.1f))
                {
                    settings.researchTypeFurniture = false;
                    settings.researchTypeStorage = true;
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
