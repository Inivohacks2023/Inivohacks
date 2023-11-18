using Inivohacks.BL.DTOs;
using Inivohacks.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inivohacks.BL.Helper
{
    public static class CertTransformation
    {
        //public static CertificateDto TransformDALtoAPI(this Certificate certificate)
        //{
        //    if (certificate == null)
        //        return null;

        //    var item = new CertificateDto()
        //    {
        //        ProductID = certificate.ProductID,
        //        InUse = certificate.InUse,
        //        ExpiryDate = certificate.ExpiryDate

        //    };

        //    return item;
        //}

        public static CertPermission TransformAPItoDAL(int certificateID,int permissionId)
        {
           

            var item = new CertPermission()
            {

                CertificateID = certificateID,
                PermissionID = permissionId
            };

            return item;
        }
    }
}
