using Inivohacks.BL.DTOs;
using Inivohacks.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inivohacks.BL.Helper
{
    public static class CertificationTransformation
    {
        public static CertificateDto TransformDALtoAPI(this Certificate certificate)
        {
            if (certificate == null)
                return null;

            var item = new CertificateDto()
            {
                ProductID = certificate.ProductID,
                InUse = certificate.InUse,
                ExpiryDate = certificate.ExpiryDate
                
            };

            return item;
        }

        public static Certificate TransformAPItoDAL(this CertificateDto certificate)
        {
            if (certificate == null)
                return null;

            var item = new Certificate()
            {
                ProductID = certificate.ProductID,
                InUse = certificate.InUse,
                ExpiryDate = certificate.ExpiryDate,
                CertificateID = certificate.CertificateID,
                Token =certificate.Token

            };

            return item;
        }
    }
}
