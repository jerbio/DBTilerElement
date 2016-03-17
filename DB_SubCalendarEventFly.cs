using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TilerElements;
using System.ComponentModel.DataAnnotations.Schema;
#if NewRigidImplementation
namespace DBTilerElement
{
    [Table("SubCalendarEvents")]
    public class DB_SubCalendarEventFly:SubCalendarEvent
    {
        DB_SubCalendarEventFly()
        {
            CalendarEventRange = new TimeLine();
            BusyFrame = new BusyTimeLine();
            HumaneTimeLine = new BusyTimeLine();
        }
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
            //throw new Exception(message);
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

        #region properties
        /*
        protected ConflictProfile ConflictingEvents;
        protected double EventScore;
        protected BusyTimeLine HumaneTimeLine;
        protected int MiscIntData;
        protected bool MuddledEvent;
        protected BusyTimeLine NonHumaneTimeLine;
        protected ulong OldPreferredIndex;
        protected ulong preferredDayIndex;
        protected ulong UnUsableIndex;
        protected bool Vestige;*/
        

        public new DateTimeOffset Start
        {
            get
            {
                return BusyFrame.Start;
            }
            set
            {
                BusyFrame = new BusyTimeLine(Id, value, BusyFrame.End);
                /*
                if (BusyFrame==null)
                {
                    BusyFrame = new BusyTimeLine(Id, value, BusyFrame.End);
                }
                else
                {
                    BusyFrame = new BusyTimeLine(Id, value, BusyFrame.End);
                }*/
            }
        }

        public new DateTimeOffset End
        {
            get
            {
                return BusyFrame.End;
            }
            set
            {
                BusyFrame = new BusyTimeLine(Id, BusyFrame.Start, value);
                //if (BusyFrame == null)
                //{
                //    BusyFrame = new BusyTimeLine(Id, BusyFrame.Start, value);
                //}
                //else
                //{
                //    BusyFrame = new BusyTimeLine(Id, BusyFrame.Start, value);
                //}
            }
        }

        public DateTimeOffset CalendarEnd
        {
            get
            {
                return CalendarEventRange.End;
            }
            set
            {
                if (CalendarEventRange == null)
                {
                    CalendarEventRange = new TimeLine(BusyFrame.Start, value);
                }
                else
                {
                    CalendarEventRange = new TimeLine(BusyFrame.Start, value);
                }
            }
        }

        public DateTimeOffset CalendarStart
        {
            get
            {
                return CalendarEventRange.Start;
            }
            set
            {
                if (BusyFrame == null)
                {
                    CalendarEventRange = new TimeLine(value, CalendarEventRange.End);
                }
                else
                {
                    CalendarEventRange = new TimeLine(value, CalendarEventRange.End);
                }
            }
        }

        /// <summary>
        /// returns the humane end time i.e ideal start time for a subevent to start
        /// </summary>
        public DateTimeOffset HumaneStart
        {
            get
            {
                return HumaneTimeLine.Start;
            }
            set
            {
                HumaneTimeLine = new BusyTimeLine(Id, value, HumaneTimeLine.End);
            }
        }
        /// <summary>
        /// returns the humane end time i.e ideal end time for a subevent to end
        /// </summary>
        public DateTimeOffset HumaneEnd
        {
            get
            {
                return HumaneTimeLine.End;
            }
            set
            {
                HumaneTimeLine = new BusyTimeLine(Id, HumaneTimeLine.Start, value);
            }
        }

        /// <summary>
        /// returns the NonHumane end time i.e ideal start time for a subevent to start
        /// </summary>
        public DateTimeOffset NonHumaneStart
        {
            get
            {
                return NonHumaneTimeLine.Start;
            }
            set
            {
                NonHumaneTimeLine = new BusyTimeLine(Id, value, NonHumaneTimeLine.End);
            }
        }
        /// <summary>
        /// returns the NonHumane end time i.e ideal end time for a subevent to end
        /// </summary>
        public DateTimeOffset NonHumaneEnd
        {
            get
            {
                return NonHumaneTimeLine.End;
            }
            set
            {
                NonHumaneTimeLine = new BusyTimeLine(Id, NonHumaneTimeLine.Start, value);
            }
        }

        #endregion
    }
}
#endif