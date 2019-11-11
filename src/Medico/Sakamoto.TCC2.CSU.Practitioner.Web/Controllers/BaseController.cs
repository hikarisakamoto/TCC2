using System.Linq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sakamoto.TCC2.CSU.Domain.Core.Bus;
using Sakamoto.TCC2.CSU.Domain.Core.Notifications;

namespace Sakamoto.TCC2.CSU.Practitioner.Web.Controllers
{
    [Produces("application/json")]
    public abstract class BaseController : Controller
    {
        private readonly IMediatorHandler _mediator;
        private readonly DomainNotificationHandler _notifications;

        protected BaseController(INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator)
        {
            _notifications = (DomainNotificationHandler) notifications;
            _mediator = mediator;
        }

        protected bool InvalidOperation()
        {
            return !_notifications.HasNotifications();
        }

        protected void NotifyError(string code, string message)
        {
            _mediator.RaiseEvent(new DomainNotification(code, message));
        }

        protected void NotifyModelStateErrors()
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                var errorMessage = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                NotifyError(string.Empty, errorMessage);
            }
        }

        protected IActionResult Response(object result = null)
        {
            if (InvalidOperation())
                return Ok(result);

            return BadRequest(new
            {
                success = false,
                errors = _notifications.GetNotifications().Select(n => n.Value)
            });
        }
    }
}