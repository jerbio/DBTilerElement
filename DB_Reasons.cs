using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilerElements;

namespace DBTilerElement
{
    public abstract class DB_Reasons:Reason
    {
    }

    public class DBWeatherReason: WeatherReason
    {

        public DBWeatherReason(Options weatherOption, Bounds weatherBounds, double top = 70, double bottom = 90, bool isCelcius = true):base(weatherOption, weatherBounds,  top , bottom, isCelcius )
        {

        }

        public DBWeatherReason():base(Options.Weather,Bounds.None)
        {

        }

        public Options WeatherOptions
        {
            get {
                return this.Option;
            }
            set
            {
                this.Option = value;
            }
        }

        public Bounds Bound
        {
            get
            {
                return this.WeatherBounds;
            }
            set
            {
                this.WeatherBounds = value;
            }
        }

        public double Ceiling
        {
            get {
                return Top;
            }

            set
            {
                Top = value;
            }
        }

        public double Floor
        {
            get
            {
                return Bottom;
            }

            set
            {
                Bottom = value;
            }
        }

        public bool CelciusFlag
        {
            get
            {
                return IsCelcius;
            }

            set
            {
                IsCelcius = value;
            }
        }
    }

    public class DBBestFitReason : BestFitReason
    {
        protected TimeSpan UsedUp { get; set; }
        protected TimeSpan Available { get; set; }
        protected TimeSpan CurrentUse { get; set; }
        public DBBestFitReason(TimeSpan usedUp, TimeSpan available, TimeSpan currentUse):base(usedUp, available, currentUse){}
        public DBBestFitReason() : base(new TimeSpan(), new TimeSpan(), new TimeSpan()) { }

        public TimeSpan UsedupTime {
            get
            {
                return UsedUp;
            }
            set {
                this.UsedUp = value;
            }
        }
        public TimeSpan AvailableTime
        {
            get
            {
                return Available;
            }
            set
            {
                this.Available = value;
            }
        }
        public TimeSpan CurrentUsedTime
        {
            get
            {
                return CurrentUse;
            }
            set
            {
                this.CurrentUse = value;
            }
        }
    }
}
