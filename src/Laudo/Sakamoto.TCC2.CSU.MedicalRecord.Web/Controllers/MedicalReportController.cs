using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sakamoto.TCC2.CSU.Domain.Core.Bus;
using Sakamoto.TCC2.CSU.Domain.Core.Notifications;
using Sakamoto.TCC2.CSU.MedicalRecord.Application.Interfaces;
using Sakamoto.TCC2.CSU.MedicalRecord.Application.ViewModel;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Web.Controllers
{
    public class MedicalReportController : BaseController
    {
        private readonly IMedicalReportAppService _medicalReportAppService;

        public MedicalReportController(INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator, IMedicalReportAppService medicalReportAppService) : base(notifications, mediator)
        {
            _medicalReportAppService = medicalReportAppService;
        }

        [HttpPost]
        [Route("medical-report")]
        public async Task<IActionResult> AddNewMedicalReport(
            [FromBody] AddNewMedicalReportViewModel medicalReportViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(medicalReportViewModel);
            }

            _medicalReportAppService.Add(medicalReportViewModel);
            return Response(medicalReportViewModel);
        }

        [HttpPost]
        [Route("medical-report")]
        public async Task<IActionResult> AddNewMedicalReportWithImage(
            [FromBody] AddNewMedicalReportWithImageViewModel medicalReportViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(medicalReportViewModel);
            }

            _medicalReportAppService.Add(medicalReportViewModel);
            return Response(medicalReportViewModel);
        }

        [HttpGet]
        [Route("medical-report/{id:guid}")]
        public async Task<IActionResult> GetMedicalReportByIdTask([FromBody] Guid id)
        {
            var medicalReportViewModel = _medicalReportAppService.GetById(id);
            return Response(medicalReportViewModel);
        }

        [HttpGet]
        [Route("medical-report/patient/{id:guid}")]
        public async Task<IActionResult> GetMedicalReportByPatientId([FromBody] Guid id)
        {
            var medicalReportViewModel = _medicalReportAppService.GetByPatientId(id);
            return Response(medicalReportViewModel);
        }

        [HttpGet]
        [Route("medical-report/practitioner/{id:guid}")]
        public async Task<IActionResult> GetMedicalReportByPractitionerId([FromBody] Guid id)
        {
            var medicalReportViewModel = _medicalReportAppService.GetByPractitionerId(id);
            return Response(medicalReportViewModel);
        }

        [HttpGet]
        [Route("medical-report/practitioner/{practitionerId:guid}/patient/{patientId:guid}")]
        public async Task<IActionResult> GetMedicalReportByPractitionerId([FromBody] Guid practitionerId,
            [FromBody] Guid patientId)
        {
            var medicalReportViewModel =
                _medicalReportAppService.GetByPractitionerIdAndPatientId(practitionerId, patientId);
            return Response(medicalReportViewModel);
        }

        [HttpDelete]
        [Route("medical-report-management-remove")]
        public async Task<IActionResult> RemoveExistingMedicalReportById(
            [FromBody] RemoveExistingMedicalReportByIdViewModel medicalReportViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(medicalReportViewModel);
            }

            _medicalReportAppService.Remove(medicalReportViewModel);

            return Response(medicalReportViewModel);
        }
    }
}