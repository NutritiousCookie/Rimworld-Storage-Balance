using Verse;

namespace StorageBalance
{
    public class StorageBalanceSettings : ModSettings
    {
        public bool doResearch = true;
        public bool useDedicatedResearch = true;
        /// public string researchUltra;

        public override void ExposeData()
        {
            Scribe_Values.Look(ref doResearch, "doStorageResearch", defaultValue: true, forceSave: true);
            Scribe_Values.Look(ref useDedicatedResearch, "useDedicatedResearch", defaultValue: true, forceSave: true);
            base.ExposeData();
        }
    }
}
