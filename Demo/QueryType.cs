using System.Collections.Generic;
using HotChocolate.Types;
using HotChocolate.Types.Filters;

namespace Demo
{
    public class QueryType: ObjectType
    {
        public ICollection<City> Cities => _cities ?? (_cities = new List<City>
        {
            new City("Amsterdam", "nl"),
            new City("Berlin", "de"),
            new City("Paris", "fr"),
            new City("Zürich", "ch"),
        });

        private ICollection<City> _cities = null;


        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Name("Query");

            descriptor.Field<QueryType>(q => q.Cities)
                .UseFiltering<CityFilterType>();
        }
    }
}
