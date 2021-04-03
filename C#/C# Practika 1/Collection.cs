using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Linq;
using Task.Resource;

namespace Task
{
    class Collection
    {
        #region Public Date
        public List<Сontainer> Сontainers { get; set; } = new List<Сontainer>();
        #endregion

        #region Privte Date
        private string FilePath = "StartInfo.txt";
        #endregion

        #region Public Methods
        public void ReadConatainerDateFromFile()
        {
            if (File.Exists(FilePath) is false)
            using (File.Create(FilePath)) { }

            using (var sr = new StreamReader(FilePath))
            {
                int containersCount = 1;
                while (true)
                {
                    try
                    {
                        var container = FileReader.ReadFromFile(sr);

                        var allId = new string[Сontainers.Count];
                        allId = Enumerable
                            .Range(0, allId.Length)
                            .Select(x => allId[x] = Сontainers[x].Id.ToString())
                            .ToArray();
                        Validation.IdValidation(container.Id.ToString(), allId);

                        Сontainers.Add(new Сontainer(container));

                        Console.WriteLine($"Container {containersCount} has been added!");

                        containersCount++;
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("Value cannot be null.")) break;

                        Console.WriteLine(ex.Message + "\nContainer not added");
                    }
                }    
            }
        }
        #region Actions
        public void EditContainer()
        {
            Console.Write("Input container Id to change it: ");
            int Id = SearchContainersId();

            if (Сontainers.Exists(x => x.Id.ToString().Contains(Id.ToString())) is false)
            {
                Console.WriteLine("This id is not correct. . .");
                return;
            }

            int index = Сontainers
                .Select((item, i) => new { Item = item, Index = i })
                 .First(x => x.Item.Id == Id).Index;


            Сontainers[index] = CreateNewContainer();

            AddContainersToFile();

            Console.WriteLine("\nContainer has been edit!\n");

        }
        public void AddContainer()
        {
            Сontainer container = CreateNewContainer();

            Сontainers.Add(new Сontainer(container));

            Console.WriteLine("\nContainer has been added!\n");

            AddContainersToFile();            
        }
        public void DeleateContainer()
        {
            Console.Write("Input container Id to deleate it: ");
            int Id = SearchContainersId();

            int index = Сontainers
              .Select((item, i) => new { Item = item, Index = i })
               .First(x => x.Item.Id == Id).Index;

            Сontainers.Remove(Сontainers[index]);

            AddContainersToFile();

            Console.WriteLine("\nContainer has been deleated!\n");

        }
        public void OutputContairnsInformation()
        {
            foreach (var x in Сontainers)
                Console.WriteLine(x.ToString());
        }
        public void SortData()
        {
            AdditionalHints.ContainerFields();
            Console.Write("Select the field by which collection will be sorted: ");
            int Operation = SearchIndexes.SearchOpeationNumber();
            Sorting(Operation);
            Console.WriteLine("\nContainers has been sorted\n");
        }
        public void SearchAllSimilarity()
        {
            Console.WriteLine("\nEnter some words to find information: ");
            string keyWord = Console.ReadLine();

            for (int i = 0; i < Сontainers.Count; i++)
            {
                string[] containerFields = ContainersFieldToArray(Сontainers[i]);

                for (int j = 0; j < containerFields.Length; j++)
                {
                    if (containerFields[j].Contains(keyWord, StringComparison.CurrentCultureIgnoreCase))
                    {
                        Console.WriteLine($"{containerFields[j]} is in {Сontainers[i].Id} containers. . . ");
                    }
                }
            }
            Console.WriteLine();
        }
        public void Exit()
        {
            Environment.Exit(0);
        }
        #endregion
        #endregion

        #region Private Methods
        private string[] ContainersFieldToArray(Сontainer Сontainers)
        {
            var FieldsArray = (from x in typeof(Сontainer)
                        .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                        select x.GetValue(Сontainers, null).ToString()).ToArray();

            return FieldsArray;
        }
        
        private int SearchContainersId()
        {
            int Id = 0;;
            while (true)
            {
                string number = Console.ReadLine();
                bool isValidNumber = int.TryParse(number, out Id);
                if (isValidNumber is false)
                {
                    Console.WriteLine("Please input number");
                    continue;
                }
                var IsTheIndexExist = Сontainers.Exists(x => x.Id.ToString().Contains(Id.ToString()));
                if (IsTheIndexExist is false)
                {
                    Console.WriteLine("Id is incorrect");
                    continue;
                }
                break;
            }
            return Id;
        }
        private Сontainer CreateNewContainer()
        {
            var container = new Сontainer();
            while (true)
            {
                try
                {
                    Console.Write("Input Id: ");
                    container.Id = int.Parse(Console.ReadLine());
                    var allId = new string[Сontainers.Count];
                    allId = Enumerable.Range(0, allId.Length).Select(x => allId[x] = Сontainers[x].Id.ToString()).ToArray();
                    Validation.IdValidation(container.Id.ToString(), allId);


                    Console.Write("Input Container Number: ");
                    container.Number = Console.ReadLine();

                    Console.Write("Input Departure Citys: ");
                    container.DepartureCitys = (DepartureCitys)Enum.Parse(typeof(DepartureCitys), Console.ReadLine());

                    Console.Write("Input Arrival Citys: ");
                    container.ArrivalCitys = (ArrivalCitys)Enum.Parse(typeof(ArrivalCitys), Console.ReadLine());

                    Console.Write("Input DepatureDate: ");
                    container.DepatureDate = DateTime.Parse(Console.ReadLine());
                    Validation.DepartureDateValidation(container.DepatureDate);

                    Console.Write("Input Arrival Date: ");
                    container.ArrivalDate = DateTime.Parse(Console.ReadLine());
                    Validation.ArrivalDateValidation(container.DepatureDate, container.ArrivalDate);

                    Console.Write("Input Items Count: ");
                    container.ItemsCount = int.Parse(Console.ReadLine());

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "\nTry again. . .\n");
                    continue;
                }
                break;
            }
            return container;
        }
        private void AddContainersToFile()
        {
            using (StreamWriter sw = new StreamWriter(FilePath))
            {
                for (int i = 0; i < Сontainers.Count; i++)
                {
                    var Fields = ContainersFieldToArray(Сontainers[i]);
                    for (int j = 0; j < Fields.Length; j++)
                    {
                        sw.WriteLine(Fields[j]);
                    }
                }
            }
        }
        #endregion


    }
}
