using Verse;

namespace StorageBalance
{
    public class StorageBalanceSettings : ModSettings
    {
        public bool doResearch;
        public bool researchTypeFurniture;
        public bool researchTypeStorage;
        /// public string researchUltra;

        public override void ExposeData()
        {
            Scribe_Values.Look(ref doResearch, "doStorageResearch", true, false);
            Scribe_Values.Look(ref researchTypeFurniture, "researchTypeFurniture", true, false);
            Scribe_Values.Look(ref researchTypeStorage, "researchTypeStorage", false, false);
            base.ExposeData();
        }
    }
}
