using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXTRPG
{
    public class HealingPotion : Consumable
    {
        public override ItemType type { get; set; }
        public override string name { get; }
        public override string toolTip { get; }
        public override int price { get; set; }
        public override int health { get; set; }

        public HealingPotion()
        {
            name = "힐링포션";
            health = 3;
            toolTip = "체력을 " + health + " 회복시킵니다";
            price = 10;
        }

        public override void Use(ICharacter ch)
        {
            Console.WriteLine(this.name + "을 사용했습니다.");
            ch.health += this.health;
            ch.items.Remove(this);
        }
    }

    public class IronArmor : Armor
    {
        public override ItemType type { get; set; }
        public override string name { get; }
        public override string toolTip { get; }
        public override int price { get; set; }
        public override int defense { get; set; }

        public IronArmor()
        {
            type = ItemType.armor;
            name = "철갑옷";
            defense = 10;
            toolTip = "최대체력+" + defense + "\n튼튼한 철갑옷 입니다.";
            price = 100;
        }

    }


    public class Stick : Weapon
    {
        public override ItemType type { get; set; }
        public override string name { get; }
        public override string toolTip { get; }
        public override int price { get; set; }
        public override int attack { get; set; }

        public Stick()
        {
            name = "나뭇가지";
            type = ItemType.weapon;
            attack = 1;
            toolTip = "공격력+" + attack + "\n나뭇가지입니다.";
            price = 1;
        }

        
    }

    public class Sword : Weapon
    {
        public override ItemType type { get; set; }
        public override string name { get; }
        public override string toolTip { get; }
        public override int price { get; set; }
        public override int attack { get; set; }

        public Sword()
        {
            type = ItemType.weapon;
            name = "한손검";
            attack = 10;
            toolTip = "공격력+" + attack + "\n날카로운 한손검 입니다.";
            price = 60;
        }

    }
}
