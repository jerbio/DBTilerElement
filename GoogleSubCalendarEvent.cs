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
        public GoogleSubCalendarEvent(SubCalEvent SubCalData)
        {
            DateTimeOffset Start = (new DateTimeOffset()).Add(TilerElementExtension.StartOfTimeTimeSpan).AddMilliseconds(SubCalData.SubCalStartDate);
            DateTimeOffset End = (new DateTimeOffset()).Add(TilerElementExtension.StartOfTimeTimeSpan).AddMilliseconds(SubCalData.SubCalEndDate);
            
            StartDateTime = Start;
            EndDateTime = End;
            BusyFrame = new BusyTimeLine(SubCalData.ID, Start, End);
            CalendarEventRange = new TimeLine(Start, End);
            UniqueID = new EventID(SubCalData.ID);
            this.NameOfEvent = new EventName(UniqueID, SubCalData.SubCalCalendarName != null ? SubCalData.SubCalCalendarName : "");
            RigidSchedule = true;
            EventPreDeadline = new TimeSpan();
            Priority = SubCalData.Priority;
            ConflictingEvents = new ConflictProfile();
            Enabled = true;
            Complete = false;
            EventDuration = BusyFrame.TimelineSpan;
            LocationInfo= new Location_Elements();
            ThirdPartyFlag = true;
            ThirdPartyTypeInfo = ThirdPartyControl.CalendarTool.Google;
            ThirdPartyUserIDInfo = SubCalData.ThirdPartyUserID;
            CreatorIDInfo = SubCalData.ThirdPartyUserID;
            otherPartyID = SubCalData.ThirdPartyEventID;
        }

        static public SubCalendarEvent convertFromGoogleToSubCalendarEvent(SubCalEvent SubCalEventData)
        {
            SubCalendarEvent RetValue = new GoogleSubCalendarEvent(SubCalEventData);
            return RetValue;
        }
    }

}
