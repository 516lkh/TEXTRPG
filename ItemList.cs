using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXTRPG
{
    public class HealingPotion : IItem
    {
        public string name { get; }
        public string toolTip { get; }
        public int price { get; set; }

        public HealingPotion()
        {
            name = "힐링포션";
            toolTip = "체력을 3 회복시킵니다";
            price = 10;
        }

        public void Use(ICharacter ch)
        {
            Console.WriteLine(this.name + "을 사용했습니다.");
            ch.health += 3;
            ch.items.Remove(this);
        }

        public void Remove(ICharacter ch)
        {
            
        }
    }

    public class IronArmor : IItem
    {
        public string name { get; }
        public string toolTip { get; }
        public int price { get; set; }

        public IronArmor()
        {
            name = "철갑옷";
            toolTip = "최대체력+10\n튼튼한 철갑옷 입니다.";
            price = 100;
        }

        public void Use(ICharacter ch)
        {
            Remove(ch);

            Console.WriteLine(ch.armor.name + "를 장착했습니다.");
            ch.armor = this;
            ch.health += 10;
            ch.items.Remove(this);
        }

        public void Remove(ICharacter ch)
        {
            if (ch.weapon != null)
            {
                Console.WriteLine(ch.armor.name + "를 해제했습니다.");
                ch.health -= 10;
                ch.items.Add(ch.weapon);
                ch.armor = null;
            }
        }
    }


    public class Stick : IItem
    {
        public string name { get; }
        public string toolTip { get; }
        public int price { get; set; }

        public Stick()
        {
            name = "나뭇가지";
            toolTip = "공격력+1\n나뭇가지입니다. 뭘 기대하시나요?";
            price = 1;
        }

        public void Use(ICharacter ch)
        {
            Remove(ch);

            Console.WriteLine(ch.weapon.name + "를 장착했습니다.");
            ch.weapon = this;
            ch.attack += 1;
            ch.items.Remove(this);
        }

        public void Remove(ICharacter ch)
        {
            if (ch.weapon != null)
            {
                Console.WriteLine(ch.weapon.name + "를 해제했습니다.");
                ch.attack -= 1;
                ch.items.Add(ch.weapon);
                ch.weapon = null;
            }
        }
    }

    public class Sword : IItem
    {
        public string name { get; }
        public string toolTip { get; }
        public int price { get; set; }

        public Sword()
        {
            name = "한손검";
            toolTip = "공격력+10\n날카로운 한손검 입니다.";
            price = 60;
        }

        public void Use(ICharacter ch)
        {
            Remove(ch);

            Console.WriteLine(ch.weapon.name + "를 장착했습니다.");
            ch.weapon = this;
            ch.attack += 10;
            ch.items.Remove(this);
        }

        public void Remove(ICharacter ch)
        {
            if (ch.weapon != null)
            {
                Console.WriteLine(ch.weapon.name + "를 해제했습니다.");
                ch.attack -= 10;
                ch.items.Add(ch.weapon);
                ch.weapon = null;
            }
        }
    }
}
