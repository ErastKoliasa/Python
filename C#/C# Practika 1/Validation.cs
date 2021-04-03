using System;
using System.Collections.Generic;
using System.Text;

namespace Task
{
    static class Validation
    {
        public static void DepartureDateValidation(DateTime DepartureDate)
        {
            if (DepartureDate > DateTime.Now) throw new Exception("Incorrect date");
        }
        public static void ArrivalDateValidation(DateTime DepartureDate, DateTime ArrivalDate)
        {
            if (DepartureDate > ArrivalDate) throw new Exception("Incorrect date");
        }
        internal static void IdValidation(string id, string[] allId)
        {
            for (int i = 0; i < allId.Length; i++)
            {
                if (id == allId[i]) throw new Exception("Incorrect id, it has been used already");
            }
        }
    }
}
