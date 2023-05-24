﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBookListEntityFrameforkDAL.Entities;

namespace MyBookListEntityFrameworkDAL.EntityConfiguration
{
    public class EventDiscountsConfig : IEntityTypeConfiguration<EventDiscounts>
    {
        public void Configure(EntityTypeBuilder<EventDiscounts> builder)
        {
            builder
            .HasKey(ed => ed.IDDiscount);

            
        }
    }
}