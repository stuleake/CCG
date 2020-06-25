using CloudCommerceGroup.Stategies;

namespace CloudCommerceGroup.Context
{
    /// <summary>
    /// The ConveterContext class, which maintains a reference to the chosen converter strategy <see cref="IConverterStrategy"/>
    /// </summary>
    public class ConverterContext
    {
        private IConverterStrategy _strategy;

        public void SetConversionStrategy(IConverterStrategy strategy)
        {
            this._strategy = strategy;
        }

        public string Convert(string source)
        {
            return _strategy.Convert(source);
        }
    }
}