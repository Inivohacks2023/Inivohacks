﻿using AutoMapper;
using Inivohacks.BL.DTOs;
using Inivohacks.BL.DTOs.Models;
using Inivohacks.DAL.Models;
using Inivohacks.ViewModels;

namespace Inivohacks.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<ManufacturerRequestModel, ManufacturerDto>();
            CreateMap<ManufacturerModel, ManufacturerDto>();
            CreateMap<ManufacturerDto, ManufacturerModel>();
            CreateMap<ProductModel, ProductDto>();
            CreateMap<ProductDto, ProductModel>();
            CreateMap<AddCodesRequestModel, CodeDto>();
            CreateMap<GenerateCodesRequestModel, CodeDto>();
            CreateMap<TrackingCodeDTO, TrackingCode>();
            CreateMap<UserModel, UserDto>();
            CreateMap<UserDto, UserModel>();
            CreateMap<PermissionDto, PermissionModel>();
            CreateMap<PermissionModel, PermissionDto>();
            CreateMap<CertificateDto, CertificateModel>();
            CreateMap<CertificateModel, CertificateDto>();
            CreateMap<Scan,ScanDto>();
        }
    }

    public static class MapperProvider
    {
        private static MapperConfiguration _mapperconfig;
        private static IMapper _mapper;

        static MapperProvider()
        {
            Initialize();
        }
        private static MapperConfiguration MapperConfig
        {
            get
            {
                return _mapperconfig;
            }
        }

        public static IMapper Mapper
        {
            get
            {
                return _mapper;
            }
        }

        public static void Initialize()
        {
            CreateMapperConfig();
            CreateMapper();
        }

        private static void CreateMapperConfig()
        {
            _mapperconfig = new MapperConfiguration(mc => { mc.AddProfile(new ApplicationMapper()); });
        }

        private static void CreateMapper()
        {
            _mapper = MapperConfig.CreateMapper();
        }


    }

}
