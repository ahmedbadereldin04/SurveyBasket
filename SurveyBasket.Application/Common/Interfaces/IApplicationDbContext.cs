namespace SurveyBasket.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Poll> Polls { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<VoteAnswer> VoteAnswers { get; set; }
    public DbSet<Vote> Votes { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
