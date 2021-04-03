using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task
{
    class FileReader
    {
        internal static Сontainer ReadFromFile(StreamReader sr)
        {
            var container = new Сontainer();

            string _Id = sr.ReadLine();
            string _Number = sr.ReadLine();
            string _DepartureCitys = sr.ReadLine();
            string _ArrivalCitys = sr.ReadLine();
            string _DepatureDate = sr.ReadLine();
            string _ArrivalDate = sr.ReadLine();
            string _ItemsCount = sr.ReadLine();

            container.Id = int.Parse(_Id);
            container.Number = _Number;
            container.DepartureCitys = (DepartureCitys)Enum.Parse(typeof(DepartureCitys), _DepartureCitys);
            container.ArrivalCitys = (ArrivalCitys)Enum.Parse(typeof(ArrivalCitys), _ArrivalCitys);
            container.DepatureDate = DateTime.Parse(_DepatureDate);
            container.ArrivalDate = DateTime.Parse(_ArrivalDate);
            container.ItemsCount = int.Parse(_ItemsCount);

            Validation.DepartureDateValidation(container.DepatureDate);
            Validation.ArrivalDateValidation(container.DepatureDate, container.ArrivalDate);

            return container;
        }
    }
}
