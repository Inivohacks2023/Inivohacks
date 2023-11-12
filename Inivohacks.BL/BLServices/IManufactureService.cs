using Inivohacks.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inivohacks.BL.BLServices
{
    public interface IManufactureService
    {
        public  Task<bool> CreateManufactureAsync(ManufacturerDto manufactuer);
    }
}
