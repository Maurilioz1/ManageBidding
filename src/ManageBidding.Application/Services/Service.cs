using FluentValidation;
using FluentValidation.Results;
using ManageBidding.Application.Interfaces.Services;
using ManageBidding.Core.DomainObjects.Models;

namespace ManageBidding.Application.Services
{
    public abstract class Service
    {
        private readonly INotificationService _notification;

        public Service(INotificationService notification)
        {
            _notification = notification;
        }

        protected void Notify(string message)
        {
            _notification.Handle(new Notification(message));
        }

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage);
            }
        }

        protected bool ExecuteValidation<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validation.Validate(entity);

            if (validator.IsValid)
            {
                return true;
            }

            Notify(validator);

            return false;
        }
    }
}
