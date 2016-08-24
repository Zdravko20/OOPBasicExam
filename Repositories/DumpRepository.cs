namespace SystemSplit.Repositories
{
    using System.Linq;
    using System.Text;

    public class DumpRepository : Repository
    {
        public override string GetRepositoryInfo()
        {
            StringBuilder dumpInfo = new StringBuilder();
            dumpInfo.AppendLine("Dump Analysis");
            dumpInfo.AppendLine($"Power Hardware Components: {this.HardwareComponents.Count(x=>x.Type == "Power")}");
            dumpInfo.AppendLine($"Heavy Hardware Components: {this.HardwareComponents.Count(x=>x.Type == "Heavy")}");
            dumpInfo.AppendLine($"Express Software Components: {this.HardwareComponents.Sum(x=>x.SoftwareComponents.Count(y => y.Type == "Express"))}");
            dumpInfo.AppendLine($"Light Software Components: {this.HardwareComponents.Sum(x => x.SoftwareComponents.Count(y => y.Type == "Light"))}");
            dumpInfo.AppendLine(
                $"Total Dumped Memory: {this.HardwareComponents.Sum(x => x.CurrentMemoryUsed)}");
            dumpInfo.Append(
                $"Total Dumped Capacity: {this.HardwareComponents.Sum(x => x.CurrentCapacityUsed)}");

            return dumpInfo.ToString();
        }
    }
}
