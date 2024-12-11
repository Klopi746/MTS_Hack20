using UnityEngine;
using System.Text.RegularExpressions;
public static class isStringUrlSCRIPT
{
    public static bool IsUrl(string input)
    {
        if (string.IsNullOrEmpty(input))
            return false;

        string pattern = @"^(http|https)://[^\s/$.?#].[^\s]*$";
        return Regex.IsMatch(input, pattern);
    }
}
