using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TilerElements;

namespace DBTilerElement
{
    public class GoogleThirdPartyControl:ThirdPartyCalendarControl
    {
        public GoogleThirdPartyControl(Dictionary<string, CalendarEvent> CalendarData)
        {
            SelectedCalendarTool = ThirdPartyControl.CalendarTool.Google;
            IDToCalendarEvent = CalendarData;
        }

        public GoogleThirdPartyControl(IEnumerable< CalendarEvent> CalendarData)
        {
            SelectedCalendarTool = ThirdPartyControl.CalendarTool.Google;
            IDToCalendarEvent = CalendarData.ToDictionary(obj => obj.Id, obj => obj); 
        }

        public override string AddAppointment(SubCalendarEvent ActiveSection, string NameOfParentCalendarEvent = "")
        {
            throw new NotImplementedException();
        }

        public override void DeleteAppointment(SubCalendarEvent ActiveSection, string NameOfParentCalendarEvent = "", string entryID = "")
        {
            throw new NotImplementedException();
        }
    }
}
