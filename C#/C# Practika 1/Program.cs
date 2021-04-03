using System;
using Task.Resource;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            var СontainerCollection = new Collection();

            СontainerCollection.ReadConatainerDateFromFile();

            AdditionalHints.Menue();

            while (true)
            {
                int OpeationNumber = SearchIndexes.SearchOpeationNumber();

                switch (OpeationNumber)
                {
                    default: break;

                    case 1: СontainerCollection.SearchAllSimilarity(); break;
                    case 2: СontainerCollection.SortData();  break;
                    case 3: СontainerCollection.DeleateContainer(); break;
                    case 4: СontainerCollection.AddContainer(); break;
                    case 5: СontainerCollection.EditContainer(); break;
                    case 6: СontainerCollection.OutputContairnsInformation(); break;
                    case 7: СontainerCollection.Exit(); break;
                }

                AdditionalHints.MenueHint();
                ConsoleKey key = Console.ReadKey().Key;
                if (key is ConsoleKey.Add) AdditionalHints.Menue(); 
            }
        }
    }
}
