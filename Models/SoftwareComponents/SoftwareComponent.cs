namespace SystemSplit.Models.SoftwareComponents
{
    public abstract class SoftwareComponent : CustomComponent
    {
        protected SoftwareComponent(string name, string type, int capacityConsumption, int memoryConsumption, string hardwareName) 
            : base(name, type)
        {
            this.CapacityConsumption = capacityConsumption;
            this.MemoryConsumption = memoryConsumption;
            this.HardwareName = hardwareName;
        }

        public virtual int CapacityConsumption { get; private set; }

        public virtual int MemoryConsumption { get; private set; }

        public string HardwareName { get; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}