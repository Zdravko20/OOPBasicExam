namespace SystemSplit.Factories
{
    using System;
    using Models.HardwareComponents;

    public class HardwareFactory
    {
        public virtual HardwareComponent CreateHardwareComponentComponent(string[] inputArgs)
        {
            HardwareComponent newComponent = null;
            string[] componentData = inputArgs[1].Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            switch (inputArgs[0])
            {
                case "RegisterPowerHardware":
                    newComponent = this.CreatePowerHardware(componentData);
                    break;
                case "RegisterHeavyHardware":
                    newComponent = this.CreateHeavyHardware(componentData);
                    break;
            }

            return newComponent;
        }

        protected HardwareComponent CreateHeavyHardware(string[] data)
        {
            HardwareComponent heavyHardwareComponent = new HeavyHardware(data[0], int.Parse(data[1]), int.Parse(data[2]));
            return heavyHardwareComponent;
        }

        protected HardwareComponent CreatePowerHardware(string[] data)
        {
            HardwareComponent powerHardwareComponent = new PowerHardware(data[0], int.Parse(data[1]), int.Parse(data[2]));
            return powerHardwareComponent;
        }
    }
}
