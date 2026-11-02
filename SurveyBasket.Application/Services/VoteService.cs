using SurveyBasket.Application.Contracts.Votes;

namespace SurveyBasket.Application.Services;

public class VoteService(IApplicationDbContext context) : IVoteService
{
    private readonly IApplicationDbContext _context = context;

    public async Task<Result> AddAsync(int pollId, string userId, VoteRequest request, CancellationToken cancellationToken = default)
    {
        bool hasVoted = await _context.Votes.AnyAsync(x => x.PollId == pollId && x.UserId == userId, cancellationToken: cancellationToken);

        if (hasVoted)
            return Result.Failure(VoteErrors.DuplicatedVote);

        var pollIsExists = await _context.Polls.AnyAsync(x => x.Id == pollId
            && x.IsPublished && x.StartsAt <= DateOnly.FromDateTime(DateTime.Now)
            && x.EndsAt >= DateOnly.FromDateTime(DateTime.Now)
            , cancellationToken: cancellationToken);

        if (!pollIsExists)
            return Result.Failure(PollErrors.PollNotFound);

        var avialableQuestions = await _context.Questions
            .Where(x => x.PollId == pollId && x.IsActive)
            .Select(q => q.Id)
            .ToListAsync(cancellationToken);
        if (!request.Answers.Select(x => x.QuestionId).SequenceEqual(avialableQuestions))
            return Result.Failure(VoteErrors.InvalidQuestions);
        var vote = new Vote
        {
            PollId = pollId,
            UserId = userId,
            VoteAnswers = request.Answers.Adapt<IEnumerable<VoteAnswer>>().ToList()

        };
        await _context.Votes.AddAsync(vote, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();


    }
}
