namespace SurveyBasket.Application.Contracts.Results;

public record VotesPerAnswerResponse(
    string Answer,
    int VotesCount
);
