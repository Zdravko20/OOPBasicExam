namespace SystemSplit.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Models.HardwareComponents;

    public abstract class Repository
    {
        private List<HardwareComponent> hardwareComponents;

        protected Repository()
        {
            this.hardwareComponents = new List<HardwareComponent>();
        }

        protected List<HardwareComponent> HardwareComponents { get {return this.hardwareComponents;} }

        public void AddToRepository(HardwareComponent component)
        {
            if (component == null)
            {
                return;
            }

            this.hardwareComponents.Add(component);
        }

        public HardwareComponent RemoveFromRepository(string componentName)
        {
            HardwareComponent component = this.hardwareComponents.FirstOrDefault(x => x.Name == componentName);
            if (component == null)
            {
                return null;
            }

            this.hardwareComponents.Remove(component);
            return component;
        }

        public abstract string GetRepositoryInfo();
    }
}
