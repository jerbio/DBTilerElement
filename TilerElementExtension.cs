using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilerElements;


namespace DBTilerElement
{
    public static class TilerElementExtension
    {
        public static DateTimeOffset JSStartTime = new DateTimeOffset(1970, 1, 1, 0, 0, 0, new TimeSpan());
        //public readonly static string[] ProviderNames = { "Tiler", "Outlook", "Google", "Facebook" };
        public static SubCalEvent ToSubCalEvent(this TilerElements.SubCalendarEvent SubCalendarEventEntry, TilerElements.CalendarEvent CalendarEventEntry = null, bool includeCalendarEvent = true)
        {
            DateTimeOffset CurrentTime = DateTimeOffset.UtcNow;
            SubCalEvent retValue = new SubCalEvent();
            retValue.CreatorId = SubCalendarEventEntry.CreatorId;
            retValue.ThirdPartyType = SubCalendarEventEntry.ThirdpartyType.ToString();
            retValue.ThirdPartyEventID = SubCalendarEventEntry.ThirdPartyID;
            retValue.ThirdPartyUserID = SubCalendarEventEntry.getThirdPartyUserID;
            retValue.ID = SubCalendarEventEntry.getId;
            retValue.CalendarID = SubCalendarEventEntry.SubEvent_ID.getRepeatCalendarEventID();

            retValue.SubCalStartDate = (long)(SubCalendarEventEntry.Start - JSStartTime).TotalMilliseconds;
            retValue.SubCalEndDate = (long)(SubCalendarEventEntry.End - JSStartTime).TotalMilliseconds;
            retValue.SubCalTotalDuration = SubCalendarEventEntry.getActiveDuration;
            retValue.SubCalRigid = SubCalendarEventEntry.isRigid;
            retValue.SubCalAddressDescription = SubCalendarEventEntry.Location?.Description;
            retValue.SubCalAddress = SubCalendarEventEntry.Location?.Address;
            retValue.ThirdPartyEventID = SubCalendarEventEntry.ThirdPartyID;
            retValue.SubCalCalendarName = SubCalendarEventEntry.Name?.NameValue;
            retValue.Notes = SubCalendarEventEntry?.Notes?.UserNote;
            retValue.LocationId = SubCalendarEventEntry.LocationId;

            if (CalendarEventEntry != null)
            {
                retValue.CalRigid = CalendarEventEntry.isRigid;
                retValue.SubCalCalEventStart = (long)(CalendarEventEntry.Start - JSStartTime).TotalMilliseconds;
                retValue.SubCalCalEventEnd = (long)(CalendarEventEntry.End - JSStartTime).TotalMilliseconds;
                retValue.SuggestedDeadline = CalendarEventEntry.DeadlineSuggestion.ToUnixTimeMilliseconds();
                retValue.SleepSuggestedDeadline = CalendarEventEntry.SleepDeadlineSuggestion.ToUnixTimeMilliseconds();

                if (string.IsNullOrEmpty(CalendarEventEntry.ThirdPartyID))
                {

                }
                else
                {
                    retValue.ID = retValue.ThirdPartyEventID;
                }
            }

            retValue.SubCalEventLong = SubCalendarEventEntry.Location?.Longitude?? TilerElements.Location.getDefaultLocation().Longitude;
            retValue.SubCalEventLat = SubCalendarEventEntry.Location?.Latitude ?? TilerElements.Location.getDefaultLocation().Latitude;
            retValue.SubCalCalendarName = SubCalendarEventEntry.getName?.NameValue;
            TilerColor uiColor = SubCalendarEventEntry?.getUIParam?.UIColor;
            if (uiColor != null) { 
                retValue.RColor = uiColor.R;
                retValue.GColor = uiColor.G;
                retValue.BColor = uiColor.B;
                retValue.OColor = uiColor.O;
                retValue.ColorSelection = uiColor.User;
            }
            retValue.isComplete = SubCalendarEventEntry.getIsComplete;
            retValue.isEnabled = SubCalendarEventEntry.isEnabled;
            retValue.Duration = (long)SubCalendarEventEntry.getActiveDuration.TotalMilliseconds;
            retValue.ThirdPartyEventID = SubCalendarEventEntry.ThirdPartyID;
            retValue.EventPreDeadline = (long)SubCalendarEventEntry.getPreDeadline.TotalMilliseconds;
            retValue.Priority = SubCalendarEventEntry.getEventPriority;
            retValue.Conflict = String.Join(",", SubCalendarEventEntry.Conflicts.getConflictingEventIDs());
            retValue.isPaused = SubCalendarEventEntry.isPaused;
            retValue.isPauseAble = SubCalendarEventEntry.StartToEnd.IsDateTimeWithin(CurrentTime) && !SubCalendarEventEntry.isRigid;
            retValue.PauseStart = (long)(SubCalendarEventEntry.Start - JSStartTime).TotalMilliseconds;
            retValue.PauseEnd = (long)(SubCalendarEventEntry.End - JSStartTime).TotalMilliseconds;
            retValue.IsLocked = SubCalendarEventEntry.isLocked;
            retValue.UserLocked = SubCalendarEventEntry.userLocked;
            retValue.isThirdParty = SubCalendarEventEntry.isThirdParty;
            retValue.isReadOnly = SubCalendarEventEntry.isReadOnly;
            retValue.isTardy = SubCalendarEventEntry.isTardy;
            retValue.isProcrastinateAll = SubCalendarEventEntry.isProcrastinateEvent;
            retValue.isAllDay = SubCalendarEventEntry.getActiveDuration >= Utility.LeastAllDaySubeventDuration;
            retValue.isViable = SubCalendarEventEntry.isViable;
            if(SubCalendarEventEntry is GoogleSubCalendarEvent)
            {
                retValue.ConfirmationStatus = (SubCalendarEventEntry as GoogleSubCalendarEvent).TileStatus.ToString();
                retValue.UserAcceptanceStatus = (SubCalendarEventEntry as GoogleSubCalendarEvent).UserStatus.ToString();
            }

            if (CalendarEventEntry!=null && includeCalendarEvent)
            {
                retValue.CalEvent = CalendarEventEntry.ToCalEvent(includeSubevents: false);
            }
            
            return retValue;
        }



        public static SubCalEvent ToSubCalEvent(this TilerElements.PausedTimeLineEntry pausedTimeline, TilerElements.CalendarEvent CalendarEventEntry, bool includeCalendarEvent = true)
        {
            SubCalendarEvent pausedSubEvent = CalendarEventEntry.getSubEvent(pausedTimeline.getSubEventId());
            DateTimeOffset CurrentTime = DateTimeOffset.UtcNow;
            SubCalEvent retValue = new SubCalEvent();
            retValue.CreatorId = CalendarEventEntry.CreatorId;
            retValue.ThirdPartyType = CalendarEventEntry.ThirdpartyType.ToString();
            retValue.ThirdPartyEventID = CalendarEventEntry.ThirdPartyID;
            retValue.ID = pausedTimeline.Id;
            retValue.CalendarID = CalendarEventEntry.Calendar_EventID.getRepeatCalendarEventID();

            retValue.SubCalStartDate = (long)(pausedTimeline.Start - JSStartTime).TotalMilliseconds;
            retValue.SubCalEndDate = (long)(pausedTimeline.End - JSStartTime).TotalMilliseconds;
            retValue.SubCalTotalDuration = pausedTimeline.TimelineSpan;
            retValue.SubCalRigid = CalendarEventEntry.isRigid;
            retValue.SubCalAddressDescription = pausedSubEvent?.Location?.Description;
            retValue.SubCalAddress = pausedSubEvent?.Location?.Address;
            retValue.ThirdPartyEventID = pausedSubEvent.ThirdPartyID;
            retValue.SubCalCalendarName = pausedSubEvent.Name?.NameValue;
            retValue.Notes = pausedSubEvent?.Notes?.UserNote;
            retValue.LocationId = pausedSubEvent.LocationId;

            if (CalendarEventEntry != null)
            {
                retValue.CalRigid = CalendarEventEntry.isRigid;
                retValue.SubCalCalEventStart = (long)(CalendarEventEntry.Start - JSStartTime).TotalMilliseconds;
                retValue.SubCalCalEventEnd = (long)(CalendarEventEntry.End - JSStartTime).TotalMilliseconds;
                retValue.SuggestedDeadline = CalendarEventEntry.DeadlineSuggestion.ToUnixTimeMilliseconds();
                retValue.SleepSuggestedDeadline = CalendarEventEntry.SleepDeadlineSuggestion.ToUnixTimeMilliseconds();
                if (string.IsNullOrEmpty(CalendarEventEntry.ThirdPartyID))
                {

                }
                else
                {
                    retValue.ID = retValue.ThirdPartyEventID;
                }
            }

            retValue.SubCalEventLong = pausedSubEvent.Location?.Longitude??TilerElements.Location.getDefaultLocation().Longitude;
            retValue.SubCalEventLat = pausedSubEvent.Location?.Latitude ?? TilerElements.Location.getDefaultLocation().Latitude;
            retValue.SubCalCalendarName = pausedSubEvent.getName?.NameValue;
            TilerColor uiColor = TilerColor.pausedUIColor();
            if (uiColor != null)
            {
                retValue.RColor = uiColor.R;
                retValue.GColor = uiColor.G;
                retValue.BColor = uiColor.B;
                retValue.OColor = uiColor.O;
                retValue.ColorSelection = uiColor.User;
            }
            retValue.isComplete = false;
            retValue.isEnabled = true;
            retValue.Duration = (long)pausedTimeline.TimelineSpan.TotalMilliseconds;
            retValue.ThirdPartyEventID = pausedSubEvent.ThirdPartyID;
            retValue.EventPreDeadline = (long)pausedSubEvent.getPreDeadline.TotalMilliseconds;
            retValue.Priority = pausedSubEvent.getEventPriority;
            retValue.Conflict = String.Join(",", pausedSubEvent.Conflicts.getConflictingEventIDs());
            retValue.isPaused = false;
            retValue.isPauseAble = false;
            retValue.PauseStart = (long)(pausedTimeline.Start - JSStartTime).TotalMilliseconds;
            retValue.PauseEnd = (long)(pausedTimeline.End - JSStartTime).TotalMilliseconds;
            retValue.IsLocked = true;
            retValue.UserLocked = false;
            retValue.isThirdParty = pausedSubEvent.isThirdParty;
            retValue.isReadOnly = true;
            retValue.isTardy = false;
            retValue.isProcrastinateAll = false;
            retValue.isAllDay = pausedSubEvent.getActiveDuration >= Utility.LeastAllDaySubeventDuration;

            if (CalendarEventEntry != null && includeCalendarEvent)
            {
                retValue.CalEvent = CalendarEventEntry.ToCalEvent(includeSubevents: false);
            }

            return retValue;
        }

        public static CalEvent ToCalEvent(this TilerElements.CalendarEvent CalendarEventEntry, TilerElements.TimeLine Range = null, bool includeSubevents = true)
        {
            CalEvent retValue = new CalEvent();
            retValue.CreatorId = CalendarEventEntry.CreatorId;
            retValue.ThirdPartyUserID = CalendarEventEntry.getThirdPartyUserID;
            retValue.ID = CalendarEventEntry.getId;
            retValue.ThirdPartyType = CalendarEventEntry.ThirdpartyType.ToString();
            retValue.CalendarName = CalendarEventEntry.getName?.NameValue;
            retValue.StartDate = (long)(CalendarEventEntry.Start - JSStartTime).TotalMilliseconds;
            retValue.EndDate = (long)(CalendarEventEntry.End - JSStartTime).TotalMilliseconds;
            retValue.TotalDuration = CalendarEventEntry.getActiveDuration;
            retValue.Rigid = CalendarEventEntry.isRigid;
            retValue.AddressDescription = CalendarEventEntry.Location?.Description;
            retValue.Address = CalendarEventEntry.Location?.Address;
            retValue.Longitude = CalendarEventEntry.Location?.Longitude ?? TilerElements.Location.getDefaultLocation().Longitude;
            retValue.Latitude = CalendarEventEntry.Location?.Latitude ?? TilerElements.Location.getDefaultLocation().Longitude;
            retValue.NumberOfSubEvents = CalendarEventEntry.NumberOfSplit;
            retValue.LocationId = CalendarEventEntry.LocationId;
            if (CalendarEventEntry.getUIParam!=null && CalendarEventEntry.getUIParam.UIColor!=null)
            {
                retValue.RColor = CalendarEventEntry.getUIParam.UIColor.R;
                retValue.GColor = CalendarEventEntry.getUIParam.UIColor.G;
                retValue.BColor = CalendarEventEntry.getUIParam.UIColor.B;
                retValue.OColor = CalendarEventEntry.getUIParam.UIColor.O;
                retValue.ColorSelection = CalendarEventEntry.getUIParam.UIColor.User;
            }
            
            retValue.NumberOfCompletedTasks = CalendarEventEntry.CompletionCount;
            retValue.NumberOfDeletedEvents = CalendarEventEntry.DeletionCount;
            retValue.OtherPartyID = CalendarEventEntry.ThirdPartyID;
            retValue.Notes = CalendarEventEntry?.Notes?.UserNote;
            retValue.isThirdParty = CalendarEventEntry.isThirdParty;
            retValue.isReadOnly = CalendarEventEntry.isReadOnly;
            retValue.SuggestedDeadline = CalendarEventEntry.DeadlineSuggestion.ToUnixTimeMilliseconds();
            retValue.isProcrastinateAll = CalendarEventEntry.isProcrastinateEvent;
            retValue.LastSuggestedDeadline = CalendarEventEntry.LastDeadlineSuggestion.ToUnixTimeMilliseconds();
            retValue.SleepSuggestedDeadline = CalendarEventEntry.SleepDeadlineSuggestion.ToUnixTimeMilliseconds();
            TimeSpan FreeTimeLeft = CalendarEventEntry.RangeSpan - CalendarEventEntry.getActiveDuration;
            long TickTier1 = (long)(FreeTimeLeft.Ticks * (.667));
            long TickTier2 = (long)(FreeTimeLeft.Ticks * (.865));
            long TickTier3 = (long)(FreeTimeLeft.Ticks * (1));
            retValue.Tiers = new long[] { TickTier1, TickTier2, TickTier3 };
            bool canDoNow = false;
            if(!CalendarEventEntry.IsFromRecurring)
            {
                canDoNow = (CalendarEventEntry.AutoDeletionCount + CalendarEventEntry.DeletionCount + CalendarEventEntry.CompletionCount) < CalendarEventEntry.NumberOfSplit;
            } else
            {
                canDoNow = CalendarEventEntry.End > DateTimeOffset.UtcNow;
            }

            retValue.canDoNow = canDoNow;
            if (includeSubevents)
            {
                if (Range != null)
                {
                    retValue.AllSubCalEvents = CalendarEventEntry.ActiveSubEvents.Where(obj => obj.StartToEnd.InterferringTimeLine(Range) != null).Select(obj => obj.ToSubCalEvent(CalendarEventEntry)).ToList();
                }
                else
                {
                    retValue.AllSubCalEvents = CalendarEventEntry.ActiveSubEvents.Select(obj => obj.ToSubCalEvent(CalendarEventEntry)).ToList();
                }

                if(CalendarEventEntry.PausedTimeLines.Count > 0)
                {
                    retValue.AllSubCalEvents = CalendarEventEntry.PausedTimeLines.Where(pausedImeline => pausedImeline.IsFinal && CalendarEventEntry.getSubEvent(pausedImeline.getSubEventId())!=null).Select(pausedImeline => pausedImeline.ToSubCalEvent(CalendarEventEntry)).Concat(retValue.AllSubCalEvents).ToList();
                }
            }
            retValue.IsLocked = CalendarEventEntry.isLocked;
            retValue.UserLocked = CalendarEventEntry.userLocked;
            return retValue;
        }


        public static CalEvent ToDeletedCalEvent(this TilerElements.CalendarEvent CalendarEventEntry, TilerElements.TimeLine Range = null)
        {
            CalEvent retValue = new CalEvent();
            retValue.CreatorId = CalendarEventEntry.CreatorId;
            retValue.ThirdPartyUserID = CalendarEventEntry.getThirdPartyUserID;

            retValue.ID = CalendarEventEntry.getId;
            retValue.ThirdPartyType = CalendarEventEntry.ThirdpartyType.ToString();
            retValue.CalendarName = CalendarEventEntry.getName?.NameValue;
            retValue.StartDate = (long)(CalendarEventEntry.Start - JSStartTime).TotalMilliseconds;
            retValue.EndDate = (long)(CalendarEventEntry.End - JSStartTime).TotalMilliseconds;
            retValue.TotalDuration = CalendarEventEntry.getActiveDuration;
            retValue.Rigid = CalendarEventEntry.isRigid;
            retValue.AddressDescription = CalendarEventEntry.Location.Description;
            retValue.Address = CalendarEventEntry.Location.Address;
            retValue.Longitude = CalendarEventEntry.Location.Longitude;
            retValue.Latitude = CalendarEventEntry.Location.Latitude;
            retValue.NumberOfSubEvents = CalendarEventEntry.AllSubEvents.Count();// CalendarEventEntry.NumberOfSplit;// AllSubEvents.Count();
            retValue.RColor = CalendarEventEntry.getUIParam.UIColor.R;
            retValue.GColor = CalendarEventEntry.getUIParam.UIColor.G;
            retValue.BColor = CalendarEventEntry.getUIParam.UIColor.B;
            retValue.OColor = CalendarEventEntry.getUIParam.UIColor.O;
            retValue.ColorSelection = CalendarEventEntry.getUIParam.UIColor.User;
            retValue.NumberOfCompletedTasks = CalendarEventEntry.CompletionCount;
            retValue.NumberOfDeletedEvents = CalendarEventEntry.DeletionCount;
            retValue.OtherPartyID = CalendarEventEntry.ThirdPartyID;
            retValue.Notes = CalendarEventEntry.Notes.UserNote;
            retValue.isThirdParty = CalendarEventEntry.isThirdParty;
            retValue.isReadOnly = true;

            TimeSpan FreeTimeLeft = CalendarEventEntry.RangeSpan - CalendarEventEntry.getActiveDuration;
            long TickTier1 = (long)(FreeTimeLeft.Ticks * (.667));
            long TickTier2 = (long)(FreeTimeLeft.Ticks * (.865));
            long TickTier3 = (long)(FreeTimeLeft.Ticks * (1));
            retValue.Tiers = new long[] { TickTier1, TickTier2, TickTier3 };
            if (Range != null)
            {
                retValue.AllSubCalEvents = CalendarEventEntry.AllSubEvents.Where(obj=>!obj.isActive).Where(obj => obj.StartToEnd.InterferringTimeLine(Range) != null).Select(obj => obj.ToSubCalEvent(CalendarEventEntry)).ToList();
            }
            else
            {
                retValue.AllSubCalEvents = CalendarEventEntry.AllSubEvents.Where(obj => !obj.isActive).Select(obj => obj.ToSubCalEvent(CalendarEventEntry)).ToList();
            }

            return retValue;
        }

        public static Location ToLocationModel(this TilerElements.Location LocationEntry)
        {
            Location retValue = new Location();
            retValue.Address = LocationEntry.Address;
            retValue.Tag = LocationEntry.Description;
            retValue.Long = LocationEntry.Longitude;
            retValue.Lat = LocationEntry.Latitude;
            retValue.isNull = LocationEntry.isNull;
            retValue.isVerified = LocationEntry.IsVerified;
            retValue.isAmbiguous = LocationEntry.IsAmbiguous;
            retValue.LocationId = LocationEntry.Id;
            return retValue;
        }
    }
}
