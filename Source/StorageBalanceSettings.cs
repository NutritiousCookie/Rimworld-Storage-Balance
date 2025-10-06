using Verse;

namespace StorageBalance
{
    public class StorageBalanceSettings : ModSettings
    {
        public bool doResearch;
        public bool useDedicatedResearch;
        /// public string researchUltra;

        public override void ExposeData()
        {
            Scribe_Values.Look(ref doResearch, "doStorageResearch", true, true);
            Scribe_Values.Look(ref useDedicatedResearch, "useDedicatedResearch", true, true);
            base.ExposeData();
        }
    }
}
