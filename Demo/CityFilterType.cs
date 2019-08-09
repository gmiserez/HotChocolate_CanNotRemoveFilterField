using HotChocolate.Types.Filters;

namespace Demo
{
    public class CityFilterType : FilterInputType<City>
    {
        protected override void Configure(
            IFilterInputTypeDescriptor<City> descriptor)
        {
            // We want to exclude this property from the generated filters
            descriptor.Filter(c => c.CountryCode).BindFiltersExplicitly();
        }
    }
}
