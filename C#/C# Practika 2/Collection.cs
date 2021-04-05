using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Linq;
using Task.Resource;
using System.ComponentModel;

namespace Task
{
    class Collection<T>
    {
        #region Public Date
        public List<T> Containers { get; set; } = new List<T>();
        #endregion

        #region Privte Date
        private const string FilePath = "StartInfo.txt";
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
                        var container = ReadFromFile<T>(sr);

                        CheckTheIdValidation(container);

                        Containers.Add((T)container);

                        Console.WriteLine($"Objects {containersCount} has been added!");

                        containersCount++;
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("Null object cannot be converted to a value type")) break;

                        Console.WriteLine(ex.Message + "\nObject not added");
                    }
                }
            }
        }


        public void EditContainer()
        {
            Console.Write("Input container Id to change it: ");
            int Index = SearchIndexOfContainerById();

            Containers[Index] = CreateNewContainer<T>();

            AddContainersToFile();

            Console.WriteLine("\nContainer has been edit!\n");

        }
        public void AddContainer()
        {
            var container = (T)typeof(T).GetConstructor(new Type[0]).Invoke(new object[0]);
            container = CreateNewContainer<T>();

            Containers.Add(container);

            Console.WriteLine("\nObject has been added!\n");

            AddContainersToFile();
        }
        public void DeleateContainer()
        {
            Console.Write("Input Objects Id to deleate it: ");
            int Index = SearchIndexOfContainerById();

            Containers.Remove(Containers[Index]);

            AddContainersToFile();

            Console.WriteLine("\nObject has been deleated!\n");

        }
        public void OutputContairnsInformation()
        {
            foreach (var x in Containers)
                Console.WriteLine(x.ToString());
        }
        public void SortData()
        {
            ContainerFields();

            Console.Write("Select the field by which collection will be sorted: ");

            int Operation = SearchIndexes.SearchOpeationNumber();

            Containers.Sort((x, y) => TypeDescriptor.GetProperties(x)[Operation - 1]
            .GetValue(x).ToString()
            .CompareTo(TypeDescriptor.GetProperties(y)[Operation - 1]
            .GetValue(y).ToString()));

            Console.WriteLine("\nObjects has been sorted\n");
        }
        public void SearchAllSimilarity()
        {
            Console.WriteLine("\nEnter some words to find information: ");
            string keyWord = Console.ReadLine();

            for (int i = 0; i < Containers.Count; i++)
            {
                string[] containerFields = ContainersFieldToArray(Containers[i]);

                for (int j = 0; j < containerFields.Length; j++)
                {
                    if (containerFields[j].Contains(keyWord, StringComparison.CurrentCultureIgnoreCase))
                    {
                        var containersType = Containers[i].GetType();
                        var Id = containersType.GetProperties()[0].GetValue(Containers[i]);

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write($"{containerFields[j]} ");
                        Console.ResetColor();
                        Console.WriteLine($"is in {containersType.Name} with '{Id}' Id");
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

        #region Private Methods
        private void ContainerFields()
        {
            var @class = (T)typeof(T).GetConstructor(new Type[0]).Invoke(new object[0]);
            var containersType = @class.GetType();
            var containersFields = containersType.GetProperties();
            for (int i = 0; i < containersFields.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {containersFields[i].Name}");
            }
        }

        private void CheckTheIdValidation(object container)
        {

            var properties = TypeDescriptor.GetProperties(container);

            var allId = new string[Containers.Count];

            allId = Enumerable
                .Range(0, allId.Length)
                .Select(x => allId[x] = (properties[0].GetValue(Containers[x])).ToString())
                .ToArray();
            Validation.IdValidation((properties[0].GetValue(container)).ToString(), allId);
        }
        private object ReadFromFile<T>(StreamReader sr)
        {

            T container = (T)typeof(T).GetConstructor(new Type[0]).Invoke(new object[0]);
            var properties = TypeDescriptor.GetProperties(container);
            var containersType = container.GetType();
            var containersFields = containersType.GetProperties();
            object[] data = new object[properties.Count];

            for (int i = 0; i < properties.Count; i++)
                data[i] = sr.ReadLine();


            for (int i = 0; i < properties.Count; i++)
            {
                var property = properties[i];

                if (containersFields[i].PropertyType.BaseType == typeof(Enum))
                    data[i] = Enum.Parse(containersFields[i].PropertyType, data[i].ToString());

                property.SetValue(container, Convert.ChangeType(data[i], property.PropertyType));
            }



            return container;
        }
        private string[] ContainersFieldToArray(T Сontainers)
        {
            var FieldsArray = (from x in typeof(T)
                        .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                               select x.GetValue(Сontainers, null).ToString()).ToArray();

            return FieldsArray;
        }
        private int SearchIndexOfContainerById()
        {
            int Id = 0; ;
            while (true)
            {
                string number = Console.ReadLine();
                bool isValidNumber = int.TryParse(number, out Id);
                if (isValidNumber is false)
                {
                    Console.WriteLine("Please input number");
                    continue;
                }
                for (int i = 0; i < Containers.Count; i++)
                {
                    var properties = TypeDescriptor.GetProperties(Containers[i]);
                    string _id = properties[0].GetValue(Containers[i]).ToString();
                    if (_id == Id.ToString())
                    {
                        return i;
                    }
                }
                Console.WriteLine("Id is incorrect");
                continue;
            }
        }
        private T CreateNewContainer<T>()
        {
            var container = (T)typeof(T).GetConstructor(new Type[0]).Invoke(new object[0]);
            var properties = TypeDescriptor.GetProperties(container);
            var containersType = container.GetType();
            var containersFields = containersType.GetProperties();
            object data;

            while (true)
            {
                try
                {
                    for (int i = 0; i < properties.Count; i++)
                    {
                        var property = properties[i];

                        Console.Write($"Enter {containersType.Name} {containersFields[i].Name}: ");

                        data = Console.ReadLine();

                        if (containersFields[i].PropertyType.BaseType == typeof(Enum))
                            data = Enum.Parse(containersFields[i].PropertyType, data.ToString());

                        property.SetValue(container, Convert.ChangeType(data, property.PropertyType));


                        if (i is 0) CheckTheIdValidation(container);
                    }
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
                for (int i = 0; i < Containers.Count; i++)
                {
                    var Fields = ContainersFieldToArray(Containers[i]);
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
