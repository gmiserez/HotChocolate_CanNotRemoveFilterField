**Describe the bug**
If if use a POCO as base for a Type from my schema, I can not tell HotChocolate to ignore some fields of this POCO when the filters are generated. 

**To Reproduce**
I have a POCO "City" which is used as base for the CityType in my schema. 
```
    public class City
    {
        public string Name { get; set; }
        public string CountryCode { get; set; }
    }
```
I try to not have any filters generated for the property "CountryCode". 
To get the expected result I tried doing the following: 
```
    public class QueryType: ObjectType
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Name("Query");
            descriptor.Field<QueryType>(q => q.Cities)
                .UseFiltering<CityFilterType>();
        }
    }

    public class CityFilterType : FilterInputType<City>
    {
        protected override void Configure(
            IFilterInputTypeDescriptor<City> descriptor)
        {
            // We want to exclude this property from the generated filters
            descriptor.Filter(c => c.CountryCode).BindFiltersExplicitly();
        }
    }
```

**Expected behavior**
Since the flters on CountryCode are to be bound explicitly and I did not declare any filter on this property I expect to have no filters generated for this property. 
