using System.Collections.Generic;

namespace AllegroRestApiTests
{
    public class ParameterOptions
    {
        public bool VariantsAllowed { get; set; }
        public bool VariantsEqual { get; set; }
        public string AmbiguousValueId { get; set; }
        public string DependsOnParameterId { get; set; }
        public List<string> RequiredDependsOnValueIds { get; set; }
        public List<string> DisplayDependsOnValueIds { get; set; }
        public bool DescribesProduct { get; set; }
        public bool CustomValuesEnabled { get; set; }
    }
}