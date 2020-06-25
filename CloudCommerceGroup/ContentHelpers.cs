using System.Collections.Generic;
using System.Linq;

namespace CloudCommerceGroup
{
    public static class ContentHelpers
    {
        public static IEnumerable<KeyValuePair<string, string>> GetHeaderValuePairs(string[] lines, 
                                                                                    string contents, 
                                                                                    int headerIndex = 0, 
                                                                                    char seperator = ',')
        {
            var keys = lines[headerIndex].Split(seperator);
            var values = contents.Split(seperator);
            
            return values.Zip(keys, (value, key) => new KeyValuePair<string, string>(key, value));
        }
    }
}