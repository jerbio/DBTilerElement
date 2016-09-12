using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilerElements.Wpf;
using TilerElements.Connectors;


namespace DBTilerElement
{
    public static class TilerElementExtension
    {
        public static DateTimeOffset CurrentTime = DateTimeOffset.UtcNow;
        public static DateTimeOffset JSStartTime = new DateTimeOffset(1970, 1, 1, 0, 0, 0, new TimeSpan());
        public static TimeSpan StartOfTimeTimeSpan = JSStartTime - new DateTimeOffset(0, new TimeSpan());
        public readonly static Dictionary<ThirdPartyControl.CalendarTool, string> ProviderNames = new Dictionary<ThirdPartyControl.CalendarTool, string>()
        {
            { ThirdPartyControl.CalendarTool.Tiler, "Tiler" },
            { ThirdPartyControl.CalendarTool.Outlook, "Outlook" },
            { ThirdPartyControl.CalendarTool.Google, "Google"},
            { ThirdPartyControl.CalendarTool.Facebook, "Facebook" }
        };
            
        public static SubCalEvent ToSubCalEvent(this SubCalendarEvent SubCalendarEventEntry, CalendarEvent CalendarEventEntry = null)
        {
            SubCalEvent retValue = new SubCalEvent();
            retValue.ThirdPartyUserID = SubCalendarEventEntry.ThirdPartyUserID;
            retValue.ThirdPartyType = ProviderNames[SubCalendarEventEntry.ThirdpartyType];
            retValue.ThirdPartyEventID = SubCalendarEventEntry.ThirdPartyID;
            retValue.ID = SubCalendarEventEntry.Id;
            retValue.CalendarID = SubCalendarEventEntry.SubEvent_ID.getRepeatCalendarEventID();

            retValue.SubCalStartDate = (long)(SubCalendarEventEntry.Start - JSStartTime).TotalMilliseconds;
            retValue.SubCalEndDate = (long)(SubCalendarEventEntry.End - JSStartTime).TotalMilliseconds;
            retValue.SubCalTotalDuration = SubCalendarEventEntry.ActiveDuration;
            retValue.SubCalRigid = SubCalendarEventEntry.Rigid;
            
            retValue.ThirdPartyEventID = SubCalendarEventEntry.ThirdPartyID;
            if (CalendarEventEntry != null)
            {
                retValue.CalRigid = CalendarEventEntry.Rigid;
                retValue.SubCalCalendarName = CalendarEventEntry.NameString;
                retValue.SubCalCalEventStart = (long)(CalendarEventEntry.Start - JSStartTime).TotalMilliseconds;
                retValue.SubCalCalEventEnd = (long)(CalendarEventEntry.End - JSStartTime).TotalMilliseconds;

                if(string.IsNullOrEmpty(CalendarEventEntry.ThirdPartyID))
                {

                }
                else
                {
                    retValue.ID = retValue.ThirdPartyEventID;
                }
            }

            if (SubCalendarEventEntry.Location != null)
            {
                retValue.SubCalEventLong = SubCalendarEventEntry.Location.YCoordinate;
                retValue.SubCalEventLat = SubCalendarEventEntry.Location.XCoordinate;
                retValue.SubCalAddressDescription = SubCalendarEventEntry.Location.Description;
                retValue.SubCalAddress = SubCalendarEventEntry.Location.Address;
            }

            if (SubCalendarEventEntry.UIParam != null)
            {
                retValue.RColor = SubCalendarEventEntry.UIParam.UIColor.R;
                retValue.GColor = SubCalendarEventEntry.UIParam.UIColor.G;
                retValue.BColor = SubCalendarEventEntry.UIParam.UIColor.B;
                retValue.OColor = SubCalendarEventEntry.UIParam.UIColor.O;
                retValue.ColorSelection = SubCalendarEventEntry.UIParam.UIColor.UserColorSelection;
            }


            retValue.isComplete = SubCalendarEventEntry.isComplete;
            retValue.isEnabled = SubCalendarEventEntry.isEnabled;
            retValue.Duration = (long)SubCalendarEventEntry.ActiveDuration.TotalMilliseconds;
            retValue.ThirdPartyEventID = SubCalendarEventEntry.ThirdPartyID;
            retValue.EventPreDeadline = (long)SubCalendarEventEntry.PreDeadline.TotalMilliseconds;
            retValue.Priority = SubCalendarEventEntry.EventPriority;
            retValue.Conflict = String.Join(",", SubCalendarEventEntry.Conflicts.getConflictingEventIDs());
            retValue.isPaused = SubCalendarEventEntry.isPaused;
            retValue.isPauseAble = SubCalendarEventEntry.RangeTimeLine.IsDateTimeWithin(CurrentTime) && !SubCalendarEventEntry.Rigid;
            retValue.PauseStart = (long)(SubCalendarEventEntry.Start - JSStartTime).TotalMilliseconds;
            retValue.PauseEnd = (long)(SubCalendarEventEntry.End - JSStartTime).TotalMilliseconds;
            return retValue;
        }

        public static CalEvent ToCalEvent(this CalendarEvent CalendarEventEntry, TimeLine Range = null)
        {
            CalEvent retValue = new CalEvent();
            retValue.ThirdPartyUserID = CalendarEventEntry.CreatorId;
            CurrentTime = DateTimeOffset.UtcNow;
            
            retValue.ID = CalendarEventEntry.Id;
            retValue.ThirdPartyType = ProviderNames[CalendarEventEntry.ThirdpartyType];
            retValue.CalendarName = CalendarEventEntry.NameString;
            retValue.StartDate = (long)(CalendarEventEntry.Start - JSStartTime).TotalMilliseconds;
            retValue.EndDate = (long)(CalendarEventEntry.End - JSStartTime).TotalMilliseconds;
            retValue.TotalDuration = CalendarEventEntry.Duration;
            retValue.Rigid = CalendarEventEntry.Rigid;
            if (CalendarEventEntry.Location != null)
            {
                retValue.AddressDescription = CalendarEventEntry.Location.Description;
                retValue.Address = CalendarEventEntry.Location.Address;
                retValue.Longitude = CalendarEventEntry.Location.YCoordinate;
                retValue.Latitude = CalendarEventEntry.Location.XCoordinate;
            }
            retValue.NumberOfSubEvents = CalendarEventEntry.AllSubEvents.Count();// CalendarEventEntry.NumberOfSplit;// AllSubEvents.Count();
            if (CalendarEventEntry.UIParam != null)
            {
                retValue.RColor = CalendarEventEntry.UIParam.UIColor.R;
                retValue.GColor = CalendarEventEntry.UIParam.UIColor.G;
                retValue.BColor = CalendarEventEntry.UIParam.UIColor.B;
                retValue.OColor = CalendarEventEntry.UIParam.UIColor.O;
                retValue.ColorSelection = CalendarEventEntry.UIParam.UIColor.UserColorSelection;
            }
            
            retValue.NumberOfCompletedTasks = CalendarEventEntry.CompletionCount;
            retValue.NumberOfDeletedEvents = CalendarEventEntry.DeletionCount;
            retValue.OtherPartyID = CalendarEventEntry.ThirdPartyID;

            TimeSpan FreeTimeLeft = CalendarEventEntry.RangeSpan - CalendarEventEntry.Duration;
            long TickTier1 = (long)(FreeTimeLeft.Ticks * (.667));
            long TickTier2 = (long)(FreeTimeLeft.Ticks * (.865));
            long TickTier3 = (long)(FreeTimeLeft.Ticks * (1));
            retValue.Tiers = new long[] { TickTier1, TickTier2, TickTier3 };
            if (Range != null)
            {
                retValue.AllSubCalEvents = CalendarEventEntry.ActiveSubEvents.Where(obj => obj.RangeTimeLine.InterferringTimeLine(Range) != null).Select(obj => obj.ToSubCalEvent(CalendarEventEntry)).ToList();
            }
            else
            {
                retValue.AllSubCalEvents = CalendarEventEntry.ActiveSubEvents.Select(obj => obj.ToSubCalEvent(CalendarEventEntry)).ToList();
            }

            return retValue;
        }


        public static CalEvent ToDeletedCalEvent(this CalendarEvent CalendarEventEntry, TimeLine Range = null)
        {
            CalEvent retValue = new CalEvent();
            retValue.ThirdPartyUserID = CalendarEventEntry.ThirdPartyUserID;

            retValue.ID = CalendarEventEntry.Id;
            retValue.ThirdPartyType = ProviderNames[CalendarEventEntry.ThirdpartyType];
            retValue.CalendarName = CalendarEventEntry.NameString;
            retValue.StartDate = (long)(CalendarEventEntry.Start - JSStartTime).TotalMilliseconds;
            retValue.EndDate = (long)(CalendarEventEntry.End - JSStartTime).TotalMilliseconds;
            retValue.TotalDuration = CalendarEventEntry.Duration;
            retValue.Rigid = CalendarEventEntry.Rigid;
            retValue.AddressDescription = CalendarEventEntry.Location.Description;
            retValue.Address = CalendarEventEntry.Location.Address;
            retValue.Longitude = CalendarEventEntry.Location.YCoordinate;
            retValue.Latitude = CalendarEventEntry.Location.XCoordinate;
            retValue.NumberOfSubEvents = CalendarEventEntry.AllSubEvents.Count();// CalendarEventEntry.NumberOfSplit;// AllSubEvents.Count();
            retValue.RColor = CalendarEventEntry.UIParam.UIColor.R;
            retValue.GColor = CalendarEventEntry.UIParam.UIColor.G;
            retValue.BColor = CalendarEventEntry.UIParam.UIColor.B;
            retValue.OColor = CalendarEventEntry.UIParam.UIColor.O;
            retValue.ColorSelection = CalendarEventEntry.UIParam.UIColor.UserColorSelection;
            retValue.NumberOfCompletedTasks = CalendarEventEntry.CompletionCount;
            retValue.NumberOfDeletedEvents = CalendarEventEntry.DeletionCount;
            retValue.OtherPartyID = CalendarEventEntry.ThirdPartyID;

            TimeSpan FreeTimeLeft = CalendarEventEntry.RangeSpan - CalendarEventEntry.Duration;
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

        public static Location ToLocationModel(this Location_Elements LocationEntry)
        {
            Location retValue = new Location();
            retValue.Address = LocationEntry.Address;
            retValue.Tag = LocationEntry.Description;
            retValue.Long = LocationEntry.YCoordinate;
            retValue.Lat = LocationEntry.XCoordinate;
            retValue.isNull = !LocationEntry.isNull;
            return retValue;
        }
    }
}
