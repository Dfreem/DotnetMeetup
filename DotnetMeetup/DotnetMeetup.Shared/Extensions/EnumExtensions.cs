using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetMeetup.Shared.Extensions;
public static class EnumExtensions
{

    public static string ToKabobCase<T>(this T icon) where T : struct, Enum
    {
        string iconName = Enum.GetName(icon) ?? "";
        if (string.IsNullOrEmpty(iconName))
            return "";

        var builder = new StringBuilder();
        for (int i = 0; i < iconName.Length; i++)
        {
            char c = iconName[i];

            // Add a hyphen before uppercase letters unless part of a capitalized group
            if (i > 0 &&
                (char.IsUpper(c) && !char.IsUpper(iconName[i - 1]) ||
                 char.IsUpper(c) && i + 1 < iconName.Length && char.IsLower(iconName[i + 1]) ||
                 char.IsDigit(c) && !char.IsDigit(iconName[i - 1])))
                builder.Append('-');

            builder.Append(char.ToLower(c));
        }
        return builder.ToString();
    }

}