namespace CloudCommerceGroup.Stategies
{
    // Strategy interface for converting data from one format to another
    public interface IConverterStrategy
    {
        /// <summary>
        /// Converts the data from the specified source
        /// </summary>
        ///// <param name="source">the location of the data to convert.  IE File path, DB connection string</param>
        /// <returns>a string in the converted format</returns>
        string Convert(string source);
    }
}