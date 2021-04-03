using System;
using System.Collections.Generic;
using System.Text;

namespace Task.Resource
{
    static class SearchIndexes
    {
        public static int SearchOpeationNumber()
        {

            int OperationNumber;
            while (true)
            {
                string Operation = Console.ReadLine();
                bool isValidOperation = int.TryParse(Operation, out OperationNumber);

                if (isValidOperation is false)
                {
                    Console.WriteLine("You can enter only numbers");
                    continue;
                }
                if (OperationNumber < 1 || OperationNumber > 7)
                {
                    Console.WriteLine("Incorrect operation");
                    continue;
                }
                break;
            }
            return OperationNumber;

        }
    }
}
