using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Player
    {
        private int _gold;
        private Item[] _inventory;


        public Player()
        {
            _gold = 100;
            //New array
            _inventory = new Item[3];
        }
                //Shield             0
        public bool Buy(Item item, int inventoryIndex)
        {
            if(_gold >= item.cost)
            {
                //Pays for item
                _gold -= item.cost;
                _inventory[inventoryIndex] = item;
                return true;
            }
            return false;
        }
        public int GetGold()
        {
            return _gold;
        }
        public Item[] GetInventory()
        {
            return _inventory;
        }



    }
}
