using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sakamoto.TCC2.CSU.Domain.Core.Bus;
using Sakamoto.TCC2.CSU.Domain.Core.Notifications;
using Sakamoto.TCC2.CSU.Patient.Application.Interfaces;
using Sakamoto.TCC2.CSU.Patient.Application.ViewModels;

namespace Sakamoto.TCC2.CSU.Patient.Web.Controller
{
    //[Route("api/[controller]")]
    [ApiController]
    public class PatientController : BaseController
    {
        private readonly IPatientAppService _patientAppService;

        public PatientController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator,
            IPatientAppService patientAppService) :
            base(notifications, mediator)
        {
            _patientAppService = patientAppService;
        }

        [HttpDelete]
        [Route("patient-management-deactivate")]
        public async Task<IActionResult> DeactivatePatient([FromBody] DeactivatePatientViewModel patientViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(patientViewModel);
            }

            _patientAppService.Deactivate(patientViewModel);

            return Response(patientViewModel);
        }


        [HttpGet]
        [Route("patient-basic-information/{cpf:maxlength(11)}")]
        public async Task<IActionResult> GetBasicPatientInformationByCpf([FromBody] string cpf)
        {
            var patientViewModel = _patientAppService.GetBasicInformationByCpf(cpf);

            return Response(patientViewModel);
        }

        [HttpGet]
        [Route("patient-basic-information/{id:guid}")]
        public async Task<IActionResult> GetBasicPatientInformationById([FromBody] Guid id)
        {
            var patientViewModel = _patientAppService.GetBasicInformationById(id);

            return Response(patientViewModel);
        }

        [HttpGet]
        [Route("patient-information/{cpf:maxlength(11)}")]
        public async Task<IActionResult> GetPatientByCpf([FromBody] string cpf)
        {
            var patientViewModel = _patientAppService.GetByCpf(cpf);

            return Response(patientViewModel);
        }

        [HttpGet]
        [Route("patient-information/{id:guid}")]
        public async Task<IActionResult> GetPatientById([FromBody] Guid id)
        {
            var patientViewModel = _patientAppService.GetById(id);

            return Response(patientViewModel);
        }


        [HttpPost]
        [Route("patient-register")]
        public async Task<IActionResult> RegisterNewPatient([FromBody] RegisterNewPatientViewModel patientViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(patientViewModel);
            }

            _patientAppService.Register(patientViewModel);

            return Response(patientViewModel);
        }


        [HttpPut]
        [Route("patient-management-address")]
        public async Task<IActionResult> UpdatePatientAddress([FromBody] UpdatePatientAddressViewModel patientViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(patientViewModel);
            }

            _patientAppService.UpdateAddress(patientViewModel);

            return Response(patientViewModel);
        }

        [HttpPut]
        [Route("patient-management-email")]
        public async Task<IActionResult> UpdatePatientEmail([FromBody] UpdatePatientEmailViewModel patientViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(patientViewModel);
            }

            _patientAppService.UpdateEmail(patientViewModel);

            return Response(patientViewModel);
        }

        [HttpPut]
        [Route("patient-management-heartrate")]
        public async Task<IActionResult> UpdatePatientHeartRate(
            [FromBody] UpdatePatientHeartRateViewModel patientViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(patientViewModel);
            }

            _patientAppService.UpdateHeartRate(patientViewModel);

            return Response(patientViewModel);
        }

        [HttpPut]
        [Route("patient-management-phone")]
        public async Task<IActionResult> UpdatePatientPhone([FromBody] UpdatePatientPhoneViewModel patientViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(patientViewModel);
            }

            _patientAppService.UpdatePhone(patientViewModel);

            return Response(patientViewModel);
        }

        [HttpPut]
        [Route("patient-management-photo")]
        public async Task<IActionResult> UpdatePatientPhoto([FromBody] UpdatePatientPhotoViewModel patientViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(patientViewModel);
            }

            _patientAppService.UpdatePhoto(patientViewModel);

            return Response(patientViewModel);
        }
    }
}