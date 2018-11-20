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
            this.EventDuration = CalendarEventData.getActiveDuration;
            this._Name = CalendarEventData.getName;
            this.StartDateTime = CalendarEventData.Start;
            this.EndDateTime = CalendarEventData.End;
            this.EventPreDeadline = CalendarEventData.getPreDeadline;
            this.PrepTime = CalendarEventData.getPreparation;
            this.Priority = CalendarEventData.getEventPriority;
            //this.RepetitionFlag = CalendarEventData.RepetitionStatus;
            this.EventRepetition = (CalendarEventData).Repeat;// EventRepetition != CalendarEventData.null ? EventRepetition.CreateCopy() : EventRepetition;
            this.Complete = CalendarEventData.getIsComplete;
            this.RigidSchedule = CalendarEventData.isLocked;//hack
            this.Splits = CalendarEventData.NumberOfSplit;
            this._AverageTimePerSplit= CalendarEventData.AverageTimeSpanPerSubEvent;
            this.UniqueID = CalendarEventData.Calendar_EventID;//hack
            //this.EventSequence = CalendarEventData.EventSequence;
            this.SubEvents = new Dictionary<EventID, SubCalendarEvent>();
            this.UiParams = CalendarEventData.getUIParam;
            this.DataBlob = CalendarEventData.Notes;
            this.Enabled = CalendarEventData.isEnabled;
            //this.isRestricted = CalendarEventData.isEventRestricted;
            this.LocationInfo= CalendarEventData.Location;//hack you might need to make copy
            this.ProfileOfProcrastination = CalendarEventData.getProcrastinationInfo;
            this.DeadlineElapsed = CalendarEventData.getIsDeadlineElapsed;
            this.UserDeleted = CalendarEventData.getIsUserDeleted;
            this.CompletedCount = CalendarEventData.CompletionCount;
            this.DeletedCount = CalendarEventData.DeletionCount;
            this.ProfileOfRestriction = restrictionData;
            this.isRestricted = true;
            //this.SubEvents = ((DB_CalendarEventRestricted)CalendarEventData).getSubEvents();
            this._Now = now;

            if (!this.EventRepetition.Enable)
            {
                foreach (SubCalendarEventRestricted eachSubCalendarEvent in CalendarEventData.AllSubEvents)
                {
                    this.SubEvents.Add(eachSubCalendarEvent.SubEvent_ID, eachSubCalendarEvent);
                }
            }
            this.otherPartyID = CalendarEventData.ThirdPartyID;// == CalendarEventData.null ? null : otherPartyID.ToString();
            this._Users = CalendarEventData.getAllUsers();
            this._Creator = CalendarEventData.getCreator;
            this._TimeZone = CalendarEventData.getTimeZone;
            //return MyCalendarEventCopy;
        }
    }
}