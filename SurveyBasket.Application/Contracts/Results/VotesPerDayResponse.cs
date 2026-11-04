using System.Collections.Specialized;

namespace SurveyBasket.Application.Contracts.Results;

public record VotesPerDayResponse(
    DateOnly Date,
    int VotesCount
);
