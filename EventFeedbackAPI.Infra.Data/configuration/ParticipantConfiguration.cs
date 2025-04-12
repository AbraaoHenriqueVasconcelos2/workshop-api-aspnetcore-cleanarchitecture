using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventFeedbackAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventFeedbackAPI.Infra.Data.configuration
{
    internal class ParticipantConfiguration : IEntityTypeConfiguration<Participant>
    {
        public void Configure(EntityTypeBuilder<Participant> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Cpf).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(100);
            builder.Property(x => x.City).HasMaxLength(100);
            builder.Property(x => x.Neighborhood).HasMaxLength(100);

        }
    }
}
