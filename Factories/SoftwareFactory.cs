namespace SystemSplit.Factories
{
    using System;
    using Models.SoftwareComponents;

    public class SoftwareFactory
    {
        public virtual SoftwareComponent CreateSoftwareComponentComponent(string[] inputArgs)
        {
            SoftwareComponent newComponent = null;
            string[] componentData = inputArgs[1].Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            switch (inputArgs[0])
            {
                case "RegisterExpressSoftware":
                    newComponent = this.CreateExpressSoftware(componentData);
                    break;
                case "RegisterLightSoftware":
                    newComponent = this.CreateLightSoftware(componentData);
                    break;
            }

            return newComponent;
        }

        protected SoftwareComponent CreateLightSoftware(string[] data)
        {
            SoftwareComponent lightSoftwareComponent = new LightSoftware(data[1], int.Parse(data[2]), int.Parse(data[3]), data[0]);
            return lightSoftwareComponent;
        }

        protected SoftwareComponent CreateExpressSoftware(string[] data)
        {
            SoftwareComponent expressSoftwareComponent = new ExpressSoftware(data[1], int.Parse(data[2]), int.Parse(data[3]), data[0]);
            return expressSoftwareComponent;
        }
    }
}

