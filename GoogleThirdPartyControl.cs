﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TilerElements;

namespace DBTilerElement
{
    public class GoogleThirdPartyControl:ThirdPartyCalendarControl
    {
        TilerUser _User;
        public GoogleThirdPartyControl(Dictionary<string, CalendarEvent> CalendarData, TilerUser user)
        {
            SelectedCalendarTool = ThirdPartyControl.CalendarTool.google;
            IDToCalendarEvent = CalendarData;
            _User = user;
        }

        public GoogleThirdPartyControl(IEnumerable< CalendarEvent> CalendarData)
        {
            SelectedCalendarTool = ThirdPartyControl.CalendarTool.google;
            IDToCalendarEvent = new Dictionary<string, CalendarEvent>();
            foreach (CalendarEvent calendarEvent in CalendarData)
            {
                if(!IDToCalendarEvent.ContainsKey(calendarEvent.getId)) IDToCalendarEvent.Add(calendarEvent.getId, calendarEvent);

            }
            //IDToCalendarEvent = CalendarData.ToDictionary(obj => obj.getId, obj => obj); 
        }

        public override string AddAppointment(SubCalendarEvent ActiveSection, string NameOfParentCalendarEvent = "")
        {
            throw new NotImplementedException();
        }

        public override void DeleteAppointment(SubCalendarEvent ActiveSection, string NameOfParentCalendarEvent = "", string entryID = "")
        {
            throw new NotImplementedException();
        }

        public override CalendarEvent getThirdpartyCalendarEvent(ReferenceNow referenceNow)
        {
            if (ThirdpartyCalendarEventInfo==null)
            {
                ThirdpartyCalendarEventInfo = new GoogleCalendarEvent(IDToCalendarEvent.Values, _User, referenceNow);
            }
            return ThirdpartyCalendarEventInfo;
        }

        public override TilerUser getUser()
        {
            return _User;
        }
    }
}
