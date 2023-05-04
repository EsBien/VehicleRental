
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;

namespace DL
{
    public class Customer_DL : ICustomer_DL
    {
        VehicleRentals_dbContext _VehicleRental_dbContext;
        public Customer_DL(VehicleRentals_dbContext VehicleRental_dbContext)
        {
            _VehicleRental_dbContext = VehicleRental_dbContext;
        }

        //string path = "C:/Users/USER/Desktop/web-api/MyFirstWebProject/MyFirstWebProject/Users.txt";
        public async Task<CustomerTbl> getUser(string PasswordCust, string Email)
        {
            CustomerTbl customer = await _VehicleRental_dbContext.CustomerTbls.FindAsync(Email);

            if (customer != null && customer.PasswordCust == PasswordCust)
                return customer;
            return null;
        }

        public async Task putUser(string Email, CustomerTbl userToUpdate)
        {
            
           // Email = userToUpdate.Email;
            CustomerTbl c = await _VehicleRental_dbContext.CustomerTbls.FindAsync(Email);
            if (c != null)
            {
                 _VehicleRental_dbContext.Entry(c).CurrentValues.SetValues(userToUpdate);
                await _VehicleRental_dbContext.SaveChangesAsync();
            }
          
        }

        public async Task<CustomerTbl> postUser(CustomerTbl Customer)
        {

            await _VehicleRental_dbContext.CustomerTbls.AddAsync(Customer);
            await _VehicleRental_dbContext.SaveChangesAsync();
            return Customer;

        }
    }
}
