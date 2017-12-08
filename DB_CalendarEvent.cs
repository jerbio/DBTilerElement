using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TilerElements;

namespace TilerFront
{
    public class DB_CalendarEventExtra : CalendarEvent
    {
        public DB_CalendarEventExtra() : base()
        {

        }
        public DB_CalendarEventExtra(CalendarEvent CalendarEventData, Procrastination procrastinationData, NowProfile NowProfileData)
        {
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
            this.RigidSchedule = CalendarEventData.getRigid;//hack
            this.Splits = CalendarEventData.NumberOfSplit;
            this._AverageTimePerSplit = CalendarEventData.AverageTimeSpanPerSubEvent;
            this.UniqueID = CalendarEventData.Calendar_EventID;//hack
            //this.EventSequence = CalendarEventData.EventSequence;
            this.SubEvents = new Dictionary<EventID, SubCalendarEvent>();
            this.UiParams = CalendarEventData.getUIParam;
            this.DataBlob = CalendarEventData.Notes;
            this.Enabled = CalendarEventData.isEnabled;
            this.isRestricted = CalendarEventData.getIsEventRestricted;
            this.LocationInfo= CalendarEventData.Location;//hack you might need to make copy
            this.ProfileOfProcrastination = CalendarEventData.getProcrastinationInfo;
            this.DeadlineElapsed = CalendarEventData.getIsDeadlineElapsed;
            this.UserDeleted = CalendarEventData.getIsUserDeleted;
            this.CompletedCount = CalendarEventData.CompletionCount;
            this.DeletedCount = CalendarEventData.DeletionCount;
            this.ProfileOfProcrastination = procrastinationData;
            this.ProfileOfNow = NowProfileData;
            //this.SubEvents = ((DB_CalendarEventRestricted)CalendarEventData).getSubEvents();
            if (!this.EventRepetition.Enable)
            {
                foreach (SubCalendarEvent eachSubCalendarEvent in CalendarEventData.AllSubEvents)
                {
                    this.SubEvents.Add(eachSubCalendarEvent.SubEvent_ID, eachSubCalendarEvent);
                }
            }

            //this.SubEvents = CalendarEventData.SubEvents;
            this.otherPartyID = CalendarEventData.ThirdPartyID;// == CalendarEventData.null ? null : otherPartyID.ToString();
            this._Users = CalendarEventData.getAllUsers();//.ToList();
            this._Creator = CalendarEventData.getCreator;
            this._TimeZone = CalendarEventData.getTimeZone;
        }
    }
}