﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilerElements;


namespace DBTilerElement
{
    public class DB_ProcrastinateAllSubCalendarEvent : ProcrastinateAllSubCalendarEvent
    {
        public DB_ProcrastinateAllSubCalendarEvent(TilerUser user, TilerUserGroup group, string timeZone, TimeLine timeLine, EventID calendarEventId, Location_Elements location, ProcrastinateCalendarEvent calendarEvent, bool isEnabled, bool isCompleted) : base(user, group, timeZone, timeLine, calendarEventId, location, calendarEvent)
        {
            this._TimeZone = timeZone;
            this.StartDateTime = timeLine.Start;
            this.EndDateTime = timeLine.End;
            this.Rigid = true;
            this.UniqueID = calendarEventId;
            this._Creator = user;
            this._Users = group;
            this.Enabled = isEnabled;
            this.Complete = isCompleted;
            this.ProfileOfNow = new NowProfile();
            this.ProfileOfProcrastination = new Procrastination(new DateTimeOffset(), new TimeSpan());
            isProcrastinateEvent = true;
        }

        public TimeSpan UseTime
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

        public DateTimeOffset PauseTime
        {
            set
            {
                this._PauseTime = value;
            }
            get
            {
                return this._PauseTime;
            }
        }

        public void updateReasons(IEnumerable<Reason> Reasons)
        {
            this.HistoricalReasonsCurrentPosition = new Dictionary<TimeSpan, List<Reason>>();
            HistoricalReasonsCurrentPosition.Add(new TimeSpan(), Reasons.ToList());
        }
    }
}