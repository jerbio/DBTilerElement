using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TilerElements;

namespace DBTilerElement
{
    public class DB_SubCalendarEventRestricted:SubCalendarEventRestricted
    {
        public DB_SubCalendarEventRestricted(SubCalendarEvent mySubCalEvent, DB_RestrictionProfile restrictionData, CalendarEventRestricted parentCalendarEvent, ReferenceNow now)
        {
            this.BusyFrame = mySubCalEvent.ActiveSlot;
            this.HardCalendarEventRange =mySubCalEvent.getCalendarEventRange;
            this._ProfileOfRestriction = restrictionData;
            this.OldPreferredIndex = mySubCalEvent.UniversalDayIndex;
            this._otherPartyID = mySubCalEvent.ThirdPartyID;
            this.updateStartTime( mySubCalEvent.Start);
            this.updateEndTime( mySubCalEvent.End);
            



            //this.CalendarEventRange = CalendarEventRange.CreateCopy();
            this._Complete = mySubCalEvent.getIsComplete;
            this._ConflictingEvents = mySubCalEvent.Conflicts;
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
            this._isEventRestricted = true;
            this.Vestige = mySubCalEvent.isVestige;
            this._LocationInfo = mySubCalEvent.LocationObj;
            this.MiscIntData = mySubCalEvent.IntData;
            //this.NonHumaneTimeLine = mySubCalEvent.NonHumaneTimeLine.CreateCopy();
            this._PrepTime = mySubCalEvent.getPreparation;
            this._Priority = mySubCalEvent.getEventPriority;
            this._RigidSchedule = mySubCalEvent.isRigid;

            this._UiParams = mySubCalEvent.getUIParam;
            this.UniqueID = mySubCalEvent.SubEvent_ID;
            this.UnUsableIndex = 0;
            this._AutoDeleted = mySubCalEvent.isAutoDeleted;
            this._Name = mySubCalEvent.getName;
            this._Creator = mySubCalEvent.getCreator;
            this._Users = mySubCalEvent.getAllUsers();
            this._TimeZone = mySubCalEvent.getTimeZone;
            this._Now = now;
            this._calendarEvent = parentCalendarEvent;
            initializeCalendarEventRange(restrictionData, this.HardCalendarEventRange);
        }

        //public override TimeSpan UsedTime
        //{
        //    set
        //    {
        //        this._UsedTime = value;
        //    }
        //    get
        //    {
        //        return this._UsedTime;
        //    }
        //}

        //public void setPausedTimeSlots(List<PausedTimeLine> pausedTimeSlots)
        //{
        //    this._pausedTimeSlot = pausedTimeSlots.ToList();
        //}

        public void updateReasons(IEnumerable<Reason> Reasons)
        {
            this.HistoricalReasonsCurrentPosition = new Dictionary<TimeSpan, List<Reason>>();
            HistoricalReasonsCurrentPosition.Add(new TimeSpan(), Reasons.ToList());
        }
    }
}