using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SurveyBasket.Application.Contracts.Polls;
using SurveyBasket.Application.Interfaces;
using SurveyBasket.Domain.Entities;

namespace SurveyBasket.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PollsController(IPollService pollService) : ControllerBase
{
    private readonly IPollService _pollService = pollService;

    [HttpGet("")]

    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var polls = await _pollService.GetAllAsync(cancellationToken);

        var response = polls.Adapt<IEnumerable<PollResponse>>();

        return Ok(response);
    }

    [HttpGet("{id}" ,Name = "GetById")]
    public async Task<IActionResult> GetAsync([FromRoute] int id, CancellationToken cancellationToken)
    {
        var poll = await _pollService.GetAsync(id, cancellationToken);

        if (poll is null)
            return NotFound();

        var reseponse = poll.Adapt<PollResponse>();

        return Ok(reseponse);
    }

    [HttpPost("")]
    public async Task<IActionResult> AddAsync([FromBody] PollRequest request
        ,CancellationToken cancellationToken)
    {

        var newPoll = await _pollService.AddAsync(request.Adapt<Poll>(), cancellationToken);

        return CreatedAtRoute("GetById", new { id = newPoll.Id }, newPoll.Adapt<PollResponse>());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] PollRequest request, CancellationToken cancellationToken)
    {
        var isUpdated = await _pollService.UpdateAsync(id, request.Adapt<Poll>(), cancellationToken);

        if (!isUpdated)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var isDeleted = await _pollService.DeleteAsync(id, cancellationToken);

        if (!isDeleted)
            return NotFound();

        return NoContent();
    }
    [HttpPut("{id}/togglePublish")]
    public async Task<IActionResult> TogglePublish(int id, CancellationToken cancellationToken)
    {
        var isToggled = await _pollService.TogglePublishStatusAsync(id, cancellationToken);

        if (!isToggled)
            return NotFound();

        return NoContent();
    }
}