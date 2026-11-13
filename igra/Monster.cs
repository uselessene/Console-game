namespace Igra.Monsters
{
    public class Monster
    {
        public int Health;
        public int Damage;

        public Monster(int hp, int dmg)
        {
            Health = hp;
            Damage = dmg;
        }

        public int Ataka()
        {
            return Damage;
        }

        public void PoluchDamage(int dmg)
        {
            Health = Health - dmg;
        }
    }

    public class Vampire : Monster
    {
        public string Name;

        public Vampire() : base(100, 20)
        {
            Name = "Dracula";
        }
    }
}