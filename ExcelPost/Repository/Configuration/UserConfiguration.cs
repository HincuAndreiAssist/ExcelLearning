using ExcelPost.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcelPost.Repository.Configuration
{
    public class studentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");

            builder.HasQueryFilter(student => !student.IsDeleted);

            builder.HasKey(student => student.Id)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            builder.Property(studentProfile => studentProfile.Name);

            builder.Property(student => student.Surname);

            builder.Property(student => student.Age);

            builder.Property(student => student.City);

            builder.Property(student => student.Age);

            builder.Property(student => student.City);

            builder.Property(student => student.IsDeleted)
               .HasDefaultValue(false);
        }
    }
}
