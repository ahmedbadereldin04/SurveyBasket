namespace SurveyBasket.Api.Controllers;

[Route("api/polls/{pollId}/[controller]")]
[ApiController]
[Authorize]
public class QuestionsController(IQuestionService questionService) : ControllerBase
{
    private readonly IQuestionService _questionService = questionService;

    [HttpGet("")]
    [HasPermission(Permissions.GetQuestions)]
    public async Task<IActionResult> GetAll([FromRoute] int pollId,CancellationToken cancellationToken = default)
    {
        var result = await _questionService.GetAllAsync(pollId, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }


    [HttpGet("{id}",Name ="GetQuestion")]
    [HasPermission(Permissions.GetQuestions)]
    public async Task<IActionResult> GetAsync([FromRoute] int pollId,[FromRoute] int id, CancellationToken cancellationToken = default)
    {
        var result = await _questionService.GetAsync(pollId, id, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }


    [HttpPost("")]
    [HasPermission(Permissions.AddQuestions)]
    public async Task<IActionResult> Add([FromRoute] int pollId, [FromBody] QuestionRequest request, CancellationToken cancellationToken = default)
    {
        var result = await _questionService.AddAsync(pollId, request, cancellationToken);

        return result.IsSuccess
            ? CreatedAtRoute("GetQuestion", new { pollId, result.Value.Id },result.Value)
            : result.ToProblem();
    }

    [HttpPut("{id}")]
    [HasPermission(Permissions.UpdateQuestions)]
    public async Task<IActionResult> Update([FromRoute] int pollId, [FromRoute] int id, [FromBody] QuestionRequest request, CancellationToken cancellationToken = default)
    {
        var result = await _questionService.UpdateAsync(pollId,id, request, cancellationToken);

        return result.IsSuccess ? NoContent() : result.ToProblem();
    }

    [HttpPut("{id}/toggleStatus")]
    [HasPermission(Permissions.UpdateQuestions)]
    public async Task<IActionResult> ToggleStatus([FromRoute] int pollId,[FromRoute] int id, CancellationToken cancellationToken)
    {
        var result = await _questionService.ToggleStatusAsync(pollId, id, cancellationToken);

        return result.IsSuccess ? NoContent() : result.ToProblem();
    }

}
