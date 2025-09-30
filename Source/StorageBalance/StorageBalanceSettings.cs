using Verse;
using UnityEngine;

namespace StorageBalance
{
    public class StorageBalanceSettings : ModSettings
    {
        public string researchTree;

        /// <summary>
        /// The part that writes our settings to file. Note that saving is by ref.
        /// </summary>
        public override void ExposeData()
        {
            Scribe_Values.Look(ref researchTree, "Storage research projects", "Vanilla Furniture Expanded");
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
        public static string[] researchTrees = { "Vanilla", "Vanilla Furniture Expanded", "Reel's Storage" };
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
            Listing_Standard listing_Standard = new Listing_Standard();
            listing_Standard.Begin(inRect);
            ///SettingsHelper is apparently outdated
            ///listing_Standard.AddLabeledRadioList($"{"MR_AddExportFormatOptionsDescription".Translate()}:",
            ///                                     researchTrees, ref settings.researchTree);
            listing_Standard.End();
            settings.Write();
        }
    }
}
