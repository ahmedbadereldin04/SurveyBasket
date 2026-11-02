namespace SurveyBasket.Application.Contracts.Votes;

public record VoteRequest(
    IEnumerable<VoteAnswerRequest> Answers
);

