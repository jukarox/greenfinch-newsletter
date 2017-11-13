using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Greenfinch.Validators
{
    public abstract class AbstractModelStateValidator
    {
        protected readonly ModelStateDictionary ModelState;

        protected AbstractModelStateValidator(ModelStateDictionary modelState)
        {
            ModelState = modelState;
        }

        public abstract void Validate();

        protected void AddError(string message)
        {
            ModelState.AddModelError(string.Empty, message);
        }
    }
}