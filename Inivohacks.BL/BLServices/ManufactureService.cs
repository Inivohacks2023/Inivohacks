using Inivohacks.BL.DTOs;
using Inivohacks.BL.Helper;
using Inivohacks.DAL.Models;
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
                manufacturerRepository.AddManufacturerAsync(manufactuer.TransformAPItoDAL());
                status = true;
            }
            catch {
                status = false;
            }
            return status;
        }

        public async IAsyncEnumerable<ManufacturerDto> GetAllManufacturerAsync()
        {
           IAsyncEnumerable<Manufacturer> manufacturerList =  manufacturerRepository.GetAllManufacturerAsync();


            await foreach (var m in manufacturerList)
            {
                yield return m.TransformDALtoAPI();
            }
           
        }
    }
}
