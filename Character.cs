using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TEXTRPG
{
    public interface ICharacter
    {
        string name { get; }
        int health { get; set; }
        int attack { get; set; }
        int gold { get; set; }
        bool isDead { get; }

        List<IItem> items { get; set; }

        IItem weapon { get; set; }
        IItem armor { get; set; }

        void TakeDamage(int damage);
    }

    public class PlayerCharacter : ICharacter
    {
        public string name { get; }
        public int health { get; set; }
        public int attack { get; set; }
        public int gold { get; set; }
        public bool isDead => health <= 0;

        public List<IItem> items { get; set; }

        public IItem weapon { get; set; }
        public IItem armor { get; set; }


        public void TakeDamage(int damage)
        {

        }

        public PlayerCharacter(string name)
        {
            this.name = name;
            this.health = 10;
            this.attack = 2;
            this.gold = 300;
            this.items = new List<IItem>();
        }
    }


    public class Merchant : ICharacter
    {
        public string name { get; }
        public int health { get; set; }
        public int attack { get; set; }
        public int gold { get; set; }
        public bool isDead => health <= 0;

        public List<IItem> items { get; set; }

        public IItem weapon { get; set; }
        public IItem armor { get; set; }


        public void TakeDamage(int damage)
        {

        }

        public Merchant(string name)
        {
            this.name = name;
            this.health = 10;
            this.attack = 2;
            this.gold = 1000;
            this.items = new List<IItem>();
            this.items.Add(new Stick());
            this.items.Add(new Sword());
            this.items.Add(new IronArmor());
            this.items.Add(new HealingPotion());
        }
    }

}
