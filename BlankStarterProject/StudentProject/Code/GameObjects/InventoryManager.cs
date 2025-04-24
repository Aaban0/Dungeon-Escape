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
                InventoryItems[currentItem] = item;
                currentItem++;
                itemNum++;
            }

            return added;
        }
    }
}
