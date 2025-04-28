
using DotnetMeetup.Shared.Enums;
using DotnetMeetup.Shared.Enums.UI;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetMeetup.Shared.Components.CalendarPicker;

public class CalendarWeek
{
    public CalendarDay[] Days { get; set; } = [];

}

public class CalendarDay
{
    public bool HasDate { get; set; }
    public DayOfWeek WeekDay { get => _date.DayOfWeek; }

    /// <summary>
    /// specify color to fill the day's square with.<br />
    /// - Selected represents the selected date and will draw a highliting border and background. color's are set in _calendars.scss
    /// - up to 4 other colors can be specified at once using the <see cref="CalendarDayColor"/> flags enum.
    /// - multiple colors are split evenly to fille the days background
    /// </summary>
    public CalendarDayColor Colors { get; set; }

    public DateTime Date { get => _date; set { _date = value; HasDate = true; } }

    DateTime _date;

}
