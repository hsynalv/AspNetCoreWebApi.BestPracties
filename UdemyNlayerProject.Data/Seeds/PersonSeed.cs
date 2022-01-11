using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UdemyNLayerProject.Core.Models;

namespace UdemyNlayerProject.Data.Seeds
{
    public class PersonSeed : IEntityTypeConfiguration<Person>
    {
        private readonly int[] _ids;
        public PersonSeed(int[] ids)
        {
            _ids = ids;
        }
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasData(
                new Person { Id = _ids[0], Name = "Hüseyin", SurName="Alav" },
                new Person { Id = _ids[1], Name = "Sedat", SurName = "Kavak" }
                );
        }
    }
}
