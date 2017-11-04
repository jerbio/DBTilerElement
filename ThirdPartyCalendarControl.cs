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
        ThirdPartyCalendarEvent ThirdpartyCalendarEventInfo;

        protected ThirdPartyCalendarControl()
        {}
        
        abstract public void DeleteAppointment(SubCalendarEvent ActiveSection, string NameOfParentCalendarEvent="", string entryID="");
        abstract public string AddAppointment(SubCalendarEvent ActiveSection, string NameOfParentCalendarEvent = "");

        public virtual Dictionary<string, CalendarEvent> getAllCalendarEvents()
        {
            return IDToCalendarEvent.ToDictionary(obj => obj.Key, obj => obj.Value);
        }

        void populateThirdpartyCalendarEventInfo (TilerUser user)
        {
            ThirdpartyCalendarEventInfo = new ThirdPartyCalendarEvent(IDToCalendarEvent.Values, user);

        }

        virtual public CalendarEvent getThirdpartyCalendarEvent()
        {
            if (ThirdpartyCalendarEventInfo==null)
            {
                populateThirdpartyCalendarEventInfo(getUser());
            }
            return ThirdpartyCalendarEventInfo;
        }

        public abstract TilerUser getUser();

    }

    class ThirdPartyCalendarEvent:CalendarEvent
    {
        public ThirdPartyCalendarEvent(IEnumerable<CalendarEvent>AllCalendarEvent, TilerUser user)
        {
            this._EventDuration = new TimeSpan(50);
            this._Splits = 1;
            this._AverageTimePerSplit= _EventDuration;
            this._UiParams = new EventDisplay();
            this.UnDesignables = new HashSet<SubCalendarEvent>();
            this.UniqueID = EventID.generateGoogleCalendarEventID((uint)AllCalendarEvent.Count());
            this._UserDeleted = false;
            this._Users = new TilerUserGroup();
            this.StartDateTime = DateTimeOffset.Now.AddDays(-90);
            this.EndDateTime = this.StartDateTime.AddDays(180);
            this._Enabled = true;
            this._Complete = false;
            this._DeletedCount = 1;
            this._CompletedCount = 1;
            this._Creator = user;
            this._EventRepetition = new Repetition(true, this.RangeTimeLine, "Daily", AllCalendarEvent.ToArray());
            this._Name = new EventName(user, this, "GOOGLE MOTHER EVENT");
            this._ProfileOfNow = new NowProfile();
        }
    }
}
