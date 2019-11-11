using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sakamoto.TCC2.CSU.Domain.Core.Bus;
using Sakamoto.TCC2.CSU.Domain.Core.Notifications;
using Sakamoto.TCC2.CSU.Practitioner.Application.Interfaces;
using Sakamoto.TCC2.CSU.Practitioner.Application.ViewModels;

namespace Sakamoto.TCC2.CSU.Practitioner.Web.Controllers
{
    public class PractitionerController : BaseController
    {
        private readonly IPractitionerAppService _practitionerAppService;

        public PractitionerController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator,
            IPractitionerAppService practitionerAppService) : base(notifications, mediator)
        {
            _practitionerAppService = practitionerAppService;
        }

        [HttpDelete]
        [Route("practitioner-management-deactivate")]
        public async Task<IActionResult> DeactivatePractitioner(
            [FromBody] DeactivatePractitionerViewModel practitionerViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(practitionerViewModel);
            }

            _practitionerAppService.Deactivate(practitionerViewModel);

            return Response(practitionerViewModel);
        }

        [HttpGet]
        [Route("practitioners")]
        public async Task<IActionResult> GetAllPractitioners()
        {
            var practitionerViewModel = await _practitionerAppService.GetAllPractitioners();
            return Response(practitionerViewModel);
        }

        [HttpGet]
        [Route("practitioner-information/{crm:maxlength(30)}")]
        public async Task<IActionResult> GetPractitionerInformationByCrm(string crm)
        {
            if (string.IsNullOrWhiteSpace(crm))
                return NotFound();

            var practitionerViewModel =await  _practitionerAppService.GetByCrm(crm);
            return Response(practitionerViewModel);
        }

        [HttpGet]
        [Route("practitioner-information/{id:guid}")]
        public async Task<IActionResult> GetPractitionerInformationById(Guid? id)
        {
            if (id == null)
                return NotFound();

            var practitionerViewModel =await _practitionerAppService.GetById(id.Value);
            return Response(practitionerViewModel);
        }

        [HttpPost]
        [Route("practitioner-register")]
        public async Task<IActionResult> RegisterNewPractitoner(
            [FromBody] RegisterNewPractitionerViewModel practitionerViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(practitionerViewModel);
            }

            _practitionerAppService.Register(practitionerViewModel);
            return Response(practitionerViewModel);
        }

        [HttpPost]
        [Route("practitioner-management-update-email")]
        public async Task<IActionResult> UpdatePractitionerEmail(
            [FromBody] UpdatePractitionerEmailViewModel practitionerViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(practitionerViewModel);
            }

            _practitionerAppService.UpdateEmail(practitionerViewModel);
            return Response(practitionerViewModel);
        }

        [HttpPost]
        [Route("practitioner-management-update-phone")]
        public async Task<IActionResult> UpdatePractitionerPhone(
            [FromBody] UpdatePractitionerPhoneViewModel practitionerViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(practitionerViewModel);
            }

            _practitionerAppService.UpdatePhone(practitionerViewModel);
            return Response(practitionerViewModel);
        }
    }
}