namespace SystemSplit.Core
{
    using System;
    using Factories;
    using IO;
    using Models.HardwareComponents;
    using Models.SoftwareComponents;
    using Repositories;

    public class CommandInterpreter
    {
        private OutputWriter writer;
        private SystemRepository systemRepository;
        private HardwareFactory hardwareFactory;
        private SoftwareFactory softwareFactory;

        public CommandInterpreter
            (OutputWriter writer,SystemRepository systemRepository ,HardwareFactory hardwareFactory, SoftwareFactory softwareFactory)
        {
            this.writer = writer;
            this.systemRepository = systemRepository;
            this.hardwareFactory = hardwareFactory;
            this.softwareFactory = softwareFactory;
        }

        protected SystemRepository SystemRepository { get { return this.systemRepository; } }

        protected OutputWriter Writer { get { return this.writer; } }

        public virtual void ParseCommands(string[] inputArgs)
        {
            switch (inputArgs[0])
            {
                case "RegisterPowerHardware":
                    this.RegisterHardware(inputArgs);
                    break;
                case "RegisterHeavyHardware":
                    this.RegisterHardware(inputArgs);
                    break;
                case "RegisterExpressSoftware":
                    this.RegisterSoftware(inputArgs);
                    break;
                case "RegisterLightSoftware":
                    this.RegisterSoftware(inputArgs);
                    break;
                case "ReleaseSoftwareComponent":
                    this.ReleaseSoftwareComponent(inputArgs);
                    break;
                case "Analyze":
                    this.writer.WriteMessageOnNewLine(this.systemRepository.GetRepositoryInfo());
                    break;
            }
        }

        private void ReleaseSoftwareComponent(string[] inputLine)
        {
            string[] data = inputLine[1].Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            string hardwareConponentName = data[0];
            string softwareComponentName = data[1];
            this.systemRepository.ReleaseSoftwareComponent(hardwareConponentName, softwareComponentName);
        }

        private void RegisterSoftware(string[] inputLine)
        {
            SoftwareComponent newExpressComponent = this.softwareFactory.CreateSoftwareComponentComponent(inputLine);
            this.systemRepository.AttachSoftwareToHardware(newExpressComponent);
        }

        private void RegisterHardware(string[] inputLine)
        {
            HardwareComponent newPowerComponent =
                this.hardwareFactory.CreateHardwareComponentComponent(inputLine);
            this.systemRepository.AddToRepository(newPowerComponent);
        }

    }
}
