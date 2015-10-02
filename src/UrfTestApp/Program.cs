using System;
using System.Threading.Tasks;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using UrfTestApp.Dal;
using UrfTestApp.Models;


namespace UrfTestApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write(
                "Press any other key ('a' for async version) to create new user:");
            var key = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (key == 'a')
            {
                Console.Write("Running CreateUserAsync()... ");
                Task.Run(async () =>
                {
                    var result = await CreateUserAsync();
                    Console.Write((result) ? "Success" : "\nFailed!");
                }).Wait();
            }
            else
            {
                Console.WriteLine("Running non-asynchronous CreateUser()...");
                var result = CreateUser();
                Console.Write((result) ? "Success" : "\nFailed!");
            }

            Console.WriteLine();
            Console.Write("Press any key to exit. ");
            Console.ReadKey();
        }


        private static bool CreateUser()
        {
            var user = BuildNewUser();

            using (IDataContextAsync ctx = new AppDataContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(ctx))
            {
                IRepositoryAsync<User> userRepository = new Repository<User>(ctx,
                    unitOfWork);

                userRepository.InsertOrUpdateGraph(user);
                try
                {
                    unitOfWork.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine();
                    Console.WriteLine(e);
                    return false;
                }

                return true;
            }
        }


        private static async Task<bool> CreateUserAsync()
        {
            var user = BuildNewUser();

            using (IDataContextAsync ctx = new AppDataContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(ctx))
            {
                IRepositoryAsync<User> userRepository = new Repository<User>(ctx,
                    unitOfWork);

                userRepository.InsertOrUpdateGraph(user);
                try
                {
                    await unitOfWork.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine();
                    Console.WriteLine(e);
                    return false;
                }
            }

            return true;
        }


        private static User BuildNewUser()
        {
            return new User
            {
                Email = "booha@somedomain",
                Details = new UserDetails
                {
                    Name = "Boo Ha",
                    Age = 99,
                    ObjectState = ObjectState.Added
                },
                ObjectState = ObjectState.Added
            };
        }
    }
}