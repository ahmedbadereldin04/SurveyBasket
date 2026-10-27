namespace SurveyBasket.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<Poll> Polls { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
