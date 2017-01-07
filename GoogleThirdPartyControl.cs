using System;
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
            IDToCalendarEvent = CalendarData.ToDictionary(obj => obj.getId, obj => obj); 
        }

        public override string AddAppointment(SubCalendarEvent ActiveSection, string NameOfParentCalendarEvent = "")
        {
            throw new NotImplementedException();
        }

        public override void DeleteAppointment(SubCalendarEvent ActiveSection, string NameOfParentCalendarEvent = "", string entryID = "")
        {
            throw new NotImplementedException();
        }

        public override TilerUser getUser()
        {
            return _User;
        }
    }
}
