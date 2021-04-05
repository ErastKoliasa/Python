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
                "\n3.Delete object" +
                "\n4.Add object" +
                "\n5.Edit object" +
                "\n6.Output objects" +
                "\n7.Exit\n");
        }
   
        public static void MenueHint()
        {
            Console.WriteLine("Press '+' to Show menue");
        }
    }
}
