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
        public static TimeSpan StartOfTimeTimeSpan = JSStartTime - new DateTimeOffset(0, new TimeSpan());
        //public readonly static string[] ProviderNames = { "Tiler", "Outlook", "Google", "Facebook" };
        public static SubCalEvent ToSubCalEvent(this TilerElements.SubCalendarEvent SubCalendarEventEntry, TilerElements.CalendarEvent CalendarEventEntry = null)
        {
            DateTimeOffset CurrentTime = DateTimeOffset.UtcNow;
            SubCalEvent retValue = new SubCalEvent();
            retValue.ThirdPartyUserID = SubCalendarEventEntry.getCreator.Id;
            retValue.ThirdPartyType = SubCalendarEventEntry.ThirdpartyType.ToString();
            retValue.ThirdPartyEventID = SubCalendarEventEntry.ThirdPartyID;
            retValue.ID = SubCalendarEventEntry.getId;
            retValue.CalendarID = SubCalendarEventEntry.SubEvent_ID.getRepeatCalendarEventID();

            retValue.SubCalStartDate = (long)(SubCalendarEventEntry.Start - JSStartTime).TotalMilliseconds;
            retValue.SubCalEndDate = (long)(SubCalendarEventEntry.End - JSStartTime).TotalMilliseconds;
            retValue.SubCalTotalDuration = SubCalendarEventEntry.getActiveDuration;
            retValue.SubCalRigid = SubCalendarEventEntry.isRigid;
            retValue.SubCalAddressDescription = SubCalendarEventEntry.Location.Description;
            retValue.SubCalAddress = SubCalendarEventEntry.Location.Address;
            retValue.ThirdPartyEventID = SubCalendarEventEntry.ThirdPartyID;

            if (CalendarEventEntry != null)
            {
                retValue.CalRigid = CalendarEventEntry.isRigid;
                retValue.SubCalCalendarName = CalendarEventEntry.getName.NameValue;
                retValue.SubCalCalEventStart = (long)(CalendarEventEntry.Start - JSStartTime).TotalMilliseconds;
                retValue.SubCalCalEventEnd = (long)(CalendarEventEntry.End - JSStartTime).TotalMilliseconds;
                retValue.Notes = CalendarEventEntry.Notes.UserNote;

                if (string.IsNullOrEmpty(CalendarEventEntry.ThirdPartyID))
                {

                }
                else
                {
                    retValue.ID = retValue.ThirdPartyEventID;
                }
            }

            retValue.SubCalEventLong = SubCalendarEventEntry.Location.Longitude;
            retValue.SubCalEventLat = SubCalendarEventEntry.Location.Latitude;
            retValue.SubCalCalendarName = SubCalendarEventEntry.getName.NameValue;
            if(SubCalendarEventEntry.getUIParam!= null) { 
                retValue.RColor = SubCalendarEventEntry.getUIParam.UIColor.R;
                retValue.GColor = SubCalendarEventEntry.getUIParam.UIColor.G;
                retValue.BColor = SubCalendarEventEntry.getUIParam.UIColor.B;
                retValue.OColor = SubCalendarEventEntry.getUIParam.UIColor.O;
                retValue.ColorSelection = SubCalendarEventEntry.getUIParam.UIColor.User;
            }
            retValue.isComplete = SubCalendarEventEntry.getIsComplete;
            retValue.isEnabled = SubCalendarEventEntry.isEnabled;
            retValue.Duration = (long)SubCalendarEventEntry.getActiveDuration.TotalMilliseconds;
            retValue.ThirdPartyEventID = SubCalendarEventEntry.ThirdPartyID;
            retValue.EventPreDeadline = (long)SubCalendarEventEntry.getPreDeadline.TotalMilliseconds;
            retValue.Priority = SubCalendarEventEntry.getEventPriority;
            retValue.Conflict = String.Join(",", SubCalendarEventEntry.Conflicts.getConflictingEventIDs());
            retValue.isPaused = SubCalendarEventEntry.isPaused;
            retValue.isPauseAble = SubCalendarEventEntry.RangeTimeLine.IsDateTimeWithin(CurrentTime) && !SubCalendarEventEntry.isRigid;
            retValue.PauseStart = (long)(SubCalendarEventEntry.Start - JSStartTime).TotalMilliseconds;
            retValue.PauseEnd = (long)(SubCalendarEventEntry.End - JSStartTime).TotalMilliseconds;
            retValue.IsLocked = SubCalendarEventEntry.isLocked;
            retValue.UserLocked = SubCalendarEventEntry.userLocked;
            return retValue;
        }

        public static CalEvent ToCalEvent(this TilerElements.CalendarEvent CalendarEventEntry, TilerElements.TimeLine Range = null, bool includeSubevents = true)
        {
            DateTimeOffset CurrentTime = DateTimeOffset.UtcNow;
            CalEvent retValue = new CalEvent();
            retValue.ThirdPartyUserID = CalendarEventEntry.getCreator.Id;
            retValue.ID = CalendarEventEntry.getId;
            retValue.ThirdPartyType = CalendarEventEntry.ThirdpartyType.ToString();
            retValue.CalendarName = CalendarEventEntry.getName.NameValue;
            retValue.StartDate = (long)(CalendarEventEntry.Start - JSStartTime).TotalMilliseconds;
            retValue.EndDate = (long)(CalendarEventEntry.End - JSStartTime).TotalMilliseconds;
            retValue.TotalDuration = CalendarEventEntry.getActiveDuration;
            retValue.Rigid = CalendarEventEntry.isRigid;
            retValue.AddressDescription = CalendarEventEntry.Location.Description;
            retValue.Address = CalendarEventEntry.Location.Address;
            retValue.Longitude = CalendarEventEntry.Location.Longitude;
            retValue.Latitude = CalendarEventEntry.Location.Latitude;
            retValue.NumberOfSubEvents = CalendarEventEntry.NumberOfSplit;
            retValue.RColor = CalendarEventEntry.getUIParam.UIColor.R;
            retValue.GColor = CalendarEventEntry.getUIParam.UIColor.G;
            retValue.BColor = CalendarEventEntry.getUIParam.UIColor.B;
            retValue.OColor = CalendarEventEntry.getUIParam.UIColor.O;
            retValue.ColorSelection = CalendarEventEntry.getUIParam.UIColor.User;
            retValue.NumberOfCompletedTasks = CalendarEventEntry.CompletionCount;
            retValue.NumberOfDeletedEvents = CalendarEventEntry.DeletionCount;
            retValue.OtherPartyID = CalendarEventEntry.ThirdPartyID;
            retValue.Notes = CalendarEventEntry.Notes.UserNote;

            TimeSpan FreeTimeLeft = CalendarEventEntry.RangeSpan - CalendarEventEntry.getActiveDuration;
            long TickTier1 = (long)(FreeTimeLeft.Ticks * (.667));
            long TickTier2 = (long)(FreeTimeLeft.Ticks * (.865));
            long TickTier3 = (long)(FreeTimeLeft.Ticks * (1));
            retValue.Tiers = new long[] { TickTier1, TickTier2, TickTier3 };
            if (includeSubevents)
            {
                if (Range != null)
                {
                    retValue.AllSubCalEvents = CalendarEventEntry.ActiveSubEvents.Where(obj => obj.RangeTimeLine.InterferringTimeLine(Range) != null).Select(obj => obj.ToSubCalEvent(CalendarEventEntry)).ToList();
                }
                else
                {
                    retValue.AllSubCalEvents = CalendarEventEntry.ActiveSubEvents.Select(obj => obj.ToSubCalEvent(CalendarEventEntry)).ToList();
                }
            }
            retValue.IsLocked = CalendarEventEntry.isLocked;
            retValue.UserLocked = CalendarEventEntry.userLocked;
            return retValue;
        }


        public static CalEvent ToDeletedCalEvent(this TilerElements.CalendarEvent CalendarEventEntry, TilerElements.TimeLine Range = null)
        {
            CalEvent retValue = new CalEvent();
            retValue.ThirdPartyUserID = CalendarEventEntry.getCreator.Id;

            retValue.ID = CalendarEventEntry.getId;
            retValue.ThirdPartyType = CalendarEventEntry.ThirdpartyType.ToString();
            retValue.CalendarName = CalendarEventEntry.getName.NameValue;
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

            TimeSpan FreeTimeLeft = CalendarEventEntry.RangeSpan - CalendarEventEntry.getActiveDuration;
            long TickTier1 = (long)(FreeTimeLeft.Ticks * (.667));
            long TickTier2 = (long)(FreeTimeLeft.Ticks * (.865));
            long TickTier3 = (long)(FreeTimeLeft.Ticks * (1));
            retValue.Tiers = new long[] { TickTier1, TickTier2, TickTier3 };
            if (Range != null)
            {
                retValue.AllSubCalEvents = CalendarEventEntry.AllSubEvents.Where(obj=>!obj.isActive).Where(obj => obj.RangeTimeLine.InterferringTimeLine(Range) != null).Select(obj => obj.ToSubCalEvent(CalendarEventEntry)).ToList();
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
            return retValue;
        }
    }
}
