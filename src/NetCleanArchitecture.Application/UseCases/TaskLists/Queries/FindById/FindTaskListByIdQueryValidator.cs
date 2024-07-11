using FluentValidation;

namespace NetCleanArchitecture.Application;

public class FindTaskListByIdQueryValidator : AbstractValidator<FindTaskListByIdQuery>
{
    public FindTaskListByIdQueryValidator()
    {
        RuleFor(query => query.TaskListId)
            .NotEmpty();
    }
}
