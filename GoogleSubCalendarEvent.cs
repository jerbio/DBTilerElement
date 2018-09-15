﻿using System;
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
            _Creator = new GoogleTilerUser(SubCalData.ThirdPartyUserID);
            this._Name = new EventName(_Creator, this.ParentCalendarEvent, SubCalData.SubCalCalendarName != null ? SubCalData.SubCalCalendarName : "");
            StartDateTime = Start;
            EndDateTime = End;
            BusyFrame = new BusyTimeLine(SubCalData.ID, Start, End);
            _CalendarEventRange = new TimeLine(Start, End);
            UniqueID = new EventID(SubCalData.ID);
            RigidSchedule = true;
            _EventPreDeadline = new TimeSpan();
            _Priority = SubCalData.Priority;
            ConflictingEvents = new ConflictProfile();
            _Enabled = true;
            _Complete = false;
            _EventDuration = BusyFrame.TimelineSpan;
            _LocationInfo = new TilerElements.Location();
            _ThirdPartyFlag = true;
            ThirdPartyTypeInfo = ThirdPartyControl.CalendarTool.google;
            ThirdPartyUserIDInfo = SubCalData.ThirdPartyUserID;
            _Users = new TilerUserGroup()
            {

            };
            _otherPartyID = SubCalData.ThirdPartyEventID;
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
