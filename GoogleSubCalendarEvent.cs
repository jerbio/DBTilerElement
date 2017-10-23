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
            this._Name = new EventName( SubCalData.SubCalCalendarName != null ? SubCalData.SubCalCalendarName : "");
            StartDateTime = Start;
            EndDateTime = End;
            BusyFrame = new BusyTimeLine(SubCalData.ID, Start, End);
            CalendarEventRange = new TimeLine(Start, End);
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
            _Creator = new GoogleTilerUser(SubCalData.ThirdPartyUserID);
            _Users = new TilerUserGroup()
            {

            };
            _otherPartyID = SubCalData.ThirdPartyEventID;
        }

        static public SubCalendarEvent convertFromGoogleToSubCalendarEvent(SubCalEvent SubCalEventData)
        {
            SubCalendarEvent RetValue = new GoogleSubCalendarEvent(SubCalEventData);
            return RetValue;
        }
    }

}
