﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TilerElements;

namespace DBTilerElement
{
    public class DB_SubCalendarEventRestricted:SubCalendarEventRestricted
    {
        public DB_SubCalendarEventRestricted(SubCalendarEvent mySubCalEvent, DB_RestrictionProfile restrictionData)
        {
            this.BusyFrame = mySubCalEvent.ActiveSlot;
            this.HardCalendarEventRange =mySubCalEvent.getCalendarEventRange;
            this.ProfileOfRestriction = restrictionData;
            this.OldPreferredIndex = mySubCalEvent.UniversalDayIndex;
            this.otherPartyID = mySubCalEvent.ThirdPartyID;
            this.StartDateTime = mySubCalEvent.Start;
            this.EndDateTime = mySubCalEvent.End;
            



            //this.CalendarEventRange = CalendarEventRange.CreateCopy();
            this.Complete = mySubCalEvent.isComplete;
            this.ConflictingEvents = mySubCalEvent.Conflicts;
            this.DataBlob = mySubCalEvent.Notes;
            this.DeadlineElapsed = mySubCalEvent.isDeadlineElapsed;
            this.Enabled = mySubCalEvent.isEnabled;
            
            this.EventDuration = mySubCalEvent.ActiveDuration;
            this.EventName = mySubCalEvent.Name;
            this.EventPreDeadline = mySubCalEvent.PreDeadline;
            //this.EventScore = mySubCalEvent.Score;
            //this.EventSequence = mySubCalEvent.EventSequence.CreateCopy();
            this.RepetitionFlag= mySubCalEvent.FromRepeat;
            //this.HumaneTimeLine = mySubCalEvent.hum HumaneTimeLine.CreateCopy();
            //this.InterferringEvents = mySubCalEvent.inter
            this.isRestricted = true;
            this.Vestige = mySubCalEvent.isVestige;
            this.LocationInfo = mySubCalEvent.myLocation;
            this.MiscIntData = mySubCalEvent.IntData;
            //this.NonHumaneTimeLine = mySubCalEvent.NonHumaneTimeLine.CreateCopy();
            this.PrepTime = mySubCalEvent.Preparation;
            this.Priority = mySubCalEvent.EventPriority;
            this.RepetitionFlag = mySubCalEvent.FromRepeat;
            this.RigidSchedule = mySubCalEvent.Rigid;

            this.UiParams = mySubCalEvent.UIParam;
            this.UniqueID = mySubCalEvent.SubEvent_ID;
            this.UnUsableIndex = 0;
            this.UserDeleted = mySubCalEvent.isUserDeleted;
            this.UserIDs = mySubCalEvent.getAllUserIDs();
            initializeCalendarEventRange(restrictionData, this.HardCalendarEventRange);
        }

        public TimeSpan UsedTime
        {
            set
            {
                this._UsedTime = value;
            }
            get
            {
                return this._UsedTime;
            }
        }

        public DateTimeOffset PauseTime
        {
            set
            {
                this._PauseTime = value;
            }
            get
            {
                return this._PauseTime;
            }
        }
    }
}