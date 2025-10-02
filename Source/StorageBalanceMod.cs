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
                listLeft.CheckboxLabeled("DedicatedResearchLabel".Translate(), ref settings.useDedicatedResearch);
                listLeft.Label("DedicatedResearchDescription" + settings.useDedicatedResearch.ToString().Translate());
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
