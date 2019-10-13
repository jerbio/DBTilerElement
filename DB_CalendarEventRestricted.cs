using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TilerElements;

namespace DBTilerElement
{
    public class DB_CalendarEventRestricted : CalendarEventRestricted
    {
        public DB_CalendarEventRestricted(CalendarEvent CalendarEventData, RestrictionProfile restrictionData, ReferenceNow now)
        {
            //CalendarEventRestricted MyCalendarEventCopy = CalendarEventData.new CalendarEventRestricted();
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
            this._AverageTimePerSplit= CalendarEventData.AverageTimeSpanPerSubEvent;
            this.UniqueID = CalendarEventData.Calendar_EventID;//hack
            //this.EventSequence = CalendarEventData.EventSequence;
            this._SubEvents = new SubEventDictionary<string, SubCalendarEvent>();
            this._UiParams = CalendarEventData.getUIParam;
            this._DataBlob = CalendarEventData.Notes;
            this._Enabled = CalendarEventData.isEnabled;
            //this.isRestricted = CalendarEventData.isEventRestricted;
            this._LocationInfo= CalendarEventData.Location;//hack you might need to make copy
            this._ProfileOfProcrastination = CalendarEventData.getProcrastinationInfo;
            this._AutoDeleted = CalendarEventData.getIsUserDeleted;
            this._CompletedCount = CalendarEventData.CompletionCount;
            this._DeletedCount = CalendarEventData.DeletionCount;
            this._ProfileOfRestriction = restrictionData;
            this.isRestricted = true;
            //this.SubEvents = ((DB_CalendarEventRestricted)CalendarEventData).getSubEvents();
            this._Now = now;

            if (!this._EventRepetition.EnableRepeat)
            {
                foreach (SubCalendarEventRestricted eachSubCalendarEvent in CalendarEventData.AllSubEvents)
                {
                    this._SubEvents.Add(eachSubCalendarEvent.Id, eachSubCalendarEvent);
                    eachSubCalendarEvent.ParentCalendarEvent = this;
                }
            }
            this._otherPartyID = CalendarEventData.ThirdPartyID;// == CalendarEventData.null ? null : otherPartyID.ToString();
            this._Users = CalendarEventData.getAllUsers();
            this._Creator = CalendarEventData.getCreator;
            this._TimeZone = CalendarEventData.getTimeZone;
            this._ProfileOfNow = CalendarEventData.getNowInfo;
            //return MyCalendarEventCopy;
        }
    }
}