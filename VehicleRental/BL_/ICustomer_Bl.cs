using Entities;
using System.Threading.Tasks;
namespace BL_
{
    public interface ICustomer_Bl
    {
        Task<CustomerTbl> getUser(string pasword, string email);
        Task<CustomerTbl> postUser(CustomerTbl user);
        Task putUser(string email, CustomerTbl userToUpdate);
    }
}