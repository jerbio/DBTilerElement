using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TilerElements;

namespace DBTilerElement
{
    public class DB_SubCalendarEventRestricted:SubCalendarEventRestricted
    {
        public DB_SubCalendarEventRestricted(SubCalendarEvent mySubCalEvent, DB_RestrictionProfile restrictionData)
        {
            this.BusyFrame = mySubCalEvent.ActiveSlot;
            this.HardCalendarEventRange =mySubCalEvent.getCalendarEventRange;
            this.ProfileOfRestriction = restrictionData;
            this.OldPreferredIndex = mySubCalEvent.UniversalDayIndex;
            this.otherPartyID = mySubCalEvent.ThirdPartyID;
            this.StartDateTime = mySubCalEvent.Start;
            this.EndDateTime = mySubCalEvent.End;
            



            //this.CalendarEventRange = CalendarEventRange.CreateCopy();
            this.Complete = mySubCalEvent.getIsComplete;
            this.ConflictingEvents = mySubCalEvent.Conflicts;
            this.DataBlob = mySubCalEvent.Notes;
            this.DeadlineElapsed = mySubCalEvent.getIsDeadlineElapsed;
            this.Enabled = mySubCalEvent.isEnabled;
            this.ProfileOfProcrastination = mySubCalEvent.getProcrastinationInfo;
            this.EventDuration = mySubCalEvent.getActiveDuration;
            this._Name = mySubCalEvent.getName;
            this.EventPreDeadline = mySubCalEvent.getPreDeadline;
            //this.EventScore = mySubCalEvent.Score;
            //this.EventSequence = mySubCalEvent.EventSequence.CreateCopy();
            //this.HumaneTimeLine = mySubCalEvent.hum HumaneTimeLine.CreateCopy();
            //this.InterferringEvents = mySubCalEvent.inter
            this.isRestricted = true;
            this.Vestige = mySubCalEvent.isVestige;
            this.LocationInfo = mySubCalEvent.Location;
            this.MiscIntData = mySubCalEvent.IntData;
            //this.NonHumaneTimeLine = mySubCalEvent.NonHumaneTimeLine.CreateCopy();
            this.PrepTime = mySubCalEvent.getPreparation;
            this.Priority = mySubCalEvent.getEventPriority;
            this.RigidSchedule = mySubCalEvent.getRigid;

            this.UiParams = mySubCalEvent.getUIParam;
            this.UniqueID = mySubCalEvent.SubEvent_ID;
            this.UnUsableIndex = 0;
            this.UserDeleted = mySubCalEvent.getIsUserDeleted;
            this._Name = mySubCalEvent.getName;
            this._Creator = mySubCalEvent.getCreator;
            this._Users = mySubCalEvent.getAllUsers();
            this._TimeZone = mySubCalEvent.getTimeZone;
            initializeCalendarEventRange(restrictionData, this.HardCalendarEventRange);
        }

        public TimeSpan UsedTime
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