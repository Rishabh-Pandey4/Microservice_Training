using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PassengerService.Models
{
    public class PassengerManager
    { public static List<PassengerModel> PassengerList;

        public PassengerManager()
        {
            PassengerList = new List<PassengerModel>()
            {
                new PassengerModel() { PassengerId=1, PassengerName="Ishan", PassengerContactNumber="9999988888",PassengerAddress="abc"},
                new PassengerModel() { PassengerId = 2, PassengerName = "Jim", PassengerContactNumber = "7777788888", PassengerAddress = "efg" },
                new PassengerModel() { PassengerId = 3, PassengerName = "Joe", PassengerContactNumber = "5555588888", PassengerAddress = "hij" }
            };
        } 

        public List<PassengerModel> GetAllPassenger()
        {
            return PassengerList;
        }
        public PassengerModel GetPassengerById(int id)
        {
            return PassengerList.Find(item => item.PassengerId == id);
        }
        public void AddPassenger(PassengerModel obj)
        {
            PassengerList.Add(obj);
        }
        public bool DeletePassenger(int id)
        {
            PassengerModel obj = PassengerList.Find(item => item.PassengerId == id);
            if (obj == null)
                return false;

            PassengerList.Remove(obj);
            return true;
        }
        public bool UpdatePassenger(PassengerModel updateObj)
        {
            foreach(var item in PassengerList)
            {
                if (item.PassengerId == updateObj.PassengerId)
                {
                    item.PassengerName = updateObj.PassengerName;
                    item.PassengerContactNumber = updateObj.PassengerContactNumber;
                    item.PassengerAddress = updateObj.PassengerAddress;
                    return true;
                }
            }
            return false;
        }
    }
}
