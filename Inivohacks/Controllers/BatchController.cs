﻿using Inivohacks.BL;
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
        public async Task<bool> AddBatch(BatchRequestModel model)
        {
           var obj= MapperExtentions.ToDto<BatchRequestModel, BatchDTO>(model);
            var result = await _batchService.CreateBatchAsync(obj);
            return result;
        }

        [HttpGet("FilterBatches")]
        public async Task<List<Batch>> GetAll(int? productId)
        {
            var result = await _batchService.GetAllBatchesAsync(productId);
            return result;
        }

        [HttpGet("GetBatchById/{batchId}")]
        public async Task<ActionResult<Batch>>  GetBatchById(int batchId)
        {
            var result = await _batchService.GetBatchById(batchId);
            if (result != null)
            {
                return Json(result);
            }
            return Ok();
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