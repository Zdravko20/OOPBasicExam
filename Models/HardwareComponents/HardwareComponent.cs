namespace SystemSplit.Models.HardwareComponents
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using SoftwareComponents;

    public abstract class HardwareComponent : CustomComponent
    {
        private List<SoftwareComponent> softwareComponents;

        protected HardwareComponent(string name, string type, int maximumCapacity, int maximumMemory)
            : base(name, type)
        {
            this.MaximumCapacity = maximumCapacity;
            this.MaximumMemory = maximumMemory;
            this.softwareComponents = new List<SoftwareComponent>();
        }

        public int CurrentCapacityUsed { get; private set; }

        public int CurrentMemoryUsed { get; private set; }

        public virtual int MaximumCapacity { get; }

        public virtual int MaximumMemory { get; }

        public IReadOnlyList<CustomComponent> SoftwareComponents { get { return this.softwareComponents; } }

        public virtual void AddComponent(SoftwareComponent component)
        {
            if (this.CurrentCapacityUsed + component.CapacityConsumption > this.MaximumCapacity
                || this.CurrentMemoryUsed + component.MemoryConsumption > this.MaximumMemory)
            {
                return;
            }

            this.softwareComponents.Add(component);
            this.CurrentCapacityUsed += component.CapacityConsumption;
            this.CurrentMemoryUsed += component.MemoryConsumption;
        }

        public virtual void RemoveComponent(SoftwareComponent component)
        {
            if (!this.softwareComponents.Contains(component))
            {
                return;
            }

            this.CurrentCapacityUsed -= component.CapacityConsumption;
            this.CurrentMemoryUsed -= component.MemoryConsumption;
            this.softwareComponents.Remove(component);
        }

        public SoftwareComponent GetSoftwareComponent(string softwareComponentName)
        {
            SoftwareComponent component = this.softwareComponents.FirstOrDefault(x => x.Name == softwareComponentName);
            return component;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Hardware Component - {this.Name}");
            result.AppendLine($"Express Software Components - {this.softwareComponents.Count(x => x.Type == "Express")}");
            result.AppendLine($"Light Software Components - {this.softwareComponents.Count(x => x.Type == "Light")}");
            result.AppendLine($"Memory Usage: {this.CurrentMemoryUsed} / {this.MaximumMemory}");
            result.AppendLine($"Capacity Usage: {this.CurrentCapacityUsed} / {this.MaximumCapacity}");
            result.AppendLine($"Type: {this.Type}");
            result.Append(this.softwareComponents.Any() ? 
                $"Software Components: {string.Join(", ", this.softwareComponents)}" 
                : "Software Components: None");

            return result.ToString();
        }
    }
}