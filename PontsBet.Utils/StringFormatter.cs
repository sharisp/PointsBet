using System.Text;

namespace PontsBet.Utils
{
    public class StringFormatter
    {

        public static string ToCommaSepatatedList(string[] items, string separator)
        {
            if (separator == null)
            {
                throw new ArgumentException("separator is null");
            }
            if (items == null || items.Length == 0)
            {
                return string.Empty;
            }
            //string.Join is a convenient method to join strings with a separator
            //return string.Join(separator, items);
            int totalLength = 0;
            foreach (var item in items)
            {
                if (item == null)
                {
                    totalLength +=  separator.Length;
                    continue; 
                }
                totalLength += item.Length + separator.Length;

                // Check for overflow,StringBuilder has a limit of int.MaxValue
                if (totalLength > int.MaxValue)
                {
                    throw new ArgumentException("combining items are too long ");
                }
            }

            StringBuilder sb = new StringBuilder(totalLength);

            for (int i = 0; i < items.Length; i++)
            {               
                sb.Append(items[i] ?? string.Empty);
                if (i < items.Length - 1)
                {
                    sb.Append(separator);
                }
            }

            return sb.ToString();
        }   
    }
}
