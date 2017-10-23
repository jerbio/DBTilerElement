using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
            this._EventDuration = mySubCalEvent.getActiveDuration;
            this._Complete = mySubCalEvent.getIsComplete;
            this.ConflictingEvents = mySubCalEvent.Conflicts;
            this._DataBlob = mySubCalEvent.Notes;
            this._Enabled = mySubCalEvent.isEnabled;
            this.EndDateTime = mySubCalEvent.End;
            this._EventPreDeadline = mySubCalEvent.getPreDeadline;
            this.EventScore = mySubCalEvent.Score;
            this.isRestricted = mySubCalEvent.getIsEventRestricted;
            this._LocationInfo = mySubCalEvent.Location;
            this.OldPreferredIndex = mySubCalEvent.OldUniversalIndex;
            this._otherPartyID = mySubCalEvent.ThirdPartyID;
            this.preferredDayIndex = mySubCalEvent.UniversalDayIndex;
            this._PrepTime = mySubCalEvent.getPreparation;
            this._Priority = mySubCalEvent.getEventPriority;
            this._ProfileOfNow = NowProfileData;
            this._ProfileOfProcrastination = ProcrastinationData;
            this.RigidSchedule = mySubCalEvent.getRigid;
            this.StartDateTime = mySubCalEvent.Start;
            this._UiParams = mySubCalEvent.getUIParam;
            this.UniqueID = mySubCalEvent.SubEvent_ID;
            this._UserDeleted = mySubCalEvent.getIsUserDeleted;
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

        public string ParentCalendarEventId { get; set; }
        [ForeignKey("ParentCalendarEventId")]
        public CalendarEvent ParentCalendarEvent { get; set; }
    }
}