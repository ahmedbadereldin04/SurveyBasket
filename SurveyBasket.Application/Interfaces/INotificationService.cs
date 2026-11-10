namespace SurveyBasket.Application.Interfaces;

public interface INotificationService
{
    Task SendNewPollsNotification(int? pollId = null);
}
