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
    internal class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IdEvent).IsRequired();
            builder.Property(x => x.IdParticipant).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.Comment).IsRequired();

            builder.HasOne(x => x.Event).WithMany(x => x.feedbacks)
                .HasForeignKey(x => x.IdEvent)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.participant).WithMany(x => x.feedbacks)
                .HasForeignKey(x => x.IdParticipant)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
