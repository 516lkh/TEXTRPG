using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXTRPG
{
    public class StageShop
    {
        private ICharacter player;
        private ICharacter merchant;

        public delegate void GameEvent(ICharacter player, ICharacter merchant);
        public event GameEvent PlayerBuy;
        public event GameEvent PlayerSell;

        public StageShop(ICharacter player, ICharacter merchant)
        {
            this.player = player;
            this.merchant = merchant;
        }

        public void Start()
        {
            string input;
            int i;


            Console.WriteLine("상점 도착!");

            while (true)
            {
                Console.WriteLine("1. 아이템을 산다");
                Console.WriteLine("2. 아이템을 판다");
                Console.WriteLine("3. 나간다");

                input = Console.ReadLine();
                switch(int.Parse(input)) 
                {
                    case 1:
                        i = 0;
                        foreach (IItem item in merchant.items)
                        {
                            i++;
                            Console.WriteLine(i.ToString() + ". " + item.name + 
                                " (" + item.price + " GOLD)");
                        }
                        input = Console.ReadLine();

                        Trade(player, merchant, merchant.items[int.Parse(input)-1]);

                        break;
                    case 2:
                        i = 0;
                        foreach (IItem item in player.items)
                        {
                            i++;
                            Console.WriteLine(i.ToString() + ". " + item.name + 
                                " (" + item.price + " GOLD)");
                        }
                        input = Console.ReadLine();

                        Trade(merchant, player, player.items[int.Parse(input) - 1]);
                        break;
                    case 3:
                        return;
                    default: 
                        Console.WriteLine("잘못 선택했습니다");
                        continue;
                }

            }

        }


        private void Trade(ICharacter buyer, ICharacter seller, IItem item)
        {
            if (buyer.gold >= item.price)
            {
                buyer.gold -= item.price;
                buyer.items.Add(item);
                seller.gold += item.price;
                seller.items.Remove(item);
                Console.WriteLine(item.name + "을 샀습니다 " +
                    "(" + buyer.name + " 남은 골드 " + buyer.gold + ")\n" +
                    seller.name + " 남은 골드 " + seller.gold + ")\n");
            } else { Console.WriteLine(buyer.name + "의 돈이 부족합니다! " +
                "(" + buyer.name + " 남은 골드 " + buyer.gold + ")\n" +
                    seller.name + " 남은 골드 " + seller.gold + ")\n"); }
        }
    }
}
