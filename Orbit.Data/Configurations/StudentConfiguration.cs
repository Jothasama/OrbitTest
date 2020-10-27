using Orbit.Data.Configurations.Core;
using Orbit.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Orbit.Data.Configurations
{
    public class StudentConfiguration : BaseEntityMap<Student>
    {
        public StudentConfiguration(string TableName, string IdName) : base(TableName, IdName)
        {
        }

        protected override void InternalMap(EntityTypeBuilder<Student> builder)
        {
            builder
                .Property(x => x.Username)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(20);

            builder
                .Property(x => x.FirstName)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(20);

            builder
                .Property(x => x.LastName)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(20);

            builder
                .Property(x => x.Age)
                .HasDefaultValueSql("0")
                .IsRequired();

            builder
                .Property(x => x.Career)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(40);
        }
    }
}