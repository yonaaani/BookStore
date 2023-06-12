using FluentValidation;
using MyBookListEntityFrameworkBLL.DTO;

public class EventsDTOValidator : AbstractValidator<EventsDTO>
{
    public EventsDTOValidator()
    {
        RuleFor(dto => dto.IDEvent).GreaterThan(0).WithMessage("IDEvent must be greater than 0");
        RuleFor(dto => dto.EventName).NotEmpty().WithMessage("EventName is required");
        RuleFor(dto => dto.EventDate).NotEmpty().WithMessage("EventDate is required");
        RuleFor(dto => dto.EventText).NotEmpty().WithMessage("EventText is required");
    }
}
