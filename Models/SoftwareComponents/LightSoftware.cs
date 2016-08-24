namespace SystemSplit.Models.SoftwareComponents
{
    public class LightSoftware : SoftwareComponent
    {
        private const string DefaultType = "Light";

        public LightSoftware(string name, int capacityConsumption, int memoryConsumption, string hardwareName) 
            : base(name, DefaultType, capacityConsumption, memoryConsumption, hardwareName)
        {
        }

        public override int CapacityConsumption
        {
            get { return base.CapacityConsumption + (base.CapacityConsumption * 1/2); }
        }

        public override int MemoryConsumption
        {
            get { return base.MemoryConsumption - (base.MemoryConsumption * 1/2); }
        }
    }
}