using System;
using System.Collections.Generic;
using System.Text;

namespace Task
{
    class Сontainer
    {
        private int _Id;
        private string _Number;
        private DepartureCitys _DepartureCitys;
        private ArrivalCitys _ArrivalCitys;
        private DateTime _DepatureDate;
        private DateTime _ArrivalDate;
        private int _ItemsCount;

        #region Propeties
        public int Id
        {
            get => _Id;
            set 
            {
                if (value < 0) throw new Exception("Incorrect Id");
                _Id = value;
            }
        }
        public string Number
        {
            get => _Number;
            set => _Number = value;
        }
       
        public DepartureCitys DepartureCitys
        {
            get => _DepartureCitys;
            set => _DepartureCitys = value;
        }
        public ArrivalCitys ArrivalCitys
        {
            get => _ArrivalCitys;
            set => _ArrivalCitys = value;
        }
        public DateTime DepatureDate
        {
            get => _DepatureDate;
            set => _DepatureDate = value;
        }
        public DateTime ArrivalDate
        {
            get => _ArrivalDate;
            set => _ArrivalDate = value;
        }
        public int ItemsCount
        {
            get => _ItemsCount;
            set
            {
                if (value < 0 || value > 10000) throw new Exception("Incorrect items count");
                _ItemsCount = value;
            }
        }
        #endregion

        public Сontainer()
        {

        }
        public Сontainer(Сontainer container)
        {
            this.Id = container.Id;
            this.Number = container.Number;
            this.DepartureCitys = container.DepartureCitys;
            this.ArrivalCitys = container.ArrivalCitys;
            this.DepatureDate = container.DepatureDate;
            this.ArrivalDate = container.ArrivalDate;
            this.ItemsCount = container.ItemsCount;
        }
        public override string ToString()
        {
            return
            $"Container Id - {Id}" +
            $"\nContainer Number - {Number}" +
            $"\nContainer Departure citys - {DepartureCitys}" +
            $"\nContainer Arrival citys - {ArrivalCitys}" +
            $"\nContainer Depature Date - {DepatureDate}" +
            $"\nContainer Arrival Date - {ArrivalDate}" +
            $"\nContainer Items count - {ItemsCount}\n";
        }
    }
}
