using System.Text.RegularExpressions;
using System;

namespace BlazorWebApp.BlazorServer.Extensions
{
    public static class StringExtensions
    {
        public static string Slugify(this string name) =>
            Regex.Replace(name, @"[^a-zA-Z0-9\-_]", "-", RegexOptions.Compiled, TimeSpan.FromSeconds(1)).ToLower()
                 .Replace("--", "-")
                 .Trim('-');
    }
}
