using CloudCommerceGroup.Stategies;
using System.Linq;
using System.Text;

namespace CloudCommerceGroup.Converters.Files
{
    /// <summary>
    /// Implementation of the <see cref="IConverterStrategy"/ for converting a csv file to json>
    /// </summary>
    public class CsvToJsonConverter : IConverterStrategy
    {
        ///<inheritdoc/>
        public string Convert(string source)
        {
            var lines = FileHelpers.ReadLines(source);
            var headerValuePairs = ContentHelpers.GetHeaderValuePairs(lines, FileHelpers.ReadAllExceptHeaders(lines));
            
            var jsonString = new StringBuilder("{");
            var currentGroup = string.Empty;

            foreach (var kvp in headerValuePairs)
            {
                if (!string.IsNullOrWhiteSpace(currentGroup) && kvp.Key.StartsWith($"{currentGroup}_"))
                {
                    continue;
                }

                var group = kvp.Key.Split('_')[0];

                if (!kvp.Key.Contains('_'))
                {
                    jsonString.Append($"{kvp.Key.Trim()}: {kvp.Value.Trim()},");
                }
                else if (currentGroup != group)
                {
                    currentGroup = group;
                    var groupJsonString = new StringBuilder($"{currentGroup}:" + " {");
                    headerValuePairs.Where(kv => kv.Key.StartsWith($"{currentGroup}_")).ToList()
                                    .ForEach(groupKey =>
                                        groupJsonString.Append($"{groupKey.Key.Split('_')[1]}: {groupKey.Value.Trim()},"));

                    groupJsonString.Remove(groupJsonString.Length - 1, 1).Append(" }");
                    jsonString.Append($"{groupJsonString},");
                }
            }

            return jsonString.Remove(jsonString.Length - 1, 1).Append(@"}").ToString();
        }
    }
}