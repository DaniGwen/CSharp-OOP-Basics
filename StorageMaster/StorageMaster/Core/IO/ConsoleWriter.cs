using StorageMasterExam.Core.IO.Contracts;
using System;

namespace StorageMasterExam.Core.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
