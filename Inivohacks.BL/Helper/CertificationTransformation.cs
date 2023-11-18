using Inivohacks.BL.DTOs;
using Inivohacks.DAL.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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
                ExpiryDate = certificate.ExpiryDate,
                Token = certificate.Token,
            };

            return item;
        }

        public static Certificate TransformAPItoDAL(this CertificateDto certificate)
        {
            if (certificate == null)
                return null;

            var item = new Certificate()
            {
                ExpiryDate = certificate.ExpiryDate,
                InUse = true,
                Token = certificate.Token,
                ProductID = certificate.ProductID
            };

            return item;
        }
    }
}
