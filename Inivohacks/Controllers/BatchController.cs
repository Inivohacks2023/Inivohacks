using Inivohacks.BL.BLServices;
using Inivohacks.BL.DTOs;
using Inivohacks.Mapper;
using Inivohacks.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
        [HttpPost]
        public async Task<bool> AddBatch(BatchRequestModel model)
        {
           var obj= MapperExtentions.ToDto<BatchRequestModel, BatchDTO>(model);
            var r = _batchService.CreateBatchAsync(obj);
            return true;
        }
    }
}
