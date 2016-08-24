namespace SystemSplit.Core
{
    using Factories;
    using IO;
    using Models.HardwareComponents;
    using Repositories;

    public class EnhancedCommandInterpreter : CommandInterpreter
    {
        private DumpRepository dumpRepository;

        public EnhancedCommandInterpreter
            (OutputWriter writer, 
            SystemRepository systemRepository, 
            DumpRepository dumpRepository,
            HardwareFactory hardwareFactory, 
            SoftwareFactory softwareFactory) 
            : base(writer, systemRepository, hardwareFactory, softwareFactory)
        {
            this.dumpRepository = dumpRepository;
        }

        public override void ParseCommands(string[] inputArgs)
        {
            switch (inputArgs[0])
            {
                case "Dump":
                    this.Dump(inputArgs);
                    break;
                case "Restore":
                    this.Restore(inputArgs);
                    break;
                case "Destroy":
                    this.Destroy(inputArgs);
                    break;
                case "DumpAnalyze":
                    this.Writer.WriteMessageOnNewLine(this.dumpRepository.GetRepositoryInfo());
                    break;
            }

            base.ParseCommands(inputArgs);
        }

        private void Destroy(string[] inputArgs)
        {
            this.dumpRepository.RemoveFromRepository(inputArgs[1]);
        }

        private void Restore(string[] inputArgs)
        {
            HardwareComponent componentToRestore = this.dumpRepository.RemoveFromRepository(inputArgs[1]);
            if (componentToRestore == null)
            {
                return;
            }

            this.SystemRepository.AddToRepository(componentToRestore);
        }

        private void Dump(string[] inputArgs)
        {
            HardwareComponent componentToDump = this.SystemRepository.RemoveFromRepository(inputArgs[1]);
            if (componentToDump == null)
            {
                return;
            }

            this.dumpRepository.AddToRepository(componentToDump);
        }
    }
}

