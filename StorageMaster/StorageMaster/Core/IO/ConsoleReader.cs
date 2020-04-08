using StorageMasterExam.Core.IO.Contracts;
using System;

namespace StorageMasterExam.Core.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
