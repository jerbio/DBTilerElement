using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilerElements;

namespace DBTilerElement
{
    public class GoogleCalendarEvent : CalendarEvent
    {
        public GoogleCalendarEvent(SubCalEvent SubCalData)
        {
            DateTimeOffset Start = (new DateTimeOffset()).Add(TilerElementExtension.StartOfTimeTimeSpan).AddMilliseconds(SubCalData.SubCalStartDate);
            DateTimeOffset End = (new DateTimeOffset()).Add(TilerElementExtension.StartOfTimeTimeSpan).AddMilliseconds(SubCalData.SubCalEndDate);
            this.EventName = SubCalData.SubCalCalendarName!=null?SubCalData.SubCalCalendarName:"";
            StartDateTime = Start;
            EndDateTime = End;
            Splits = 1;
            RigidSchedule = true;
            UniqueID = new EventID(new EventID(SubCalData.ID).getRepeatCalendarEventID());
            RigidSchedule = true;
            EventPreDeadline = new TimeSpan();
            Priority = SubCalData.Priority;
            Enabled = true;
            Complete = false;
            EventDuration = End - Start;
            LocationInfo= new Location_Elements();
            ThirdPartyFlag = true;
            ThirdPartyTypeInfo = ThirdPartyControl.CalendarTool.Google;
            otherPartyID = SubCalData.ThirdPartyEventID;
            CreatorIDInfo = SubCalData.ThirdPartyUserID;
            SubCalendarEvent mySubCal = GoogleSubCalendarEvent.convertFromGoogleToSubCalendarEvent( SubCalData);//.convertFromGoogleToSubCalendarEvent();
            SubEvents = new Dictionary<EventID, SubCalendarEvent>() { { mySubCal.SubEvent_ID, mySubCal } };
        }


        static public CalendarEvent convertFromGoogleToCalendarEvent(SubCalEvent SubCalEventData)
        {
            CalendarEvent RetValue = new GoogleCalendarEvent(SubCalEventData);
            return RetValue;
        }


        
    }
}
