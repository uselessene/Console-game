namespace Igra.Heroes
{
    public class Hero
    {
        public string Name;
        public int Health;
        public int Damage;

        public Hero(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        public int Ataka()
        {
            return Damage;
        }

        public void PoluchDamage(int dmg)
        {
            Health = Health - dmg;
        }

        public void Heal(int hp)
        {
            Health = Health + hp;
            if (Health > 100) 
            {
                Health = 100;
            }
        }
    }
}