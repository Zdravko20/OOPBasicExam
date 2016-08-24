namespace SystemSplit
{
    using System;
    using System.Linq;
    using Core;
    using Factories;
    using IO;
    using Repositories;

    public class Startup
    {
        static void Main()
        {
            InputReader reader = new InputReader();
            OutputWriter writer = new OutputWriter();
            SoftwareFactory softwareFactory = new SoftwareFactory();
            HardwareFactory hardwareFactory = new HardwareFactory();
            SystemRepository systemRepository = new SystemRepository();
            DumpRepository dumpRepository = new DumpRepository();
            Engine engine = new Engine(reader, writer,systemRepository, dumpRepository,hardwareFactory,softwareFactory);
            engine.Run();
        }
    }
}
