using Inivohacks.BL.DTOs;
using Inivohacks.DAL.Models;
using Inivohacks.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inivohacks.BL.BLServices
{
    public class CodeService : ICodeService
    {
        private readonly ITrackingCodeRepository _trackingCodeRepository;
        public CodeService(ITrackingCodeRepository trackingCodeRepository)
        {
            _trackingCodeRepository = trackingCodeRepository;
        }

        public CodeResponseDto GenerateCodeAsync(int NoProducts, int ProductId)
        {
            TrackingCode code = new TrackingCode();
            List<Guid> Codes = new List<Guid>();
            foreach(int item in Enumerable.Range(1, NoProducts))
            {
                Codes.Add(new Guid(BitConverter.GetBytes(item)));
            }
            return new CodeResponseDto()
            {
                NoProducts = NoProducts,
                BatchNumber = code.BatchNumber,
                Codes = Codes
            };
        }


        public void SaveCustomCodeAsync(CodeDto codeDto)
        {
            throw new NotImplementedException();
        }
    }
}
