using System.Data.Entity.ModelConfiguration;
using UrfTestApp.Models;


namespace UrfTestApp.Dal.Configurations
{
    public class UserDetailsMap
        : EntityTypeConfiguration<UserDetails>
    {
        public UserDetailsMap()
        {
            ToTable("UsersDetails");

            // Primary Key
            HasKey(u => u.UserId);

            // Properties
            Property(u => u.UserId)
                .IsRequired()
                .HasColumnName("UserId");

            Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Name");

            Property(u => u.Age)
                .IsRequired()
                .HasColumnName("Age");
        }
    }
}