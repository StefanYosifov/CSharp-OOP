using System;
using System.Collections.Generic;
using System.Text;

namespace _5.FootballTeamGenerator
{
    public class Stats
    {
        public Stats(int endurance,int sprint,int dribble,int passing,int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }


        private int startMinValue = 0;
        private int startMaxValue = 100;


        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;


        public int Endurance
        {
            get
            {
                return endurance;
            }
            private set
            {
                if(value<startMaxValue || value > startMaxValue)
                {
                    throw new ArgumentException(string.Format(ErrorMessages.StatsInRangeExceptionMessage,nameof(this.Endurance)));
                }
                this.endurance = value;
            }
        }


        public int Sprint
        {
            get
            {
                return sprint;
            }
            private set
            {
                if (value < startMaxValue || value > startMaxValue)
                {
                    throw new ArgumentException(string.Format(ErrorMessages.StatsInRangeExceptionMessage, nameof(this.Sprint)));
                }
                this.sprint = value;
            }
        }

       public int Dribble
        {
            get
            {
                return this.dribble;
            }
            private set
            {
                if (value < startMaxValue || value > startMaxValue)
                {
                    throw new ArgumentException(string.Format(ErrorMessages.StatsInRangeExceptionMessage, nameof(this.dribble)));
                }
                this.dribble = value;
            }
        }

        public int Passing
        {
            get
            {
                return this.passing;
            }
            private set
            {
                if (value < startMaxValue || value > startMaxValue)
                {
                    throw new ArgumentException(string.Format(ErrorMessages.StatsInRangeExceptionMessage, nameof(this.Passing)));
                }
                this.passing = value;
            }
        }

        public int Shooting
        {
            get
            {
                return this.shooting;
            }
            private set
            {
                if (value < startMaxValue || value > startMaxValue)
                {
                    throw new ArgumentException(string.Format(ErrorMessages.StatsInRangeExceptionMessage, nameof(this.Shooting)));
                }
                this.shooting = value;
            }
        }


        public int GetOverallStats()
        {
            return this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting/5;
        }
    }
}
