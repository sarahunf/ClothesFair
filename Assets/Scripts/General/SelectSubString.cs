using System;

namespace General
{
    //outside code. select substring
        static class SelectSubString
        {
            public static string GetUntilOrEmpty(this string text, string stopAt = "_")
            {
                if (!String.IsNullOrWhiteSpace(text))
                {
                    int charLocation = text.IndexOf(stopAt, StringComparison.Ordinal);

                    if (charLocation > 0)
                    {
                        return text.Substring(0, charLocation);
                    }
                }

                return String.Empty;
            }
        }
    }
