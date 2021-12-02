using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilerElements;


namespace DBTilerElement
{
    public class DB_ProcrastinateCalendarEvent: ProcrastinateCalendarEvent
    {
        public DB_ProcrastinateCalendarEvent(EventID procrasstinaeAllId, EventName NameEntry, DateTimeOffset StartData, DateTimeOffset EndData, TimeSpan EventDuration, TimeSpan eventPrepTime, TimeSpan PreDeadlineTimeSpan, Repetition EventRepetitionEntry, TilerElements.Location EventLocation, EventDisplay UiData, MiscData NoteData, bool EnabledEventFlag, bool CompletionFlag, TilerUser creator, TilerUserGroup users, string timeZone, int splitCount, NowProfile nowProfile) : base(procrasstinaeAllId, NameEntry, StartData, EndData, EventDuration, eventPrepTime, PreDeadlineTimeSpan, EventRepetitionEntry, EventLocation, UiData, NoteData, EnabledEventFlag, CompletionFlag, creator, users, timeZone, splitCount, nowProfile)
        {
            UniqueID = procrasstinaeAllId;
        }

        public DB_ProcrastinateCalendarEvent(CalendarEvent MyUpdated, SubCalendarEvent[] MySubEvents) : base(MyUpdated, MySubEvents)
        {

        }

        public void setPausedTimeSlots(List<PausedTimeLineEntry> pausedTimeSlots)
        {
            foreach (var pausedTimeSlot in pausedTimeSlots)
            {
                addToPausedTimeSlot(pausedTimeSlot);
            }
        }
    }

    
}
