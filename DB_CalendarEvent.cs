using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TilerElements;

namespace DBTilerElement
{
    public class DB_CalendarEvent : CalendarEvent
    {
        protected DB_CalendarEvent() : base()
        {

        }
        public DB_CalendarEvent(CalendarEvent CalendarEventData, Procrastination procrastinationData, NowProfile NowProfileData)
        {
            this._EventDuration = CalendarEventData.getActiveDuration;
            this._Name = CalendarEventData.getName;
            this.updateStartTime( CalendarEventData.Start);
            this.updateEndTime( CalendarEventData.End);
            this._EventPreDeadline = CalendarEventData.getPreDeadline;
            this._PrepTime = CalendarEventData.getPreparation;
            this._Priority = CalendarEventData.getEventPriority;
            //this.RepetitionFlag = CalendarEventData.RepetitionStatus;
            this._EventRepetition = (CalendarEventData).Repeat;// EventRepetition != CalendarEventData.null ? EventRepetition.CreateCopy() : EventRepetition;
            this._Complete = CalendarEventData.getIsComplete;
            this._RigidSchedule = CalendarEventData.isRigid;//hack
            this._Splits = CalendarEventData.NumberOfSplit;
            this._AverageTimePerSplit = CalendarEventData.AverageTimeSpanPerSubEvent;
            this.UniqueID = CalendarEventData.Calendar_EventID;//hack
            //this.EventSequence = CalendarEventData.EventSequence;
            this._SubEvents = new SubEventDictionary();
            this._UiParams = CalendarEventData.getUIParam;
            this._DataBlob = CalendarEventData.Notes;
            this._Enabled = CalendarEventData.isEnabled;
            this._isEventRestricted = CalendarEventData.getIsEventRestricted;
            this._LocationInfo= CalendarEventData.Location;//hack you might need to make copy
            this._AutoDeleted = CalendarEventData.isAutoDeleted;
            this._CompletedCount = CalendarEventData.CompletionCount;
            this._DeletedCount = CalendarEventData.DeletionCount;
            this._ProfileOfProcrastination = procrastinationData;
            this._ProfileOfNow = NowProfileData;
            //this.SubEvents = ((DB_CalendarEventRestricted)CalendarEventData).getSubEvents();
            if (this._EventRepetition!=null && !this._EventRepetition.EnableRepeat)
            {
                foreach (SubCalendarEvent eachSubCalendarEvent in CalendarEventData.AllSubEvents)
                {
                    this._SubEvents.Add(eachSubCalendarEvent.Id, eachSubCalendarEvent);
                }
            } else if(this._EventRepetition == null)
            {
                isRepeatLoaded_DB = false;
            }

            //this.SubEvents = CalendarEventData.SubEvents;
            this._otherPartyID = CalendarEventData.ThirdPartyID;// == CalendarEventData.null ? null : otherPartyID.ToString();
            this._Users = CalendarEventData.getAllUsers();//.ToList();
            this._Creator = CalendarEventData.getCreator;
            this._TimeZone = CalendarEventData.getTimeZone;
            this.Now = CalendarEventData.Now;
        }

        public ThirdPartyControl.CalendarTool CalendarType
        {
            set
            {
                this.ThirdPartyTypeInfo = value;
            }
        }

        public void setPausedTimeSlots(List<PausedTimeLineEntry> pausedTimeSlots)
        {
            foreach(var pausedTimeSlot in pausedTimeSlots)
            {
                addToPausedTimeSlot(pausedTimeSlot);
            }
        }
    }
}