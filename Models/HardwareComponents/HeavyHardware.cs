namespace SystemSplit.Models.HardwareComponents
{
    public class HeavyHardware : HardwareComponent
    {
        private const string DefaultType = "Heavy";

        public HeavyHardware(string name, int maximumCapacity, int maximumMemory) 
            : base(name, DefaultType, maximumCapacity, maximumMemory)
        {
        }

        public override int MaximumCapacity
        {
            get { return base.MaximumCapacity * 2; }
        }

        public override int MaximumMemory
        {
            get { return base.MaximumMemory - (base.MaximumMemory * 1/4); }
        }
    }
}