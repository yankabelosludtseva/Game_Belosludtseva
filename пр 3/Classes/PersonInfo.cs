using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace пр_3.Classes
{
    public class PersonInfo
    {
        public string Name { get; set; }
        public int Healht { get; set; }
        public int Armor { get; set; }
        public int Level { get; set; }
        public int Glasses { get; set; }
        public int Money { get; set; }
        public float Damage { get; set; }
        public PersonInfo(string Name, int Healht, int Armor, int Level, int Glasses, int Money, float Damage)
        {
            this.Name = Name;
            this.Healht = Healht;
            this.Armor = Armor;
            this.Level = Level;
            this.Glasses = Glasses;
            this.Money = Money;
            this.Damage = Damage;
        }
    }
}
