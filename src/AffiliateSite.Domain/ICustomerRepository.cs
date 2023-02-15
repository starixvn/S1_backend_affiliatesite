
namespace AffiliateSite.Domain
{
    public interface ICustomerRepository
    {
        Task<Customer> Load(string playerUserName);
    }
}