using AutoMapper;
using Inivohacks.BL.DTOs;
using Inivohacks.ViewModels;

namespace Inivohacks.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<ManufacturerModel, ManufacturerDto>();
            CreateMap<ManufacturerDto, ManufacturerModel>();
            CreateMap<ProductModel, ProductDto>();
            CreateMap<ProductDto, ProductModel>();
            CreateMap<AddCodeRequestModel, CodeDto>();
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
