using System;

namespace Browser
{
    public static class StringExtension
    {
        public static bool include(this String str, string strsPart)
        {
            return (str.IndexOf(strsPart) == -1) ? false : true;
        }

        public static string RemoveInsertedToBegindText(this String str, string insertedToBegindText)
        {
            return str.Remove(0, insertedToBegindText.Length);
        }
    }
}
