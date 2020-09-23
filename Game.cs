using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    struct Item
    {
        public int cost;
        public string name;
    }
    class Game
    {
        private Player _player;
        private Shop _shop;
        private Item _arrow;
        private Item _shield;
        private Item _gem;
        private Item[] shopInventory;
        private bool _gameover;

        //Run the game
        public void Run()
        {
            Start();

            while (_gameover == false);
            {
                Update();
            }
            End();
        }

        private void InitItems()
        {
            _arrow.name = "Arrow";
            _arrow.cost = 10;

            _shield.name = "shield";
            _shield.cost = 15;

            _gem.name = "Gem";
            _gem.cost = 1000;
        }

        public void PrintInventory(Item[] inventory)
        {
            for(int i = 0; i < inventory.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + inventory[i].name + inventory[i].cost);
            }
        }

        private void OpenShopMenu()
        {
            //Buying Items
            Console.WriteLine("OI!! Hurry and pick sominm, eh!!");

            PrintInventory(shopInventory);
            char input = Console.ReadKey().KeyChar;
            int itemIndex = -1;
            switch (input)
            {
                case '1':
                    itemIndex = 0;
                    break;

                case '2':
                    itemIndex = 1;
                    break;

                case '3':
                    itemIndex = 2;
                    break;

                default:
                    return;

            }
            if (_player.GetGold() < shopInventory[itemIndex].cost)
            {
                Console.WriteLine("Get ya money up instead of ya funny up!");
                return;
            }

            Console.WriteLine("Where this goin?");

            PrintInventory(shopInventory);

             input = Console.ReadKey().KeyChar;
            int playerIndex = -1;
            switch (input)
            {
                case '1':
                    playerIndex = 0;
                    break;

                case '2':
                    playerIndex = 1;
                    break;

                case '3':
                    playerIndex = 2;
                    break;

                default:
                    return;

            }
            _shop.Sell(_player, itemIndex, playerIndex);
        }
             
        //Performed once when the game begins
        public void Start()
        {
            _gameover = false;
            _player = new Player();
            InitItems();
            shopInventory = new Item[] { _arrow, _shield, _gem };
            _shop = new Shop(shopInventory);
        }

        //Repeated until the game ends
        public void Update()
        {
            OpenShopMenu();
        }

        //Performed once when the game ends
        public void End()
        {
            
        }
    }
}
