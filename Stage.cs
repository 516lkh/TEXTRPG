using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXTRPG
{
    public class StageStart
    {

        private PlayerCharacter player;


        public StageStart(PlayerCharacter player)
        {
            this.player = player;
        }


        public void Start()
        {
            Console.WriteLine("게임 시작!\n");
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.\n");
            while (true)
            {
                Console.WriteLine("<스파르타 마을>\n");
                Console.WriteLine("1. 상점 가기");
                Console.WriteLine("2. 던전 가기");
                Console.WriteLine("3. 상태 보기");
                Console.WriteLine("4. 인벤토리 확인");
                Console.WriteLine("");
                Console.Write("원하시는 행동을 선택해주세요 >> ");

                int input = Cal.CheckValidInput(1, 4);
                Console.Clear();

                switch (input)
                {
                    case 1:
                        ICharacter merchant = new Merchant("상인");
                        StageShop shop = new StageShop(player, merchant);
                        shop.Start();
                        continue;
                    case 2:
                        Console.WriteLine("미완성입니다.");
                        continue;
                    case 3:
                        player.CaracterInfo();
                        continue;
                    case 4:
                        player.InventoryInfo();
                        continue;
                }

            }
        }
    }

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

            int i;


            

            while (true)
            {
                Console.WriteLine("<상점>\n");
                Console.WriteLine("1. 아이템을 산다");
                Console.WriteLine("2. 아이템을 판다");
                Console.WriteLine("3. 나간다");
                Console.WriteLine("");
                Console.Write("원하시는 행동을 선택해주세요 >> ");

                int input = Cal.CheckValidInput(1, 3);
                Console.Clear();
                

                switch (input)
                {
                    case 1:
                        
                        i = 0;
                        foreach (IItem item in merchant.items)
                        {
                            i++;
                            Console.WriteLine(i.ToString() + ". " + item.name +
                                " (" + item.price + " GOLD)");
                        }
                        Console.WriteLine((++i).ToString() + ". 뒤로");
                        Console.WriteLine("");
                        Console.Write("원하시는 행동을 선택해주세요 >> ");

                        input = Cal.CheckValidInput(1, i);
                        Console.Clear();
                        if (input == i) break;

                        Trade(player, merchant, merchant.items[input - 1]);

                        break;


                    case 2:
                        
                        i = 0;
                        foreach (IItem item in player.items)
                        {
                            i++;
                            Console.WriteLine(i.ToString() + ". " + item.name +
                                " (" + item.price + " GOLD)");
                        }
                        Console.WriteLine((++i).ToString() + ". 뒤로");
                        Console.WriteLine("");
                        Console.Write("원하시는 행동을 선택해주세요 >> ");

                        input = Cal.CheckValidInput(1, i);
                        Console.Clear();
                        if (input == i) break;

                        Trade(merchant, player, player.items[input - 1]);
                        break;


                    case 3:
                        return;

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

                Console.WriteLine(buyer.name + " : " + item.name + "을 샀습니다 \n" +
                    "(" + buyer.name + " 남은 골드 " + buyer.gold + ")\n" +
                    "(" + seller.name + " 남은 골드 " + seller.gold + ")\n");
            }
            else
            {
                Console.WriteLine(buyer.name + "의 돈이 부족합니다! \n" +
                    "(" + buyer.name + " 남은 골드 " + buyer.gold + ")\n" +
                    "(" + seller.name + " 남은 골드 " + seller.gold + ")\n");
            }
        }
    }
}
