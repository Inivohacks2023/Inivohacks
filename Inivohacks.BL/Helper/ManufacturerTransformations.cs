using Inivohacks.BL.DTOs;
using Inivohacks.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Inivohacks.BL.Helper
{
    public static class ManufacturerTransformations
    {
        public static ManufacturerDto TransformDALtoAPI(this Manufacturer manufacturer)
        {
            if (manufacturer == null)
                return null;

            var item = new ManufacturerDto()
            {
                ManufacturerID = manufacturer.ManufacturerID,
                Name = manufacturer.Name,
                Address = manufacturer.Address,
                NotifyEmail = manufacturer.NotifyEmail,
                NotifySMS = manufacturer.NotifySMS
            };

            return item;
        }

        public static Manufacturer TransformAPItoDAL(this ManufacturerDto manufacturer)
        {
            if (manufacturer == null)
                return null;

            var item = new Manufacturer()
            {
                Name = manufacturer.Name,
                Address = manufacturer.Address,
                NotifyEmail = manufacturer.NotifyEmail,
                NotifySMS = manufacturer.NotifySMS

            };

            return item;
        }
    }
}
