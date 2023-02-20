namespace AffiliateSite.Users.Domain
{
    public interface ICustomerRepository
    {
        Task<Customer> Load(string playerUserName);
    }
}