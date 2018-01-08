namespace FourFlagsRPG.Models.Models.Heroes
{
    using static Utilities.HeroConstants;

    public class Barbarian : Hero
    {
        public Barbarian(string name)
            : base(name)
        {
            this.Health *= BarbarianHealthMultiplier;
            this.Damage *= BarbarianDamageMultiplier;
            this.Strength *= BarbarianStrengthMultiplier;
            this.Defence *= BarbarianDefenceMultiplier;
            this.Description = string.Format(BarbarianDescription, this.Name);
        }
    }
}