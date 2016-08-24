namespace SystemSplit.Core
{
    using System;
    using Factories;
    using IO;
    using Repositories;

    public class Engine
    {
        private InputReader reader;
        private OutputWriter writer;
        private SystemRepository systemRepository;
        private DumpRepository dumpRepository;
        private HardwareFactory hardwareFactory;
        private SoftwareFactory softwareFactory;
        private CommandInterpreter interpreter;

        public Engine
            (InputReader reader,
            OutputWriter writer,
            SystemRepository systemRepository,
            DumpRepository dumpRepository,
            HardwareFactory hardwareFactory,
            SoftwareFactory softwareFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.systemRepository = systemRepository;
            this.dumpRepository = dumpRepository;
            this.hardwareFactory = hardwareFactory;
            this.softwareFactory = softwareFactory;
            this.interpreter =
                new EnhancedCommandInterpreter
                (this.writer, this.systemRepository, this.dumpRepository, this.hardwareFactory, this.softwareFactory);
        }

        public virtual void Run()
        {
            string[] inputLine = this.reader.ReadLine().Split(new[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            while (inputLine[0] != "System Split")
            {
                this.interpreter.ParseCommands(inputLine);
                inputLine = this.reader.ReadLine().Split(new[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            }

            this.writer.WriteMessageOnNewLine(this.systemRepository.PrintAllHardware());
        }
    }
}
