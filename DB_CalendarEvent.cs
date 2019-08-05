using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TilerElements;

namespace TilerFront
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
            this.StartDateTime = CalendarEventData.Start;
            this.EndDateTime = CalendarEventData.End;
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
            this.SubEvents = new SubEventDictionary<string, SubCalendarEvent>();
            this._UiParams = CalendarEventData.getUIParam;
            this._DataBlob = CalendarEventData.Notes;
            this._Enabled = CalendarEventData.isEnabled;
            this.isRestricted = CalendarEventData.getIsEventRestricted;
            this._LocationInfo= CalendarEventData.Location;//hack you might need to make copy
            this._UserDeleted = CalendarEventData.getIsUserDeleted;
            this._CompletedCount = CalendarEventData.CompletionCount;
            this._DeletedCount = CalendarEventData.DeletionCount;
            this._ProfileOfProcrastination = procrastinationData;
            this._ProfileOfNow = NowProfileData;
            //this.SubEvents = ((DB_CalendarEventRestricted)CalendarEventData).getSubEvents();
            if (!this._EventRepetition.EnableRepeat)
            {
                foreach (SubCalendarEvent eachSubCalendarEvent in CalendarEventData.AllSubEvents)
                {
                    this.SubEvents.Add(eachSubCalendarEvent.Id, eachSubCalendarEvent);
                }
            }

            //this.SubEvents = CalendarEventData.SubEvents;
            this._otherPartyID = CalendarEventData.ThirdPartyID;// == CalendarEventData.null ? null : otherPartyID.ToString();
            this._Users = CalendarEventData.getAllUsers();//.ToList();
            this._Creator = CalendarEventData.getCreator;
            this._TimeZone = CalendarEventData.getTimeZone;
        }

        public ThirdPartyControl.CalendarTool CalendarType
        {
            set
            {
                this.ThirdPartyTypeInfo = value;
            }
        }
    }
}