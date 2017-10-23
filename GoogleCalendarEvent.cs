﻿using System;
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
            this._Name = new EventName( SubCalData.SubCalCalendarName!=null?SubCalData.SubCalCalendarName:"");
            StartDateTime = Start;
            EndDateTime = End;
            _Splits = 1;
            RigidSchedule = true;
            UniqueID = new EventID(new EventID(SubCalData.ID).getRepeatCalendarEventID());
            RigidSchedule = true;
            _EventPreDeadline = new TimeSpan();
            _Priority = SubCalData.Priority;
            _Enabled = true;
            _Complete = false;
            _EventDuration = End - Start;
            _LocationInfo = new TilerElements.Location();
            _ThirdPartyFlag = true;
            ThirdPartyTypeInfo = ThirdPartyControl.CalendarTool.google;
            _otherPartyID = SubCalData.ThirdPartyEventID;
            _Creator = new GoogleTilerUser(SubCalData.ThirdPartyUserID);
            _Users = new TilerUserGroup();
            
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
