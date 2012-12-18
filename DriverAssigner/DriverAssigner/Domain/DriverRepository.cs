using DriverAssigner.Models;

namespace DriverAssigner.Domain {
    public class DriverRepository {
        public DriverRepository() { }

        public Driver Get(string fullName) {
            return new Driver() { FirstName = "John", LastName = "Smith", LastAssignment = "Midland, TX" };
        }

        public void Save(Driver driver) {
            
        }

        public void Delete(Driver driver) {

        }

        private string GetKey(Driver driver) {
            return driver.FirstName + driver.LastName;
        }
    }
}