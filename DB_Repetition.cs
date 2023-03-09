using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilerElements;

namespace DBTilerElement
{
    public class DB_Repetition:Repetition
    {
        public override bool isPersistable { get; set; } = false;
        public DB_Repetition (CalendarEvent parentCalendarEvent, IEnumerable<CalendarEvent> calEvents, int dayOfWeek = 7, bool notSubRepetition = false  )
        {
            if(calEvents.Count() > 0 && !notSubRepetition)
            {
                if(calEvents.First().Calendar_EventID.getRepeatDayCalendarEventComponent() != "7")
                {
                    initializeSubRepetitions(parentCalendarEvent, calEvents);
                }
            } else
            {
                RepetitionWeekDay = dayOfWeek;
                _RepetitionFrequency = Frequency.NONE;
                _RepetitionRange = new TimeLine();
                _EnableRepeat = false;
                _Location = new TilerElements.Location();
                _initializingRange = new TimeLine();
                _DictionaryOfIDAndCalendarEvents = new IDKeyDictionary<string, CalendarEvent>(calEvents);
                _DictionaryOfWeekDayToRepetition = new IDKeyDictionary<int, Repetition>();
            }
        }

        public void initializeSubRepetitions (CalendarEvent parentCalendarEvent, IEnumerable<CalendarEvent> calEvents)
        {
            Dictionary<DayOfWeek, List<CalendarEvent>> dayOfWeekTOCalEVents = Weekdays.ToDictionary(day => day, day => new List<CalendarEvent>());

            List<Repetition> subRepetitions = dayOfWeekTOCalEVents.Where(kvp => kvp.Value.Count > 0).Select(kvp => ((Repetition)new DB_Repetition(parentCalendarEvent, kvp.Value, (int)kvp.Key, true))).ToList();

            this.SubRepetitions = subRepetitions;
        }
    }
}
