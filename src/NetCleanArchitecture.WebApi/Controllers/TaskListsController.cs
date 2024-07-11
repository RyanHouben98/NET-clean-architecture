using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetCleanArchitecture.Application;

namespace NetCleanArchitecture.WebApi;

[Route("api/v1/[controller]")]
public class TaskListsController(ISender sender) : ApiController
{
    [HttpGet]
    public async Task<IActionResult> List()
    {
        var query = new ListTaskListsQuery();

        var result = await sender.Send(query);

        return result.Match(
            Ok,
            Problem);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> FindById([FromRoute] Guid id)
    {
        var query = new FindTaskListByIdQuery(id);

        var result = await sender.Send(query);

        return result.Match(
            Ok,
            Problem);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTaskListRequest request)
    {
        var command = new CreateTaskListCommand(request.Name);

        var result = await sender.Send(command);

        return result.Match(
            okResult => CreatedAtAction(nameof(FindById), new { id = okResult}, okResult),
            Problem
        );
    }
}
