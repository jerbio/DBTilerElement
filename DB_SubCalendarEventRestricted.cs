using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TilerElements;

namespace DBTilerElement
{
    public class DB_SubCalendarEventRestricted:SubCalendarEventRestricted//, IDB_SubCalendarEvent, IRestrictedEvent
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
            this.Complete = mySubCalEvent.isComplete;
            this.ConflictingEvents = mySubCalEvent.Conflicts;
            this.DataBlob = mySubCalEvent.Notes;
            this.DeadlineElapsed = mySubCalEvent.isDeadlineElapsed;
            this.Enabled = mySubCalEvent.isEnabled;
            
            this.EventDuration = mySubCalEvent.ActiveDuration;
            
            this.EventPreDeadline = mySubCalEvent.PreDeadline;
            this.FromRepeatEvent = mySubCalEvent.FromRepeat;
            
            
            this.Vestige = mySubCalEvent.isVestige;
            this.LocationInfo = mySubCalEvent.Location;
            this.MiscIntData = mySubCalEvent.IntData;
            //this.NonHumaneTimeLine = mySubCalEvent.NonHumaneTimeLine.CreateCopy();
            this.PrepTime = mySubCalEvent.Preparation;
            this.Priority = mySubCalEvent.EventPriority;
            this.FromRepeatEvent = mySubCalEvent.FromRepeat;
            this.RigidSchedule = mySubCalEvent.Rigid;
            

            this.UiParams = mySubCalEvent.UIParam;
            this.UniqueID = mySubCalEvent.SubEvent_ID;
            this.NameOfEvent = new EventName(this.UniqueID , mySubCalEvent.Name);
            this.UnUsableIndex = 0;
            this.UserDeleted = mySubCalEvent.isUserDeleted;
            this.UserIDs = mySubCalEvent.getAllUserIDs();
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
    }
}