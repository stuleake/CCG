using CloudCommerceGroup.Stategies;
using System.Linq;
using System.Text;

namespace CloudCommerceGroup.Converters.Files
{
    /// <summary>
    /// Implementation of the <see cref="IConverterStrategy"/ for converting a csv file to xml
    /// </summary>
    class CsvToXmlConverter : IConverterStrategy
    {
        ///<inheritdoc/>
        public string Convert(string source)
        {
            var lines = FileHelpers.ReadLines(source);
            var headerValuePairs = ContentHelpers.GetHeaderValuePairs(lines, FileHelpers.ReadAllExceptHeaders(lines));

            var xmlString = new StringBuilder();
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
                    xmlString.Append($"<{kvp.Key.Trim()}>{kvp.Value.Trim()}</{kvp.Key.Trim()}>");
                }
                else if (currentGroup != group)
                {
                    currentGroup = group;
                    var groupXmlString = new StringBuilder($"<{currentGroup}>");
                    headerValuePairs.Where(kv => kv.Key.StartsWith($"{currentGroup}_")).ToList()
                                    .ForEach(groupKey =>
                                        groupXmlString.Append($"<{groupKey.Key.Split('_')[1]}>{groupKey.Value.Trim()}</{groupKey.Key.Split('_')[1]}>"));

                    groupXmlString.Append($"</{currentGroup}>");
                    xmlString.Append(groupXmlString);
                }
            }

            return xmlString.ToString();
        }
    }
}