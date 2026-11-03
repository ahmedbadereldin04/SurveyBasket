namespace SurveyBasket.Application.Common.Errors;

public static class VoteErrors
{
    public static readonly Error InvalidQuestions =
        new("Vote.InvalidQuestions", "Invalid questions", StatusCodes.Status400BadRequest);

    public static readonly Error DuplicatedVote =
        new("Vote.DuplicatedVote", "You have already voted for this poll", StatusCodes.Status409Conflict);
}