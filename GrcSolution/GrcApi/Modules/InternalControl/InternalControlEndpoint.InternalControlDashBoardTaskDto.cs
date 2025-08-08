using Arm.GrcApi.Modules.InternalControl;
using Arm.GrcApi.Modules.Shared;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;

namespace GrcApi.Modules.InternalControl
{
    public record CreateTaskDto(List<InternalControlDashBoardTaskDto> CreateTask);

    public class CreateTaskDtoValidator : AbstractValidator<CreateTaskDto>
    {
        public CreateTaskDtoValidator()
        {
            RuleFor(x => x.CreateTask).NotEmpty();
            RuleForEach(x => x.CreateTask).SetValidator(new InternalControlDashBoardTaskDtoValidator());
        }
    }

    public record InternalControlDashBoardTaskDto
    (
        string ActivityInterval,
        string Activity,
        string Comment,
        DateTime CompletionDate,
        string ActionOwner,
        string ActionOwnerEmail
    );

    public class InternalControlDashBoardTaskDtoValidator : AbstractValidator<InternalControlDashBoardTaskDto>
    {
        public InternalControlDashBoardTaskDtoValidator()
        {
            RuleFor(x => x.ActivityInterval).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.Activity).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.Comment).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.ActionOwner).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.ActionOwnerEmail).NotEmpty().EmailAddress();
            RuleFor(e => e.CompletionDate).NotEmpty().GreaterThanOrEqualTo(Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))).WithMessage("Completion date cannot be earlier than today's date");
        }
    }

    public record CreateTask(
        InternalControlDashboardActivityInterval ActivityInterval,
        string Activity,
        string Comment,
        DateTime CompletionDate,
        string ActionOwner,
        string ActionOwnerEmail,
        DateTime? NotificationDate
    );

    public class TaskReportParameter
    {
        const int maxPageSize = 100;
        private int _pageSize = 50;
        public int PageNumber { get; set; } = 1;
        public int PageSize { 
            get => _pageSize; 
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value; 
        }
    }

    public class TaskReportParameterDto : TaskReportParameter
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string? Status { get; set; }
    }
}
