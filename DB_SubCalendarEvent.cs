using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TilerElements;

namespace DBTilerElement
{
    public class DB_SubCalendarEvent:SubCalendarEvent
    {
        public DB_SubCalendarEvent(SubCalendarEvent mySubCalEvent, NowProfile NowProfileData, Procrastination ProcrastinationData)
        {
            this.BusyFrame = mySubCalEvent.ActiveSlot;
            this.CalendarEventRange = mySubCalEvent.getCalendarEventRange;
            this._Name = mySubCalEvent.getName;
            this.EventDuration = mySubCalEvent.getActiveDuration;
            this.Complete = mySubCalEvent.getIsComplete;
            this.ConflictingEvents = mySubCalEvent.Conflicts;
            this.DataBlob = mySubCalEvent.Notes;
            this.DeadlineElapsed = mySubCalEvent.getIsDeadlineElapsed;
            this.Enabled = mySubCalEvent.isEnabled;
            this.EndDateTime = mySubCalEvent.End;
            this.EventPreDeadline = mySubCalEvent.getPreDeadline;
            this.EventScore = mySubCalEvent.Score;
            this.isRestricted = mySubCalEvent.getIsEventRestricted;
            this.LocationInfo = mySubCalEvent.Location;
            this.OldPreferredIndex = mySubCalEvent.OldUniversalIndex;
            this.otherPartyID = mySubCalEvent.ThirdPartyID;
            this.preferredDayIndex = mySubCalEvent.UniversalDayIndex;
            this.PrepTime = mySubCalEvent.getPreparation;
            this.Priority = mySubCalEvent.getEventPriority;
            this.ProfileOfNow = NowProfileData;
            this.ProfileOfProcrastination = ProcrastinationData;
            this.RigidSchedule = mySubCalEvent.isLocked;
            this.StartDateTime = mySubCalEvent.Start;
            this.UiParams = mySubCalEvent.getUIParam;
            this.UniqueID = mySubCalEvent.SubEvent_ID;
            this.UserDeleted = mySubCalEvent.getIsUserDeleted;
            this._Users = mySubCalEvent.getAllUsers();
            this.Vestige = mySubCalEvent.isVestige;
            this._Name = mySubCalEvent.getName;
            this._Creator = mySubCalEvent.getCreator;
            this._Users = mySubCalEvent.getAllUsers();
            this._TimeZone = mySubCalEvent.getTimeZone;
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
        public void updateReasons(IEnumerable<Reason>Reasons)
        {
            this.HistoricalReasonsCurrentPosition = new Dictionary<TimeSpan, List<Reason>>();
            HistoricalReasonsCurrentPosition.Add(new TimeSpan(), Reasons.ToList());
        }
    }
}