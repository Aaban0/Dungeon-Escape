using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Code.GameObjects
{
    internal class InventoryManager : GameObject
    {
        public int itemNum { get; set; }
        public InventoryItem[] InventoryItems { get; set; }

        public int currentItem {  get; set; }
        private const int CAPACITY = 4;

        public InventoryManager()
        {
            currentItem = 0;
            itemNum = 0;
            InventoryItems = new InventoryItem[CAPACITY];
            SetSprite("inventory");
            GetSprite().SetInWorldSpace(false);
            GetSprite().SetScale(2, 2);
            SetVisible(true);
        }

        public override void Update(float deltaTime)
        {
            
        }

        public bool AddItem(InventoryItem item)
        {
            bool added = false;

            if (itemNum < CAPACITY)
            {
                InventoryItems[itemNum] = item;
                currentItem++;
                itemNum++;
                added = true;
            }

            return added;
        }

        public bool RemoveItem(InventoryItem item)
        {
            bool removed = false;

            for (int i = 0; i < InventoryItems.Length; i++)
            {
                if (InventoryItems[i] == item)
                {
                    InventoryItems[i] = null;
                    itemNum--;
                    removed = true;
                    break;
                }
            }
            return removed;
        }

        public InventoryItem GetItem2()
        {
            /*for (int i = 0; i < InventoryItems.Length; i++)
            {
                if (InventoryItems.Length > 1)
                {
                    InventoryItems[i] = null;
                    currentItem = 1;
                }
            }*/
            return InventoryItems[currentItem];
        }

        // Get the previous item in the inventory
        public InventoryItem GetPreviousItem()
        {
            currentItem--;

            if (currentItem < 0)
                currentItem = - 1;

            return InventoryItems[currentItem];
        }

        public InventoryItem TakeItem(int itemIndex)
        {
            return InventoryItems[itemIndex];
        }

    }
}
