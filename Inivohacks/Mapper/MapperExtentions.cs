namespace Inivohacks.Mapper
{
    public static class MapperExtentions
    {
        public static TViewModel ToViewModel<TDto, TViewModel>(this TDto dto)
        {
            return MapperProvider.Mapper.Map<TDto, TViewModel>(dto);
        }
        public static TDto ToDto<TViewModel, TDto>(this TViewModel viewModel)
        {
            return MapperProvider.Mapper.Map<TViewModel, TDto>(viewModel);
        }
    }
}
