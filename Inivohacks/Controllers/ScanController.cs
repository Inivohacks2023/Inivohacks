using Inivohacks.BL.BLServices;
using Inivohacks.BL.DTOs.Models;
using Inivohacks.DAL.Models;
using Inivohacks.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace Inivohacks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScanController : Controller
    {
        private readonly IScanService _iscanService;

        public ScanController(IScanService iscanService)
        {
            _iscanService = iscanService;

        }
        [HttpGet("ScanForDetails")]
        public async Task<ActionResult<ScannedItemInfomationModel>> GetBatchById(Guid TrackingCodeID,int? CertificateId,int? UserId,string?Latitude,string ?Longitude, string? Location)
        {
            try
            {
                var result = await _iscanService.GetItemInformation(TrackingCodeID, CertificateId, UserId,Latitude,Longitude,Location);
                if (result != null)
                {
                    return Json(result);
                }

                return StatusCode(500, "Object with given id not found");



            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }
/*
        [HttpPost("AddTrackingCode")]
        public async Task<ActionResult<ScannedItemInfomationModel>> Addscan(TrackingCodeDTO trackingoCodeObj)
        {
            try
            {
                var obj = MapperExtentions.ToDto<TrackingCodeDTO, TrackingCode>(trackingoCodeObj);
                var result = await _iscanService.Add(obj);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);

            }


        }*/
        [HttpPut("Rebrand")]
        public async Task<ActionResult<string>> Rebrand(RebrandTrackerCodeDTO rebrandObj)
        {
            try
            {

                var result = await _iscanService.Rebrand(rebrandObj);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);

            }
        }

        [HttpPut("Recall")]
        public async Task<ActionResult<string>> Recall(RecallDTO model)
        {
            try
            {

                var result = await _iscanService.Recall(model);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);

            }
        }

        [HttpPost("RequestTransfer")]
        public async Task<ActionResult<string>> RequestTransfer(TransferBatchDTO transferBatchDTO)
        {
            try
            {

                var result = await _iscanService.RequestTransfer(transferBatchDTO);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);

            }
        }

        [HttpPost("AcceptTransfer")]
        public async Task<ActionResult<string>> AcceptTransfer(TransferBatchDTO transferBatchDTO)
        {
            try
            {

                var result = await _iscanService.AcceptTransfer(transferBatchDTO);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);

            }
        }
    }
}
