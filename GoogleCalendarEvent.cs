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
            _Creator = new GoogleTilerUser(SubCalData.ThirdPartyUserID);
            this._Name = new EventName( this.Creator_EventDB, null, SubCalData.SubCalCalendarName!=null?SubCalData.SubCalCalendarName:"");
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
            _LocationInfo = String.IsNullOrEmpty(SubCalData.SubCalAddressDescription) ? new TilerElements.Location() : new TilerElements.Location(SubCalData.SubCalAddressDescription);
            _ThirdPartyFlag = true;

            ThirdPartyTypeInfo = ThirdPartyControl.CalendarTool.google;
            _otherPartyID = SubCalData.ThirdPartyEventID;
            _Users = new TilerUserGroup();
            _DataBlob = new MiscData();
            _ProfileOfNow = new NowProfile();
            SubCalendarEvent mySubCal = GoogleSubCalendarEvent.convertFromGoogleToSubCalendarEvent( SubCalData, _LocationInfo);//.convertFromGoogleToSubCalendarEvent();
            SubEvents = new SubEventDictionary<string, SubCalendarEvent>();
            SubEvents.Collection.Add(mySubCal.Id, mySubCal);
        }


        static public CalendarEvent convertFromGoogleToCalendarEvent(SubCalEvent SubCalEventData)
        {
            CalendarEvent RetValue = new GoogleCalendarEvent(SubCalEventData);
            return RetValue;
        }


        
    }
}
