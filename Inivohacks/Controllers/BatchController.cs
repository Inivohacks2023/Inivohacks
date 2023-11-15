using Inivohacks.BL;
using Inivohacks.BL.BLServices;
using Inivohacks.BL.DTOs;
using Inivohacks.DAL.Models;
using Inivohacks.Mapper;
using Inivohacks.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace Inivohacks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchController : Controller
    {
        private readonly IBatchService _batchService;

        public BatchController(IBatchService batchService)
        {
            _batchService = batchService;   
            
        }
        [HttpPost("AddNewBatch")]
        public async Task<ActionResult<Batch>> AddBatch(BatchRequestModel model)
        {
            try
            {
                var obj = MapperExtentions.ToDto<BatchRequestModel, BatchDTO>(model);
                var result = await _batchService.CreateBatchAsync(obj);
                return Ok(result);

            }
            catch (Exception e)
            { 
            return StatusCode(500, e.Message);
            }
        }

        [HttpGet("FilterBatches")]
        public async Task<ActionResult<List<Batch>>> GetAll(int? productId)
        {
            try
            {
                var result = await _batchService.GetAllBatchesAsync(productId);
                return result;

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);

            }
           
        }

        [HttpGet("ScanForDetails/{batchId}")]
        public async Task<ActionResult<Batch>>  GetBatchById(int batchId)
        {
            try
            {
                var result = await _batchService.GetBatchById(batchId);
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

        [HttpPost("Rebrand")]
        public async Task<ActionResult<Batch>> RebrandBatch(BatchDTO batch)
        {
            var result = await _batchService.RebrandBatch(batch);
            if (result == StaticVariables.SuccessMessage)
            {
                return Json(result);
            }
            return StatusCode(500, result);
        }



        [HttpPut("ScanToUpdateOwner")]
        public async Task<ActionResult<string>> ScanToUpdateOwner(int batchid, int locationId, string locationName)
        {

            var result = await _batchService.UpdateOwner(batchid: batchid,locationId:locationId,locationName:locationName); ;
            if (result == StaticVariables.SuccessMessage)
            {
                return Json(result);
            }
            return StatusCode(500, result);
        }

        [HttpPut("Recall/{batchId}")]
        public async Task<bool> Recall(int batchId)
        {
            
            var result = await _batchService.Recall(batchId);
            return result;
        }


        [HttpDelete("Delete/{batchId}")]
        public async Task<bool> Delete(int batchId)
        {
            var result = await _batchService.Delete(batchId);
            return result;
        }

    }
}
