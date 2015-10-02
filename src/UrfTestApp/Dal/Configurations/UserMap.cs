using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using UrfTestApp.Models;


namespace UrfTestApp.Dal.Configurations
{
    public class UserMap
        : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("Users");

            // Primary Key
            HasKey(u => u.UserId);

            // Properties
            Property(u => u.UserId)
                .IsRequired()
                .HasColumnName("UserId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Email");

            HasRequired(s => s.Details)
                .WithRequiredPrincipal()
                .WillCascadeOnDelete();
        }
    }
}