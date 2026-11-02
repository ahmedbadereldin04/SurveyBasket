namespace SurveyBasket.Application.Contracts.Votes;

public record VoteAnswerRequest(
    int QuestionId,
    int AnswerId
);
