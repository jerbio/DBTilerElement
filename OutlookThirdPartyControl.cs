﻿//#define EnableOutlook

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TilerElements;

#if EnableOutlook
using Outlook = Microsoft.Office.Interop.Outlook;
#endif

namespace DBTilerElement
{
    public class OutlookThirdPartyControl : ThirdPartyCalendarControl
    {
        //Hold calendarevents that have already being added. helps address scenarios with recurrence
        HashSet<CalendarEvent> allReadyAdded = new HashSet<CalendarEvent>();
        public OutlookThirdPartyControl()
        {
            SelectedCalendarTool = ThirdPartyControl.CalendarTool.microsoft;
        }


        public OutlookThirdPartyControl( Dictionary<string, CalendarEvent> CalendarData)
        {
            IDToCalendarEvent = CalendarData;

        }
        virtual public void removeAllEventsFromOutLook(IEnumerable<CalendarEvent> ArrayOfCalendarEvents)
        {
            int i = 0;
            CalendarEvent[] ArrayOfCalendarevents = ArrayOfCalendarEvents.ToArray();
            for (; i < ArrayOfCalendarevents.Length; i++)//this loops through the ArrayOfValues and ArrayOfIndex. Since each index loop corresponds to the same dictionary entry.
            {
                RemoveFromOutlook(ArrayOfCalendarevents[i]); //this removes the value from outlook
                // AllEventDictionary.Remove(ArrayOfKeys[i]);//this removes the entry from The dictionary
            }
        }

        public override CalendarEvent getThirdpartyCalendarEvent(ReferenceNow referenceNow)
        {
            throw new NotImplementedException();
        }

        override public void DeleteAppointment(SubCalendarEvent ActiveSection, string NameOfParentCalendarEvent = "", string entryID = "")
        {
#if EnableOutlook
            if (entryID == "")
            {
                return;
            }
            Outlook.Application outlookApp = new Microsoft.Office.Interop.Outlook.Application();
            Outlook.MAPIFolder calendar = outlookApp.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar);

            Outlook.Items calendarItems = calendar.Items;
            try
            {
                string SubJectString = ActiveSection.getId + "**" + NameOfParentCalendarEvent;
                if (ActiveSection.getIsComplete)
                {
                    //SubJectString = ActiveSection.ID + "*\u221A*" + NameOfParentCalendarEvent;
                }
                Outlook.AppointmentItem item = calendarItems[SubJectString] as Outlook.AppointmentItem;
                item.Delete();
            }
            catch(Exception e)
            {
                return;
            }
#endif

        }
        override public string AddAppointment(SubCalendarEvent ActiveSection, string NameOfParentCalendarEvent = "")
        {
            if (!ActiveSection.isEnabled)
            {
                return "";
            }
#if EnableOutlook
            try
            {
                Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
                Outlook.AppointmentItem newAppointment = (Outlook.AppointmentItem)app.CreateItem(Outlook.OlItemType.olAppointmentItem);
                /*(Outlook.AppointmentItem)
            this.Application.CreateItem(Outlook.OlItemType.olAppointmentItem);*/
                newAppointment.Start = ActiveSection.Start.toTimeZoneTime().DateTime;// DateTimeOffset.Now.AddHours(2);
                newAppointment.End = ActiveSection.End.toTimeZoneTime().DateTime;// DateTimeOffset.Now.AddHours(3);
                newAppointment.Location = "TBD";
                newAppointment.Body = "JustTesting";
                newAppointment.AllDayEvent = false;
                string SubJectString = ActiveSection.getId + "**" + NameOfParentCalendarEvent;
                if (ActiveSection.getIsComplete)
                {
                    //SubJectString = ActiveSection.ID + "*\u221A*" + NameOfParentCalendarEvent;
                }
                newAppointment.Subject = SubJectString;// ActiveSection.ID + "**" + NameOfParentCalendarEvent;

                /*newAppointment.Recipients.Add("Roger Harui");
                Outlook.Recipients sentTo = newAppointment.Recipients;
                Outlook.Recipient sentInvite = null;
                sentInvite = sentTo.Add("Holly Holt");
                sentInvite.Type = (int)Outlook.OlMeetingRecipientType
                    .olRequired;
                sentInvite = sentTo.Add("David Junca ");
                sentInvite.Type = (int)Outlook.OlMeetingRecipientType
                    .olOptional;
                sentTo.ResolveAll();*/
                newAppointment.Save();
                //newAppointment.EntryID;

                //newAppointment.Display(true);
                return newAppointment.EntryID;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("The following error occurred: " + ex.Message);
                return "";
            }

#endif
            return "";


        }




        virtual public void RemoveFromOutlook(CalendarEvent MyEvent)
        {
            int i = 0;
            if (MyEvent.IsFromRecurringAndNotChildRepeatCalEvent)
            {
                LoopThroughRemoveRepeatEvents(MyEvent.Repeat);
            }
            else
            {
                for (i = 0; i < MyEvent.AllSubEvents.Length; i++)
                {
                    SubCalendarEvent pertinentSubCalEvent = MyEvent.AllSubEvents[i];
                    DeleteAppointment(pertinentSubCalEvent, MyEvent.getName.NameValue, pertinentSubCalEvent.ThirdPartyID);
                }
            }
            allReadyAdded.Remove(MyEvent);
        }

        virtual public void WriteToOutlook(CalendarEvent MyEvent)
        {
#if (EnableOutlook)
            int i = 0;
            if (!MyEvent.isActive)
            {
                return;
            }
            if (MyEvent.IsRecurring)
            {
                LoopThroughAddRepeatEvents(MyEvent.Repeat);
            }
            else
            {
                if(!allReadyAdded.Contains(MyEvent))
                {
                    SubCalendarEvent[] enableSubCalEVents = MyEvent.ActiveSubEvents;
                    for (; i < enableSubCalEVents.Length; i++)
                    {

                        SubCalendarEvent pertinentSubCalEvent = enableSubCalEVents[i];
                        pertinentSubCalEvent.ThirdPartyID = AddAppointment(pertinentSubCalEvent, MyEvent.getName?.NameValue);/////////////
                    }
                    allReadyAdded.Add(MyEvent);
                }
                
            }
#endif
        }

        virtual public void WriteToOutlook()
        {
            if(IDToCalendarEvent!=null)
            {
                foreach (CalendarEvent calEvent in IDToCalendarEvent.Values)
                {
                    WriteToOutlook(calEvent);
                }
            }
        }

        virtual public void LoopThroughAddRepeatEvents(Repetition MyRepetition)
        {
            int i = 0;
            CalendarEvent[] recurringEvents = MyRepetition.RecurringCalendarEvents();
            for (; i < recurringEvents.Length; i++)
            {
                WriteToOutlook(recurringEvents[i]);
            }
        }



        virtual public void LoopThroughRemoveRepeatEvents(Repetition MyRepetition)
        {
            int i = 0;
            CalendarEvent[] recurringEvents = MyRepetition.RecurringCalendarEvents();
            for (; i < recurringEvents.Length; i++)
            {
                RemoveFromOutlook(recurringEvents[i]);
            }
        }

        public override TilerUser getUser()
        {
            throw new NotImplementedException();
        }
    }
}
