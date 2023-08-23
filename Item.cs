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

        void Use(ICharacter ch);
        void Equip(ICharacter ch);
        void Unclothe(ICharacter ch);
        void Discard(ICharacter ch);
    }

    public abstract class Weapon : IItem
    {
        public ItemType type { get { return type; } set => type = ItemType.weapon; }

        public abstract string name { get; }
        public abstract string toolTip { get; }
        public abstract int price { get; set; }

        public void Use(ICharacter ch)
        {
            Console.WriteLine("장비는 사용되지 않습니다.");
        }
        public abstract void Equip(ICharacter ch);
        public abstract void Unclothe(ICharacter ch);
        public void Discard(ICharacter ch)
        {
            if (ch.items.Contains(this))
            {
                ch.items.Remove(this);
                Console.WriteLine(this.name + " 아이템을 버렸습니다");
            }
        }
    }

    public abstract class Armor : IItem
    {
        public ItemType type { get { return type; } set => type = ItemType.armor; }

        public abstract string name { get; }
        public abstract string toolTip { get; }
        public abstract int price { get; set; }

        public void Use(ICharacter ch)
        {
            Console.WriteLine("장비는 사용되지 않습니다.");
        }
        public abstract void Equip(ICharacter ch);
        public abstract void Unclothe(ICharacter ch);
        public void Discard(ICharacter ch)
        {
            if (ch.items.Contains(this))
            {
                ch.items.Remove(this);
                Console.WriteLine(this.name + " 아이템을 버렸습니다");
            }
        }
    }

    public abstract class Consumable : IItem
    {
        public ItemType type { get { return type; } set => type = ItemType.consumable; }

        public abstract string name { get; }
        public abstract string toolTip { get; }
        public abstract int price { get; set; }

        public abstract void Use(ICharacter ch);
        public  void Equip(ICharacter ch)
        {
            Console.WriteLine("소모품은 장비되지 않습니다.");
        }
        public  void Unclothe(ICharacter ch)
        {
            Console.WriteLine("소모품은 장비해제되지 않습니다.");
        }
        public void Discard(ICharacter ch)
        {
            if (ch.items.Contains(this))
            {
                ch.items.Remove(this);
                Console.WriteLine(this.name + " 아이템을 버렸습니다");
            }
        }
    }

}
