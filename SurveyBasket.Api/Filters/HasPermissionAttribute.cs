namespace SurveyBasket.Api.Filters;

public class HasPermissionAttribute(string permission) : AuthorizeAttribute(permission)
{

}
