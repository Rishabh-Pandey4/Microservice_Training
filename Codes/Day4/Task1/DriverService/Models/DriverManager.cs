using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriverService.Models
{
    public class DriverManager
    {
        public static List<DriverModel> DriverList;

        public DriverManager()
        {
            DriverList = new List<DriverModel>()
            {
                new DriverModel() { DriverId=1, DriverName="Parth Khandelwal", DriverContactNumber="9999988888",DrivingLicenseNumber="123456"},
                new DriverModel() { DriverId = 2, DriverName = "Sam", DriverContactNumber = "7777788888", DrivingLicenseNumber = "234561" },
                new DriverModel() { DriverId = 3, DriverName = "Tom", DriverContactNumber = "5555588888", DrivingLicenseNumber = "345612" }
            };
        }

        public List<DriverModel> GetAllDrivers()
        {
            return DriverList;
        }
        public DriverModel GetDriverById(int id)
        {
            return DriverList.Find(item => item.DriverId == id);
        }
        public void AddDriver(DriverModel obj)
        {

            DriverList.Add(obj);
        }
        public bool DeleteDriver(int id)
        {
            DriverModel obj = DriverList.Find(item => item.DriverId == id);
            if (obj == null)
                return false;

            DriverList.Remove(obj);
            return true;
        }
        public bool UpdateDriver(DriverModel updateObj)
        {
            foreach (var item in DriverList)
            {
                if (item.DriverId == updateObj.DriverId)
                {
                    item.DriverName = updateObj.DriverName;
                    item.DriverContactNumber = updateObj.DriverContactNumber;
                    item.DrivingLicenseNumber = updateObj.DrivingLicenseNumber;
                    return true;
                }
            }
            return false;
        }
    }
}
