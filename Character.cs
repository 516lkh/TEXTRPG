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
        int defense { get; set; }
        int gold { get; set; }
        bool isDead { get; }

        List<IItem> items { get; set; }

        IItem weapon { get; set; }
        IItem armor { get; set; }



    }

    public class PlayerCharacter : ICharacter
    {
        public string name { get; }
        public int health { get; set; }
        public int attack { get; set; }
        public int defense { get; set; }
        public int gold { get; set; }
        public bool isDead => health <= 0;

        public List<IItem> items { get; set; }

        public IItem weapon { get; set; }
        public IItem armor { get; set; }



        public PlayerCharacter(string name)
        {
            this.name = name;
            this.health = 10;
            this.attack = 2;
            this.defense = 0;
            this.gold = 300;
            this.items = new List<IItem>();

            this.weapon = null;
            this.armor = null;
        }

        public void CaracterInfo()
        {
            Console.WriteLine("이름 : " + this.name);
            Console.WriteLine("체력 : " + this.health);
            Console.WriteLine("공격력 : " + this.attack);
            Console.WriteLine("방어력 : " + this.defense);
            Console.WriteLine("골드 : " + this.gold);
            if (this.weapon != null) Console.WriteLine("무기 : " + this.weapon.name);
            else Console.WriteLine("무기 : 없음");
            if (this.armor != null) Console.WriteLine("갑옷 : " + this.armor.name);
            else Console.WriteLine("갑옷 : 없음");
            Console.WriteLine();

        }

        public void InventoryInfo()
        {
            int i = 0;
            int input;

            foreach (var item in items)
            {
                Console.WriteLine((++i).ToString() + ". " + item.name);
            }


            Console.WriteLine((++i).ToString() + ". 뒤로");
            Console.WriteLine("");
            Console.Write("원하시는 행동을 선택해주세요 >> ");

            input = Cal.CheckValidInput(1, i);
            Console.Clear();

            if (input == i) return;

            else if (items[input - 1].type == (ItemType.weapon) || items[input - 1].type == (ItemType.armor))
            {
                Console.WriteLine(items[input - 1].name);
                Console.WriteLine(items[input - 1].toolTip);
                Console.WriteLine();
                Console.WriteLine("1. 장비 장착");
                Console.WriteLine("2. 버리기");
                Console.WriteLine("3. 뒤로");
                Console.WriteLine("");
                Console.Write("원하시는 행동을 선택해주세요 >> ");

                int input2 = Cal.CheckValidInput(1, 3);
                Console.Clear();

                if (input2 == 3) return;
                if (input2 == 1)
                {
                    items[input - 1].Equip(this); return;
                }
                else if (input2 == 2)
                {
                    items[input - 1].Discard(this); return;
                }

            }
            else if (items[input - 1].type.Equals(ItemType.consumable))
            {
                Console.WriteLine(items[input - 1].name);
                Console.WriteLine(items[input - 1].toolTip);
                Console.WriteLine();
                Console.WriteLine("1. 소모품 사용");
                Console.WriteLine("2. 버리기");
                Console.WriteLine("3. 뒤로");
                Console.WriteLine("");
                Console.Write("원하시는 행동을 선택해주세요 >> ");


                int input2 = Cal.CheckValidInput(1, 3);
                Console.Clear();

                if (input2 == 3) return;
                else if (input2 == 1)
                {
                    items[input - 1].Use(this); return;
                }
                else if (input2 == 2)
                {
                    items[input - 1].Discard(this); return;
                }
            }
        }
    }


    public class Merchant : ICharacter
    {
        public string name { get; }
        public int health { get; set; }
        public int attack { get; set; }
        public int defense { get; set; }
        public int gold { get; set; }
        public bool isDead => health <= 0;

        public List<IItem> items { get; set; }

        public IItem weapon { get; set; }
        public IItem armor { get; set; }



        public Merchant(string name)
        {
            this.name = name;
            this.health = 10;
            this.attack = 2;
            this.defense = 0;
            this.gold = 1000;
            this.items = new List<IItem>();
            this.items.Add(new Stick());
            this.items.Add(new Sword());
            this.items.Add(new IronArmor());
            this.items.Add(new HealingPotion());
        }
    }

}
