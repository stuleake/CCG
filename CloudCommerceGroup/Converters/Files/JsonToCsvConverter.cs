using CloudCommerceGroup.Stategies;

namespace CloudCommerceGroup.Converters.Files
{
    /// <summary>
    /// Implementation of the <see cref="IConverterStrategy"/ for converting a json file to csv
    /// </summary>
    public class JsonToCsvConverter : IConverterStrategy
    {
        ///<inheritdoc/>
        public string Convert(string source)
        {
            // Implementation deliberately omitted 
            return "json -> csv";
        }
    }
}