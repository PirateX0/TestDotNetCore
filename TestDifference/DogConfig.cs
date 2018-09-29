using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestDifference
{
    public class DogConfig : IEntityTypeConfiguration<Dog>
    {
        public void Configure(EntityTypeBuilder<Dog> builder)
        {
            builder.ToTable("T_Dogs");
            builder.HasOne(e => e.Person).WithMany().HasForeignKey(e => e.PersonId);
        }
    }
}
