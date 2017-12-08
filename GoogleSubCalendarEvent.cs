using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilerElements;

namespace DBTilerElement
{
    public class GoogleSubCalendarEvent : SubCalendarEvent
    {
        public GoogleSubCalendarEvent(SubCalEvent SubCalData, TilerElements.Location location = null)
        {
            DateTimeOffset Start = (new DateTimeOffset()).Add(TilerElementExtension.StartOfTimeTimeSpan).AddMilliseconds(SubCalData.SubCalStartDate);
            DateTimeOffset End = (new DateTimeOffset()).Add(TilerElementExtension.StartOfTimeTimeSpan).AddMilliseconds(SubCalData.SubCalEndDate);
            this._Name = new EventName( SubCalData.SubCalCalendarName != null ? SubCalData.SubCalCalendarName : "");
            StartDateTime = Start;
            EndDateTime = End;
            BusyFrame = new BusyTimeLine(SubCalData.ID, Start, End);
            CalendarEventRange = new TimeLine(Start, End);
            UniqueID = new EventID(SubCalData.ID);
            RigidSchedule = true;
            EventPreDeadline = new TimeSpan();
            Priority = SubCalData.Priority;
            ConflictingEvents = new ConflictProfile();
            Enabled = true;
            Complete = false;
            EventDuration = BusyFrame.TimelineSpan;
            LocationInfo = location ?? new TilerElements.Location();
            ThirdPartyFlag = true;
            ThirdPartyTypeInfo = ThirdPartyControl.CalendarTool.google;
            ThirdPartyUserIDInfo = SubCalData.ThirdPartyUserID;
            _Creator = new GoogleTilerUser(SubCalData.ThirdPartyUserID);
            _Users = new TilerUserGroup()
            {

            };
            otherPartyID = SubCalData.ThirdPartyEventID;
        }

        static public SubCalendarEvent convertFromGoogleToSubCalendarEvent(SubCalEvent SubCalEventData, TilerElements.Location location = null)
        {
            if (location == null && !String.IsNullOrEmpty(SubCalEventData.SubCalAddress))
            {
                location = new TilerElements.Location(SubCalEventData.SubCalAddress);
            }
            SubCalendarEvent RetValue = new GoogleSubCalendarEvent(SubCalEventData, location);
            return RetValue;
        }
    }

}
