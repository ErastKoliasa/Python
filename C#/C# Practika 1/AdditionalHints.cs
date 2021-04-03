using System;
using System.Collections.Generic;
using System.Text;

namespace Task.Resource
{
    static class AdditionalHints
    {
        public static void Menue()
        {
            Console.WriteLine
                ("\nChose The Operation:" +
                "\n1.Show all similarity" +
                "\n2.Sort date" +
                "\n3.Delete container" +
                "\n4.Add container" +
                "\n5.Edit container" +
                "\n6.Output containers information" +
                "\n7.Exit\n");
        }
        public static void ContainerFields()
        {
            Console.WriteLine
                ($"1.{nameof(Сontainer.Id)}" +
                 $"\n2.{nameof(Сontainer.Number)}" +
                 $"\n3.{nameof(Сontainer.DepartureCitys)}" +
                 $"\n4.{nameof(Сontainer.ArrivalCitys)}" +
                 $"\n5.{nameof(Сontainer.DepatureDate)}" +
                 $"\n6.{nameof(Сontainer.ArrivalDate)}" +
                 $"\n7.{nameof(Сontainer.ItemsCount)}");
        }
        public static void MenueHint()
        {
            Console.WriteLine("Press '+' to Show menue");
        }
    }
}
