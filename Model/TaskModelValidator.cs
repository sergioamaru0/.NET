using FluentValidation;
using TaskManager.Model;

public class TaskModelValidator : AbstractValidator<TaskModel>
{
    public TaskModelValidator()
    {
        RuleFor(task => task.TaskName)
            .NotEmpty().WithMessage("El nombre de la tarea es obligatorio.")
            .Matches(@"^\S.*").WithMessage("El nombre de la tarea no puede ser solo espacios en blanco.");
    }
}
