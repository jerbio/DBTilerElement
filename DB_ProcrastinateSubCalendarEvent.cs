using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilerElements;


namespace DBTilerElement
{
    public class DB_ProcrastinateAllSubCalendarEvent : ProcrastinateAllSubCalendarEvent
    {
        public DB_ProcrastinateAllSubCalendarEvent(TilerUser user, TilerUserGroup group, string timeZone, TimeLine timeLine, EventID calendarEventId, TilerElements.Location location, ProcrastinateCalendarEvent calendarEvent, bool isEnabled, bool isCompleted) : base(user, group, timeZone, timeLine, calendarEventId, location, calendarEvent)
        {
            this._TimeZone = timeZone;
            updateStartTime( timeLine.Start);
            updateEndTime(timeLine.End);
            this._RigidSchedule = true;
            this.UniqueID = calendarEventId;
            this._Creator = user;
            this._Users = group;
            this._Enabled = isEnabled;
            this._Complete = isCompleted;
            this._ProfileOfNow = new NowProfile();
            this._ProfileOfProcrastination = new Procrastination(new DateTimeOffset(), new TimeSpan());
            _isProcrastinateEvent = true;
            this._calendarEvent = calendarEvent;
        }

        public void setPausedTimeSlots(List<PausedTimeLine> pausedTimeSlots)
        {
            this._pausedTimeSlot = pausedTimeSlots.ToList();
        }

        override public TimeSpan UsedTime
        {
            set
            {
                this._UsedTime = value;
            }
            get
            {
                return this._UsedTime;
            }
        }

        public void updateReasons(IEnumerable<Reason> Reasons)
        {
            this.HistoricalReasonsCurrentPosition = new Dictionary<TimeSpan, List<Reason>>();
            HistoricalReasonsCurrentPosition.Add(new TimeSpan(), Reasons.ToList());
        }
    }
}
