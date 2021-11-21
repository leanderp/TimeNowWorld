
using System.Globalization;

using TimeNowWorld.Models;

namespace TimeNowWorld.Core.Services;

public class TimeCountryServices
{
    public static TargetTime GetTimeCountry(TargetTime targetTime)
    {
        if (targetTime is null)
        {
            throw new ArgumentNullException(nameof(targetTime));
        }

        var timeInit = targetTime.MyCountry;

        if (timeInit is not null && targetTime.TargetCountries is not null)
        {
            string time = $@"{timeInit.Time}{ClearTimeZone(timeInit.TimeZone)}";

            var timeUtcTarget = TimeFormatUtc(time);

            foreach (var country in targetTime.TargetCountries)
            {
                string timeZone = ClearTimeZone(country.TimeZone);
                country.Time = TimeLocal(timeUtcTarget, timeZone);
            }
        }

        return targetTime;
    }

    private static string ClearTimeZone(string time)
    {
        string tzone = time.Replace("UTC", "");

        if (tzone.Contains('−'))
        {
            tzone = tzone.Replace("−", "");
            time = $@"-{tzone}";
        }
        else
        {
            time = $@"{tzone}";
        }

        return time;
    }

    private static (bool isUtcPositive, string time) ClearDataUtc(string timeZone)
    {
        bool isUtcPositive = false;
        string time = timeZone;

        if (timeZone.Contains('-'))
        {
            time = time.Replace("-", "");
        }
        else
        {
            isUtcPositive = true;
            time = time.Replace("+", "");
        }

        return (isUtcPositive, time);
    }


    private static DateTime TimeFormatUtc(string time)
    {
        var t = DateTimeOffset.Parse(time).UtcDateTime;

        return t;
    }

    private static DateTime TimeLocal(DateTime timeTarget, string timeZone)
    {
        DateTime dateTime;

        var (isUtcPositive, time) = ClearDataUtc(timeZone);

        dateTime = Convert.ToDateTime(time);
        
        DateTime dateTimeCopy = dateTime;

        if (isUtcPositive)
        {
            dateTime = timeTarget.AddHours(dateTimeCopy.Hour);
            dateTime = dateTime.AddMinutes(dateTimeCopy.Minute);
        }
        else
        {
            dateTime = timeTarget.AddHours(-dateTimeCopy.Hour);
            dateTime = dateTime.AddMinutes(-dateTimeCopy.Minute);
        }

        return dateTime;
    }
}

