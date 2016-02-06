using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TilerElements;
#if NewRigidImplementation
namespace DBTilerElement
{
    public class DB_SubCalendarEventFly:SubCalendarEvent
    {
        DB_SubCalendarEventFly()
        { }
        internal DB_SubCalendarEventFly(EventID EventIDData, string Name, DateTimeOffset StartData, DateTimeOffset EndData, int PriorityData, Location_Elements LocationData, DateTimeOffset OriginalStartData, TimeSpan EventPrepTimeData, TimeSpan Event_PreDeadlineData, bool EventRigidFlagData, EventDisplay UiData, MiscData NoteData, bool CompletionFlagData, Procrastination ProcrastinationData, TimeLine CalendarEventRangeData, bool FromRepeatFlagData, bool ElapsedFlagData, bool EnabledFlagData, List<string> UserIDData,long Sequence)
        {
            string message = "Halt JEROME !!!!!. This was a commit knowing this error will happen" +
" You did this because you want to figure out your next steps.\n"
+ " You deleted all refereneces to the NowProfile in SubCalendarEVents and TilerEVents because they were inherited from TIler Events.\n"
+ "You did this because you think it was not needed and could easily be stored in the calendar event object. Since the calendar object can explicitly store a deviating subcalendar event and update the calculated rigid event with the deviation.\n"
+ "Beware Jerome of the case where a repeating rigid event gets created and then now is pressed. Tiler needs to know which rigid event was pressed to accomplish this now activity\n"
+ " You deleted the now profile because it was making the xml file too big and was hampering read performnace\n"
+ " You realized that non-rigid subevents still get persisted and are not calculated on the fly which is unlike their rigid counterparts(I havent tested the latter part because, but this branch is called newrigidimplementation aka on the fly rigid calculations).\n"
+ " You might want to resdesign the calls for the creation of non-rigid subevents to be calculated on the fly";
            throw new Exception(message);
            this.BusyFrame = new BusyTimeLine(EventIDData.ToString(), StartData, EndData);
            this.CalendarEventRange = CalendarEventRangeData;
            this.FromRepeatEvent = FromRepeatFlagData;
            this.EventName = Name;
            this.EventDuration = BusyFrame.BusyTimeSpan;
            this.Complete = CompletionFlagData;
            this.ConflictingEvents = new ConflictProfile();
            this.DataBlob = NoteData;
            this.DeadlineElapsed = ElapsedFlagData;
            this.Enabled = EnabledFlagData;
            this.StartDateTime = StartData;
            this.EndDateTime = EndData;
            this.EventPreDeadline = Event_PreDeadlineData;
            this.RepetitionSequence = Sequence;
            this.LocationInfo = LocationData;
            //this.OldPreferredIndex = mySubCalEvent.OldUniversalIndex;
            //this.otherPartyID = mySubCalEvent.ThirdPartyID;
            //this.preferredDayIndex = mySubCalEvent.UniversalDayIndex;
            this.PrepTime = EventPrepTimeData;
            this.Priority = PriorityData;
            //this.ProfileOfNow = NowProfileData;
            this.ProfileOfProcrastination = ProcrastinationData;
            //this.RepetitionFlag = mySubCalEvent.FromRepeat;
            this.RigidSchedule = EventRigidFlagData;

            this.UiParams = UiData;
            this.UniqueID = EventIDData;

            this.UserIDs = UserIDData;
            this.OriginalStart = OriginalStartData;
        }

        internal void InitializeDisabled(SubCalendarEvent SubCalendarEventData)
        {
            if (!SubCalendarEventData.isEnabled)
            {
                TimeSpan SPanShift = SubCalendarEventData.Start - this.Start;
                this.shiftEvent(SPanShift, true);
                this.Enabled = SubCalendarEventData.isEnabled;
                return;
            }
            throw new Exception("Trying to set undelete event as deleted, check DB_SubCalendarEventFly");
        }

        internal void InitializeNowProfile(SubCalendarEvent SubCalendarEventData)
        {
            return;
        }

        internal void InitializeCompleted(SubCalendarEvent SubCalendarEventData)
        {
            if (SubCalendarEventData.isComplete)
            {
                TimeSpan SPanShift = SubCalendarEventData.Start - this.Start;
                this.shiftEvent(SPanShift, true);
                this.Complete = SubCalendarEventData.isComplete;
                return;
            }
            throw new Exception("Trying to set uncomplete event as completed, check DB_SubCalendarEventFly");
        }
    }
}
#endif