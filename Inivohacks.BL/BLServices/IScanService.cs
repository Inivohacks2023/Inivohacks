using Inivohacks.BL.DTOs;
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
        public Task<ScannedItemInfomationModel?> GetItemInformation(Guid guId, int? CertificateId, int? UserId, string? Latitude, string? Longitude, string? Location);
        public  Task<TrackingCode> Add(TrackingCode tr);

        public Task<Guid> Rebrand(RebrandTrackerCodeDTO rebrandData);

        public Task<string> Recall(RecallDTO model);
        public Task<string> RequestTransfer(TransferBatchDTO transferBatchDTO);
        public Task<string> AcceptTransfer(TransferBatchDTO transferBatchDTO);
        public Task<List<Scan>> getHistory(Guid scanGuid);
    }
}
