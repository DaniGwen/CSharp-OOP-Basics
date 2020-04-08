using StorageMasterExam.Core.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMasterExam.Core
{
    public class Engine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly StorageMaster storageMaster;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.storageMaster = new StorageMaster();
        }

        public void Run()
        {
            while (true)
            {
                var command = this.reader.ReadLine();
                if (command == "END")
                {
                    break;
                }
            }


        }
    }
}
