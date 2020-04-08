using StorageMasterExam.Core;
using StorageMasterExam.Core.IO;

namespace StorageMasterExam
{
    public class Startup
    {
        public static void Main()
        {
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();

            var engine = new Engine(reader,writer);

            engine.Run();
        }
    }
}
