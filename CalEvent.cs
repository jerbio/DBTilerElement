﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TilerElements.Wpf;
using TilerElements.DB;

namespace DBTilerElement
{
    public class CalEvent
    {
        public string ID { get; set; }
        public string CalendarName { get; set; }
        public long StartDate { get; set; }
        public long EndDate { get; set; }
        public TimeSpan TotalDuration { get; set; }
        public bool Rigid { get; set; }
        public string AddressDescription { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int NumberOfSubEvents { get; set; }
        public int NumberOfDeletedEvents { get; set; }
        public int NumberOfCompletedTasks { get; set; }
        public int RColor { get; set; }
        public int GColor { get; set; }
        public int BColor { get; set; }
        public double OColor { get; set; }
        public int ColorSelection { get; set; }
        public IList<long> Tiers { get; set; }
        public IList<SubCalEvent> AllSubCalEvents { get; set; }
        public string OtherPartyID { get; set; }
        public string ThirdPartyUserID { get; set; }
        public string ThirdPartyType { get; set; }

        ///*
        public static CalendarEvent FromGoogleToRepatCalendarEvent(IEnumerable<SubCalendarEvent> AllSubCalEvents, TimeLine LimitsOfCalculation = null)
        {
            CalendarEvent RetValue = null;

            SubCalendarEvent[] AllSubcals = AllSubCalEvents.ToArray();
            if (AllSubcals.Length > 0)
            {
                SubCalendarEvent FirtEvent = AllSubcals.First();
                EventID ParentCalId = new EventID(FirtEvent.SubEvent_ID.getRepeatCalendarEventID());
                if (LimitsOfCalculation == null)
                {
                    DateTimeOffset CalEventStart = AllSubcals.Min(obj => obj.Start);
                    DateTimeOffset CalEventEnd = AllSubcals.Max(obj => obj.End);
                    LimitsOfCalculation = new TimeLine(CalEventStart, CalEventEnd);
                }

                RetValue = new CalendarEvent(ParentCalId, AllSubCalEvents.First().Name, LimitsOfCalculation.TimelineSpan, LimitsOfCalculation.Start, LimitsOfCalculation.End, LimitsOfCalculation.Start, new TimeSpan(), new TimeSpan(), true, new Repetition(), AllSubcals.Length, new Location_Elements(), true, new EventDisplay(), new MiscData(), false,0);
                RetValue = new CalendarEvent(RetValue, AllSubcals);
            }
            return RetValue;
        }
        //*/
    }
}