﻿namespace WarCroft.Entities.Items
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WarCroft.Entities.Characters.Contracts;

    public class HealthPotion : Item
    {

        private const int HealthPotionWeight = 5;

        public HealthPotion() : base(HealthPotionWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.
        }
    }
}
