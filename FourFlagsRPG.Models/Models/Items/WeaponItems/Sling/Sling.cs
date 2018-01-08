namespace FourFlagsRPG.Models.Models.Items.WeaponItems
{
    public class Sling : Weapon
    {
        private const int DamageBonusPoints = 13;
        private const int StrengthBonusPoints = 3;
        private const string SlingName = "The Sling of The Vampires";

        public Sling(int id)
            : base(id, SlingName, DamageBonusPoints, StrengthBonusPoints) { }
    }
}