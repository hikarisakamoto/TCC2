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
    public class MedicalRecordController : BaseController
    {
        private readonly IMedicalRecordAppService _medicalRecordAppService;

        public MedicalRecordController(INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator, IMedicalRecordAppService medicalRecordAppService) : base(notifications, mediator)
        {
            _medicalRecordAppService = medicalRecordAppService;
        }

        [HttpPost]
        [Route("medical-record-simple")]
        public async Task<IActionResult> AddNewMedicalRecord(
            [FromBody] AddNewMedicalRecordViewModel medicalRecordViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(medicalRecordViewModel);
            }

            _medicalRecordAppService.Add(medicalRecordViewModel);
            return Response(medicalRecordViewModel);
        }

        [HttpPost]
        [Route("medical-record-with-image")]
        public async Task<IActionResult> AddNewMedicalRecordWithImage(
            [FromBody] AddNewMedicalRecordWithImageViewModel medicalRecordViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(medicalRecordViewModel);
            }

            _medicalRecordAppService.Add(medicalRecordViewModel);
            return Response(medicalRecordViewModel);
        }

        [HttpGet]
        [Route("medical-records")]
        public async Task<IActionResult> GetAllMedicalRecord()
        {
            var medicalRecordViewModel = await _medicalRecordAppService.GetAll();
            return Response(medicalRecordViewModel);
        }

        [HttpGet]
        [Route("medical-record/{id:guid}")]
        public async Task<IActionResult> GetMedicalRecordByIdTask(Guid? id)
        {
            if (id == null)
                return NotFound();

            var medicalRecordViewModel = await _medicalRecordAppService.GetById(id.Value);
            return Response(medicalRecordViewModel);
        }

        [HttpGet]
        [Route("medical-record/patient/{id:guid}")]
        public async Task<IActionResult> GetMedicalRecordByPatientId(Guid? id)
        {
            if (id == null)
                return NotFound();

            var medicalRecordViewModel = await _medicalRecordAppService.GetByPatientId(id.Value);
            return Response(medicalRecordViewModel);
        }

        [HttpGet]
        [Route("medical-record/practitioner/{id:guid}")]
        public async Task<IActionResult> GetMedicalRecordByPractitionerId(Guid? id)
        {
            if (id == null)
                return NotFound();

            var medicalRecordViewModel = await _medicalRecordAppService.GetByPractitionerId(id.Value);
            return Response(medicalRecordViewModel);
        }

        [HttpGet]
        [Route("medical-record/practitioner/{practitionerId:guid}/patient/{patientId:guid}")]
        public async Task<IActionResult> GetMedicalRecordByPractitionerId(Guid? practitionerId, Guid? patientId)
        {
            if (practitionerId == null || patientId == null)
                return NotFound();

            var medicalRecordViewModel =
                await _medicalRecordAppService.GetByPractitionerIdAndPatientId(practitionerId.Value, patientId.Value);
            return Response(medicalRecordViewModel);
        }

        [HttpDelete]
        [Route("medical-record-management-remove")]
        public async Task<IActionResult> RemoveExistingMedicalRecordById(
            RemoveExistingMedicalRecordByIdViewModel medicalRecordViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(medicalRecordViewModel);
            }

            _medicalRecordAppService.Remove(medicalRecordViewModel);

            return Response(medicalRecordViewModel);
        }
    }
}