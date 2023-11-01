using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorSozluk.Api.Domain.Models;
using BlazorSozluk.Api.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorSozluk.Api.Infrastructure.Persistence.EntityConfigurations.Entry
{
    public class EntryFavoriteEntityConfiguration:BaseEntityConfiguration<EntryFavorite>
    {
        public override void Configure(EntityTypeBuilder<EntryFavorite> builder)
        {
            base.Configure(builder);

            builder.ToTable("entryfavorite", BlazorSozlukContext.DEFAULT_SCHEMA);

            builder.HasOne(i => i.Entry)
                .WithMany(i => i.EntryFavorites)
                .HasForeignKey(i => i.EntryId);


            builder.HasOne(i => i.CreatedUser)
                .WithMany(i => i.EntryFavorites)
                .HasForeignKey(i => i.CreatedById);
        }
    }
}
