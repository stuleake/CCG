using CloudCommerceGroup.Stategies;

namespace CloudCommerceGroup.Converters.Database
{
    /// <summary>
    /// Implementation of the <see cref="IConverterStrategy"/ for converting database content to xml
    /// </summary>
    public class DatabaseToXmlConverter : IConverterStrategy
    {
        ///<inheritdoc/>
        public string Convert(string source)
        {
            // Implementation deliberately omitted 
            return "db -> xml";
        }
    }
}