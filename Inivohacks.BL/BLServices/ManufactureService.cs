using Inivohacks.BL.DTOs;
using Inivohacks.BL.Helper;
using Inivohacks.DAL.Repositories;

namespace Inivohacks.BL.BLServices
{
    public class ManufactureService : IManufactureService
    {
        private readonly IManufacturerRepository manufacturerRepository;

        public ManufactureService(IManufacturerRepository manufacturerRepository)
        { 
            this.manufacturerRepository = manufacturerRepository;
        }
        public async Task<bool> CreateManufactureAsync(ManufacturerDto manufactuer)
        {
            bool status = false;
            if (manufactuer == null)
            {
                status = false;
            }
            try
            {
                manufacturerRepository.AddAsync(manufactuer.TransformAPItoDAL());
                status = true;
            }
            catch {
                status = false;
            }
            return status;
        }
    }
}
