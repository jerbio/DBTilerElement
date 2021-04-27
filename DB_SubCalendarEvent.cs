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
        public DB_SubCalendarEvent(CalendarEvent calendarEvent, TilerUser Creator, TilerUserGroup users, string timeZone, string MySubEventID, EventName name, BusyTimeLine MyBusylot, DateTimeOffset EventStart, DateTimeOffset EventDeadline, TimeSpan EventPrepTime, string myParentID, bool Rigid, bool Enabled, EventDisplay UiParam, MiscData Notes, bool completeFlag, TilerElements.Location EventLocation = null, TimeLine calendarEventRange = null, ConflictProfile conflicts = null)
        {
            if (EventDeadline < EventStart)
            {
                throw new Exception("SubCalendar Event cannot have an end time earlier than the start time");
            }
            _TimeZone = timeZone;
            _Name = name;
            _Creator = Creator;
            _Users = users;
            if (conflicts == null)
            {
                conflicts = new ConflictProfile();
            }
            _ConflictingEvents = conflicts;
            _CalendarEventRange = calendarEventRange;
            //string eventName, TimeSpan EventDuration, DateTimeOffset EventStart, DateTimeOffset EventDeadline, TimeSpan EventPrepTime, TimeSpan PreDeadline, bool EventRigidFlag, bool EventRepetition, int EventSplit
            updateStartTime(EventStart);
            updateEndTime( EventDeadline);
            _EventDuration = MyBusylot.End - MyBusylot.Start;
            BusyFrame = MyBusylot;
            _PrepTime = EventPrepTime;
            UniqueID = new EventID(MySubEventID);
            this._LocationInfo = EventLocation;

            _UiParams = UiParam;
            _DataBlob = Notes;
            _Complete = completeFlag;

            this._Enabled = Enabled;
            //EventSequence = new EventTimeLine(UniqueID.ToString(), StartDateTime, EndDateTime);
            _RigidSchedule = Rigid;
            _LastReasonStartTimeChanged = this.Start;
            _calendarEvent = calendarEvent;
        }


        public DB_SubCalendarEvent(SubCalendarEvent mySubCalEvent, NowProfile NowProfileData, Procrastination ProcrastinationData, CalendarEvent calendarEvent)
        {
            this.BusyFrame = mySubCalEvent.ActiveSlot;
            this._CalendarEventRange = mySubCalEvent.getCalendarEventRange;
            this._Name = mySubCalEvent.getName;
            this._EventDuration = mySubCalEvent.getActiveDuration;
            this._Complete = mySubCalEvent.getIsComplete;
            this._ConflictingEvents = mySubCalEvent.Conflicts;
            this._DataBlob = mySubCalEvent.Notes;
            this._Enabled = mySubCalEvent.isEnabled;
            updateEndTime( mySubCalEvent.End);
            this._EventPreDeadline = mySubCalEvent.getPreDeadline;
            this._EventScore = mySubCalEvent.Score;
            this.isRestricted = mySubCalEvent.getIsEventRestricted;
            this._LocationInfo = mySubCalEvent.LocationObj;
            this.OldPreferredIndex = mySubCalEvent.OldUniversalIndex;
            this._otherPartyID = mySubCalEvent.ThirdPartyID;
            this.preferredDayIndex = mySubCalEvent.UniversalDayIndex;
            this._PrepTime = mySubCalEvent.getPreparation;
            this._Priority = mySubCalEvent.getEventPriority;
            this._ProfileOfNow = NowProfileData;
            this._ProfileOfProcrastination = ProcrastinationData;
            this._RigidSchedule = mySubCalEvent.isRigid;
            updateStartTime( mySubCalEvent.Start);
            this._UiParams = mySubCalEvent.getUIParam;
            this.UniqueID = mySubCalEvent.SubEvent_ID;
            this._AutoDeleted = mySubCalEvent.getIsUserDeleted;
            this._Users = mySubCalEvent.getAllUsers();
            this.Vestige = mySubCalEvent.isVestige;
            this._Name = mySubCalEvent.getName;
            this._Creator = mySubCalEvent.getCreator;
            this._Users = mySubCalEvent.getAllUsers();
            this._TimeZone = mySubCalEvent.getTimeZone;
            this._calendarEvent = calendarEvent;
        }

        //override public TimeSpan UsedTime
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


        public ThirdPartyControl.CalendarTool CalendarType
        {
            set
            {
                this.ThirdPartyTypeInfo = value;
            }
        }

        public void updateReasons(IEnumerable<Reason>Reasons)
        {
            this.HistoricalReasonsCurrentPosition = new Dictionary<TimeSpan, List<Reason>>();
            HistoricalReasonsCurrentPosition.Add(new TimeSpan(), Reasons.ToList());
        }

        public string ParentCalendarEventId { get; set; }
        [ForeignKey("ParentCalendarEventId")]
        public override CalendarEvent ParentCalendarEvent { get; set; }
    }
}