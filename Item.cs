using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TEXTRPG
{
    public enum ItemType
    {
        consumable,
        weapon,
        armor
    }

    public interface IItem
    {
        ItemType type { get; set; }

        string name { get; }
        string toolTip { get; }
        int price { get; set; }
        int attack { get; set; }
        int defense { get; set; }
        int health { get; set; }

        void Use(ICharacter ch);
        void Equip(ICharacter ch);
        void Unclothe(ICharacter ch);
        void Discard(ICharacter ch);
    }

    public abstract class Weapon : IItem
    {
        public abstract ItemType type { get; set; }

        public abstract string name { get; }
        public abstract string toolTip { get; }
        public abstract int price { get; set; }
        public abstract int attack { get; set; }
        public int defense { get; set; }
        public int health { get; set; }

        public void Use(ICharacter ch)
        {
            Console.WriteLine("장비는 사용되지 않습니다.");
        }
        public void Equip(ICharacter ch)
        {
            Unclothe(ch);

            Console.WriteLine(this.name + " 아이템을 장착했습니다.");
            ch.weapon = this;
            ch.attack += this.attack;
            ch.items.Remove(this);
        }

        public void Unclothe(ICharacter ch)
        {
            if (ch.weapon != null)
            {
                Console.WriteLine(ch.weapon.name + " 아이템을 해제했습니다.");
                ch.attack -= ch.weapon.attack;
                ch.items.Add(ch.weapon);
                ch.weapon = null;
            }
        }
        public void Discard(ICharacter ch)
        {
            ch.items.Remove(this);
            Console.WriteLine(this.name + " 아이템을 버렸습니다");

        }
    }

    public abstract class Armor : IItem
    {
        public abstract ItemType type { get; set; }

        public abstract string name { get; }
        public abstract string toolTip { get; }
        public abstract int price { get; set; }
        public int attack { get; set; }
        public abstract int defense { get; set; }
        public int health { get; set; }

        public void Use(ICharacter ch)
        {
            Console.WriteLine("장비는 사용되지 않습니다.");
        }

        public void Equip(ICharacter ch)
        {
            this.Unclothe(ch);

            Console.WriteLine(this.name + " 아이템을 장착했습니다.");
            ch.armor = this;
            ch.defense += this.defense;
            ch.items.Remove(this);
        }

        public void Unclothe(ICharacter ch)
        {
            if (ch.armor != null)
            {
                Console.WriteLine(ch.armor.name + " 아이템을 해제했습니다.");
                ch.defense -= ch.armor.defense;
                ch.items.Add(ch.armor);
                ch.armor = null;
            }
        }
        public void Discard(ICharacter ch)
        {
            ch.items.Remove(this);
            Console.WriteLine(this.name + " 아이템을 버렸습니다");

        }
    }

    public abstract class Consumable : IItem
    {
        public abstract ItemType type { get; set; }

        public abstract string name { get; }
        public abstract string toolTip { get; }
        public abstract int price { get; set; }
        public int attack { get; set; }
        public int defense { get; set; }
        public abstract int health { get; set; }

        public abstract void Use(ICharacter ch);
        public void Equip(ICharacter ch)
        {
            Console.WriteLine("소모품은 장비되지 않습니다.");
        }
        public void Unclothe(ICharacter ch)
        {
            Console.WriteLine("소모품은 장비해제되지 않습니다.");
        }
        public void Discard(ICharacter ch)
        {
            ch.items.Remove(this);
            Console.WriteLine(this.name + " 아이템을 버렸습니다");

        }
    }

}
