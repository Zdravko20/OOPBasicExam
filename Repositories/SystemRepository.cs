namespace SystemSplit.Repositories
{
    using System.Linq;
    using System.Text;
    using Models.HardwareComponents;
    using Models.SoftwareComponents;

    public class SystemRepository : Repository
    {
        public void AttachSoftwareToHardware(SoftwareComponent softwareComponent)
        {
            HardwareComponent componentToAttachTo =
                this.HardwareComponents.FirstOrDefault(x => x.Name == softwareComponent.HardwareName);
            if (componentToAttachTo == null)
            {
                return;
            }

            componentToAttachTo.AddComponent(softwareComponent);
        }

        public void ReleaseSoftwareComponent(string hardwareComponentName, string softwareComponentName)
        {
            HardwareComponent hardwareComponent =
                this.HardwareComponents.FirstOrDefault(x => x.Name == hardwareComponentName);
            if (hardwareComponent == null)
            {
                return;
            }

            SoftwareComponent softwareComponent = hardwareComponent.GetSoftwareComponent(softwareComponentName);
            if (softwareComponent == null)
            {
                return;
            }

            hardwareComponent.RemoveComponent(softwareComponent);
        }

        public string PrintAllHardware()
        {
            StringBuilder result = new StringBuilder();
            foreach (var hardwareComponent in this.HardwareComponents.OrderByDescending(x => x.Type))
            {
                result.AppendLine(hardwareComponent.ToString());
            }

            return result.ToString().Trim();
        }

        public override string GetRepositoryInfo()
        {
            StringBuilder systemInfo = new StringBuilder();
            systemInfo.AppendLine("System Analysis");
            systemInfo.AppendLine($"Hardware Components: {this.HardwareComponents.Count}");
            systemInfo.AppendLine($"Software Components: {this.HardwareComponents.Sum(x => x.SoftwareComponents.Count)}");
            systemInfo.AppendLine(
                $"Total Operational Memory: {this.HardwareComponents.Sum(x => x.CurrentMemoryUsed)} / {this.HardwareComponents.Sum(x => x.MaximumMemory)}");
            systemInfo.Append(
                $"Total Capacity Taken: {this.HardwareComponents.Sum(x => x.CurrentCapacityUsed)} / {this.HardwareComponents.Sum(x => x.MaximumCapacity)}");

            return systemInfo.ToString();
        }
    }
}
