using Inivohacks.BL.DTOs.Models;
using Inivohacks.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inivohacks.BL.BLServices
{
    public interface IScanService
    {
        public Task<ScannedItemInfomationModel?> GetItemInformation(Guid guId);
        public  Task<TrackingCode> Add(TrackingCode tr);

        public Task<Guid> Rebrand(RebrandTrackerCodeDTO rebrandData);

        public Task<string> Recall(Guid guId);
        public Task<string> TransferItem(TransferBatchDTO transferBatchDTO);
    }
}
