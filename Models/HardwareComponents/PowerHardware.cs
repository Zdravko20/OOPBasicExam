namespace SystemSplit.Models.HardwareComponents
{
    public class PowerHardware : HardwareComponent
    {
        private const string DefaultType = "Power";

        public PowerHardware(string name, int maximumCapacity, int maximumMemory) 
            : base(name, DefaultType, maximumCapacity, maximumMemory)
        {
        }

        public override int MaximumCapacity
        {
            get { return base.MaximumCapacity - (base.MaximumCapacity *3/4); }
        }

        public override int MaximumMemory
        {
            get { return base.MaximumMemory + (base.MaximumMemory *3/4); }
        }
    }
}