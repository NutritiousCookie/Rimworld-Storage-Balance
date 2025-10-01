using Verse;

namespace StorageBalance
{
    public class StorageBalanceSettings : ModSettings
    {
        public bool doResearch;
        public string researchType;
        /// public string researchUltra;

        public override void ExposeData()
        {
            Scribe_Values.Look(ref doResearch, "doStorageResearch");
            Scribe_Values.Look(ref researchType, "researchType", "Furniture");
            base.ExposeData();
        }
    }
}
