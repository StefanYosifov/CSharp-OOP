namespace Heroes.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class HeroesErrorMessages
    {
        public const string nameIsNullOrWhiteSpace = "Hero name cannot be null or empty.";
        public const string healthIsBelowZero = "Hero health cannot be below 0.";
        public const string armourIsBelowZero = "Hero armour cannot be below 0.";
        public const string heroWithSuchNameExists = "The hero {0} already exists.";
        public const string heroWithSuchTypeExists = "Invalid hero type.";
        public const string heroSuccesfullyAdded = "Successfully added Sir {0} to the collection.";
        public const string heroWithSuchNameDoesNotExist = "Hero {0} does not exist.";
        public const string heroAlreadyHasAWeapon = "Hero {0} is well-armed";
    }
}
