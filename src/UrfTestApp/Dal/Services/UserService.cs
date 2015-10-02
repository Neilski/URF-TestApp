using Repository.Pattern.Repositories;
using Service.Pattern;
using UrfTestApp.Models;


namespace UrfTestApp.Dal.Services
{
    public class UserService : Service<User>
    {
        private readonly IRepositoryAsync<User> _repository;


        public UserService(
            IRepositoryAsync<User> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}