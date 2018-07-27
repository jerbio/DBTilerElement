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
            this._otherPartyID = mySubCalEvent.ThirdPartyID;
            this.StartDateTime = mySubCalEvent.Start;
            this.EndDateTime = mySubCalEvent.End;
            



            //this.CalendarEventRange = CalendarEventRange.CreateCopy();
            this._Complete = mySubCalEvent.getIsComplete;
            this.ConflictingEvents = mySubCalEvent.Conflicts;
            this._DataBlob = mySubCalEvent.Notes;
            this._Enabled = mySubCalEvent.isEnabled;
            this._ProfileOfProcrastination = mySubCalEvent.getProcrastinationInfo;
            this._EventDuration = mySubCalEvent.getActiveDuration;
            this._Name = mySubCalEvent.getName;
            this._EventPreDeadline = mySubCalEvent.getPreDeadline;
            //this.EventScore = mySubCalEvent.Score;
            //this.EventSequence = mySubCalEvent.EventSequence.CreateCopy();
            //this.HumaneTimeLine = mySubCalEvent.hum HumaneTimeLine.CreateCopy();
            //this.InterferringEvents = mySubCalEvent.inter
            this.isRestricted = true;
            this.Vestige = mySubCalEvent.isVestige;
            this._LocationInfo = mySubCalEvent.Location;
            this.MiscIntData = mySubCalEvent.IntData;
            //this.NonHumaneTimeLine = mySubCalEvent.NonHumaneTimeLine.CreateCopy();
            this._PrepTime = mySubCalEvent.getPreparation;
            this._Priority = mySubCalEvent.getEventPriority;
            this.RigidSchedule = mySubCalEvent.isRigid;

            this._UiParams = mySubCalEvent.getUIParam;
            this.UniqueID = mySubCalEvent.SubEvent_ID;
            this.UnUsableIndex = 0;
            this._UserDeleted = mySubCalEvent.getIsUserDeleted;
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