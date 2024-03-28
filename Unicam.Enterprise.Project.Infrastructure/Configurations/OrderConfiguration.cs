using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unicam.Enterprise.Project.Model.Entities;

namespace Unicam.Enterprise.Project.Infrastructure.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");
        builder.HasKey(o => o.Id);
        builder.OwnsOne(o => o.DeliveryAddress);
        builder.HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId);
        builder.HasMany(o => o.Courses)
            .WithMany(c => c.Orders)
            .UsingEntity(j => j.ToTable("OrderCourses"));
    }
}