using System.Data.Entity;
using Repository.Pattern.Ef6;
using UrfTestApp.Dal.Configurations;
using UrfTestApp.Models;


namespace UrfTestApp.Dal
{
    public class AppDataContext : DataContext
    {
        public DbSet<User> Users { get; set; }


        static AppDataContext()
        {
            Database.SetInitializer<AppDataContext>(
                new CreateDatabaseIfNotExists<AppDataContext>());
        }


        public AppDataContext()
            : base("Name=DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }


        public static AppDataContext Create()
        {
            return new AppDataContext();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new UserDetailsMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}