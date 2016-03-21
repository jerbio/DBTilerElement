﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TilerElements;

namespace DBTilerElement
{
    public class DB_CalendarEventRestricted : CalendarEventRestricted//, IRestrictedEvent, IDB_CalendarEvent
    {
        DB_CalendarEventRestricted()
        {
            
        }
        public DB_CalendarEventRestricted(CalendarEvent CalendarEventData, RestrictionProfile restrictionData)
        {
            //CalendarEventRestricted MyCalendarEventCopy = CalendarEventData.new CalendarEventRestricted();
            this.EventDuration = CalendarEventData.Duration;
            
            this.StartDateTime = CalendarEventData.Start;
            this.EndDateTime = CalendarEventData.End;
            this.EventPreDeadline = CalendarEventData.PreDeadline;
            this.PrepTime = CalendarEventData.Preparation;
            this.Priority = CalendarEventData.EventPriority;
            //this.RepetitionFlag = CalendarEventData.RepetitionStatus;
            this.EventRepetition = (CalendarEventData).Repeat;// EventRepetition != CalendarEventData.null ? EventRepetition.CreateCopy() : EventRepetition;
            this.Complete = CalendarEventData.isComplete;
            this.RigidSchedule = CalendarEventData.Rigid;//hack
            this.Splits = CalendarEventData.NumberOfSplit;
            this.TimePerSplit = CalendarEventData.EachSplitTimeSpan;
            this.UniqueID = CalendarEventData.Calendar_EventID;//hack
            //this.EventSequence = CalendarEventData.EventSequence;
            this.SubEvents = new Dictionary<EventID, SubCalendarEvent>();
            this.UiParams = CalendarEventData.UIParam;
            this.DataBlob = CalendarEventData.Notes;
            this.Enabled = CalendarEventData.isEnabled;
            //this.isRestricted = CalendarEventData.isEventRestricted;
            this.LocationInfo= CalendarEventData.Location;//hack you might need to make copy
            this.ProfileOfProcrastination = CalendarEventData.ProcrastinationInfo;
            this.DeadlineElapsed = CalendarEventData.isDeadlineElapsed;
            this.UserDeleted = CalendarEventData.isUserDeleted;
            this.CompletedCount = CalendarEventData.CompletionCount;
            this.DeletedCount = CalendarEventData.DeletionCount;
            this.ProfileOfRestriction = restrictionData;
            //this.SubEvents = ((DB_CalendarEventRestricted)CalendarEventData).getSubEvents();
            this.NameOfEvent = new EventName(this.UniqueID, CalendarEventData.Name);
            if (!this.EventRepetition.Enable)
            {
                foreach (SubCalendarEventRestricted eachSubCalendarEvent in CalendarEventData.AllSubEvents)
                {
                    this.SubEvents.Add(eachSubCalendarEvent.SubEvent_ID, eachSubCalendarEvent);
                }
            }
            this.otherPartyID = CalendarEventData.ThirdPartyID;// == CalendarEventData.null ? null : otherPartyID.ToString();
            this.UserIDs = CalendarEventData.getAllUserIDs();//.ToList();
            //return MyCalendarEventCopy;
        }
    }
}