namespace FourFlagsRPG.Models.Models.Heroes
{
    using static Utilities.HeroConstants;

    public class Dwarf : Hero
    {
        public Dwarf(string name)
            : base(name)
        {
            this.Health *= DwarfHealthMultiplier;
            this.Dexterity *= DwarfDexterityMultiplier;
            this.Damage += DwarfDamageMultiplier;
            this.Defence += DwarfDefenceMultiplier;
            this.Description = string.Format(DwarfDescription, this.Name);
        }
    }
}