namespace Heroes.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class WeaponsErrorMessages
    {
        public const string nameIsEmptyOrWhiteSpace = "Weapon type cannot be null or empty.";
        public const string durabilityIsBelowZero = "Durability cannot be below 0.";
        public const string weaponIsNull = "Weapon cannot be null.";
        public const string weaponWithSuchNameExists = "The weapon { 0 } already exists.";
        public const string weaponTypeIsInvalid = "Invalid weapon type.";
        public const string weaponSuccesfullyAdded = "A {0} {1} is added to the collection.";
        public const string weaponWithSuchNameDoesNotExist= "Weapon {0} does not exist.";
    }
}
