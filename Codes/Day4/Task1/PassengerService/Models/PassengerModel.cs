using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PassengerService.Models
{
    public class PassengerModel
    {
        public int PassengerId { get; set; }
        public string PassengerName { get; set; }
        public string PassengerContactNumber { get; set; }
        public string PassengerAddress { get; set; }
    }
}
