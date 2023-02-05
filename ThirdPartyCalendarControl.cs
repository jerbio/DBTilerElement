using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TilerElements;




namespace DBTilerElement
{
    public abstract class ThirdPartyCalendarControl
    {
        protected ThirdPartyControl.CalendarTool SelectedCalendarTool;
        protected Dictionary<string, CalendarEvent> IDToCalendarEvent = new Dictionary<string, CalendarEvent>();
        protected ThirdPartyCalendarEvent ThirdpartyCalendarEventInfo;

        protected ThirdPartyCalendarControl()
        {}
        
        abstract public void DeleteAppointment(SubCalendarEvent ActiveSection, string NameOfParentCalendarEvent="", string entryID="");
        abstract public string AddAppointment(SubCalendarEvent ActiveSection, string NameOfParentCalendarEvent = "");

        public virtual Dictionary<string, CalendarEvent> getAllCalendarEvents()
        {
            return IDToCalendarEvent.ToDictionary(obj => obj.Key, obj => obj.Value);
        }

         public abstract CalendarEvent getThirdpartyCalendarEvent(ReferenceNow referenceNow);

        public abstract TilerUser getUser();

    }
}
