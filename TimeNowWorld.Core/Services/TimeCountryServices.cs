
using System.Globalization;

using TimeNowWorld.Models;

namespace TimeNowWorld.Core.Services;

public class TimeCountryServices
{
    public static TargetTime GetTimeCountry(TargetTime? targetTime)
    {
        if (targetTime is null)
        {
            throw new ArgumentNullException(nameof(targetTime));
        }

        if (targetTime.MyCountry is not null)
        {
            if (targetTime.MyCountry.TimeZone is not null)
            {
                string timeZoneInit = ClearTimeZone(targetTime.MyCountry.TimeZone);

                string time = $@"{targetTime.MyCountry.Time}{timeZoneInit}";

                var timeUtcTarget = TimeFormatUtc(time);

                if (targetTime.TargetCountries is not null)
                {
                    foreach (var country in targetTime.TargetCountries)
                    {
                        if (country is not null)
                        {
                            if (country.TimeZone is not null)
                            {
                                string timeZone = ClearTimeZone(country.TimeZone);
                                country.Time = TimeLocal(timeUtcTarget, timeZone);
                            }
                        }
                    }
                }
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

