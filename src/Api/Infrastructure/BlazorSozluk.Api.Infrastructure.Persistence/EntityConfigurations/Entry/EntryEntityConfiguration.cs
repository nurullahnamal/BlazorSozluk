

using BlazorSozluk.Api.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorSozluk.Api.Infrastructure.Persistence.EntityConfigurations.Entry
{
    public class EntryEntityConfiguration:BaseEntityConfiguration<Domain.Models.Entry>
    {
        public override void Configure(EntityTypeBuilder<Domain.Models.Entry> builder)
        {
            base.Configure(builder);
            builder.ToTable("entry", BlazorSozlukContext.DEFAULT_SCHEMA);


            builder.HasOne(i => i.CreatedBy)
                .WithMany(i => i.Entries)
                .HasForeignKey(i => i.CreatedById);
        }

    }
}
