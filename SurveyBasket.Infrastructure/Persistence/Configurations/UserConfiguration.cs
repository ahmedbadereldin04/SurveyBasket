namespace SurveyBasket.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
       
        builder.Property(p => p.FirstName).HasMaxLength(100);
        builder.Property(p => p.LastName).HasMaxLength(100);


        builder.OwnsMany(p => p.RefreshTokens)
            .ToTable("RefreshTokens")
            .WithOwner()
            .HasForeignKey("UserId");
    }
}
