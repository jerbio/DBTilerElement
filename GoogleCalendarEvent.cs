﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilerElements.Wpf;
using TilerElements.DB;
using TilerElements.Connectors;
namespace DBTilerElement
{
    public class GoogleCalendarEvent : DB_CalendarEventFly
    {
        
        public GoogleCalendarEvent(SubCalEvent SubCalData)
        {
            DateTimeOffset Start = (new DateTimeOffset()).Add(TilerElementExtension.StartOfTimeTimeSpan).AddMilliseconds(SubCalData.SubCalStartDate);
            DateTimeOffset End = (new DateTimeOffset()).Add(TilerElementExtension.StartOfTimeTimeSpan).AddMilliseconds(SubCalData.SubCalEndDate);
            
            StartDateTime = Start;
            EndDateTime = End;
            Splits = 1;
            RigidSchedule = true;
            UniqueID = new EventID(new EventID(SubCalData.ID).getRepeatCalendarEventID());
            this.NameOfEvent = new EventName(UniqueID, SubCalData.SubCalCalendarName != null ? SubCalData.SubCalCalendarName : "");
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
            this.CreatorId = SubCalData.ThirdPartyUserID;
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
