using System.Windows.Forms;

namespace SearchSimilarImages
{
    static class ListViewExtensions
    {
        public static void AddRow(this ListView lvw, string key,
            string itemTitle, params string[] subitemTitles)
        {
            var newItem = lvw.Items.Add(itemTitle, key);

            for (var i = subitemTitles.GetLowerBound(0);
                     i <= subitemTitles.GetUpperBound(0);
                     i++)
            {
                newItem.SubItems.Add(subitemTitles[i]);
            }
        }
    }
}
