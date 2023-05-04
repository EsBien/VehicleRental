using Entities;
using System.Threading.Tasks;

namespace DL
{
    public interface ICustomer_DL
    {
         Task<CustomerTbl> getUser(string password, string email);
        Task<CustomerTbl> postUser(CustomerTbl user);
        Task putUser(string Email, CustomerTbl userToUpdate);
    }
}