using System;
using System.Collections.Generic;
using System.Text;

namespace _5.FootballTeamGenerator
{
    public static class ErrorMessages
    {

        public const string NameNullExceptionMessage = "A name should not be empty.";
        public const string StatsInRangeExceptionMessage = "{0} should be between 0 and 100.";
        public const string PlayerNotInTeam = "Player {0} is not in {1} team";
        public const string TeamDoesNotExist = "Player {0} is not in [Team name] team.";


    }
}
