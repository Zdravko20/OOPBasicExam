namespace SystemSplit.Models.SoftwareComponents
{
    public class ExpressSoftware : SoftwareComponent
    {
        private const string DefaultType = "Express";

        public ExpressSoftware(string name, int capacityConsumption, int memoryConsumption, string hardwareName) 
            : base(name, DefaultType, capacityConsumption, memoryConsumption, hardwareName)
        {
        }

        public override int MemoryConsumption
        {
            get { return base.MemoryConsumption * 2; }
        }
    }
}