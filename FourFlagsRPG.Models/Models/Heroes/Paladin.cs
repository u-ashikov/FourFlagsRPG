namespace FourFlagsRPG.Models.Models.Heroes
{
    using static Utilities.HeroConstants;

    public class Paladin : Hero
    {
        public Paladin(string name)
            : base(name)
        {
            this.Health += this.Health / PaladinHealthDivider;
            this.Strength *= PaladinfStrengthMultiplier;
            this.Damage += PaladinDamageMultiplier;
            this.Dexterity += PaladinDexterityMultiplier;
            this.Defence += PaladinDefenceMultiplier;
            this.Description = string.Format(PaladinDescription, this.Name);
        }
    }
}