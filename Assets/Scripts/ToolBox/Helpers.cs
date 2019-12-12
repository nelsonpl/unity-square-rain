using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Entities;

namespace Assets.Scripts
{
    internal static class Helpers
    {
        internal static string ReplaceStringEmpty(this string text, string value)
        {
            return text.Replace(value, string.Empty);
        }
    }
}
