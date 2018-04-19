using System;
using System.Collections.Generic;
using System.Linq;

namespace Home.BO
{
    public static class MinutesToTimeStringConverter
    {
        public static string ConvertToTimeString(int minutes)
        {
            if (minutes < 0 || minutes >= 1440)
                throw new ArgumentOutOfRangeException(nameof(minutes));
            if (minutes == 0)
                return "";
            var unit = (minutes == 1 ? "Min" : "Mins");
            if (minutes <= 90)
                return $"{minutes} {unit}";
            var hours = minutes / 60;
            minutes = minutes % 60;
            unit = (hours == 1 ? "Hr" : "Hrs");
            return ($"{hours} {unit} " + ConvertToTimeString(minutes)).Trim();
        }

        public static int ConvertToMinutes(string timeString)
        {
            if (string.IsNullOrWhiteSpace(timeString))
                return 0;
            timeString = $" {timeString.ToLower()} ";
            var tokens = new List<String>();
            int state = 0, start = 0;
            for (var i = 0; i <= timeString.Length; ++i)
            {
                if (char.IsWhiteSpace(timeString[i]) && state != 0)
                {
                    tokens.Add(timeString.Substring(start, i - start));
                    state = 0;
                }
                if (char.IsDigit(timeString[i]) && state != 1)
                {
                    if (state != 0) tokens.Add(timeString.Substring(start, i - start));
                    start = i;
                    state = 1;
                }
                else if (!char.IsWhiteSpace(timeString[i]) && state != 2)
                {
                    if (state != 0) tokens.Add(timeString.Substring(start, i - start));
                    start = i;
                    state = 2;
                }
                if (tokens.Count > 4)
                    throw new ArgumentException("Invalid format", nameof(timeString));
            }
            if (tokens.Count <= 0)
                throw new ArgumentException("Invalid format", nameof(timeString));
            int i1 = 0, i2 = 0;
            if (!int.TryParse(tokens[0], out i1) || (tokens.Count > 2 && !int.TryParse(tokens[2], out i2)))
                throw new ArgumentException("Invalid format", nameof(timeString));
            var hrTokens = new string[] { "h", "hr", "hrs", "hour", "hours" };
            var mnTokens = new string[] { "m", "min", "mins", "minute", "minutes" };
            if (tokens.Count == 2 && mnTokens.Contains(tokens[1]) && i1 <= 90)
                return i1;
            if (tokens.Count == 2 && hrTokens.Contains(tokens[0]) && i1 <= 23)
                return i1 * 60;
            if (tokens.Count == 3 && tokens[1] == ":" && i1 < 24 && i2 < 60)
                return i1 * 60 + i2;
            if (tokens.Count == 4 && hrTokens.Contains(tokens[1]) && mnTokens.Contains(tokens[3]) && i1 < 24 && i2 < 60)
                return i1 * 60 + i2;
            throw new ArgumentException("Invalid format", nameof(timeString));
        }
    }
}
