using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Code.GameObjects
{
    internal class InventoryManager : GameObject
    {
        /// <summary>
        /// 
        /// Inventory Manager allows for items to be stored for the player to be used later 
        /// The Inventroy Manager uses and array to store its items 
        /// When items are removed the algorithm finds an empty array index to store any new items picked up.
        /// 
        /// </summary>
        
        public int itemNum { get; set; }
        public InventoryItem[] InventoryItems { get; set; }

        public int currentItem {  get; set; }
        private const int CAPACITY = 4;

        // Inventory Manager constructor creates an array of items and 
        // deals with initialisation of the variables needed to track the
        // inventory
        public InventoryManager()
        {
            currentItem = 0;
            itemNum = 0;
            InventoryItems = new InventoryItem[CAPACITY];
            SetSprite("inventory");
            GetSprite().SetInWorldSpace(false);
            GetSprite().SetScale(2, 2);
            SetVisible(true);
            GetSprite().SetLayerDepth(10);
        }

        public override void Update(float deltaTime)
        {
            
        }

        //Method for addings in items to inventory 
        public bool AddItem(InventoryItem item)
        {
            bool added = false;

            //checks if there is space in the array
            if (itemNum < CAPACITY)
            {
                //adds an item if there is space 
                if (InventoryItems[itemNum] == null)
                {
                    InventoryItems[itemNum] = item;
                    //currentItem++;
                    itemNum++;
                    added = true;
                }
                else
                {
                    //loops for the length of the array
                    for (int i = 0; i < InventoryItems.Length; i++)
                    {
                        //if there is a space free after an item has been used 
                        if (InventoryItems[i] == null)
                        {
                            // gets position in for loop and increaes by 1
                            itemNum = i + 1;
                            InventoryItems[i] = item;
                            added = true;
                            break; // Exit the loop once the item is added
                        }
                    }
                }
            }

            return added;
        }

        // Item removed from the inventory by reference
        // If the item passed in is the same as an item in the inventory
        // Item is removed and it's space in array set to null
        public bool RemoveItem(InventoryItem item)
        {
            bool removed = false;

            for (int i = 0; i < InventoryItems.Length; i++)
            {
                if (InventoryItems[i] == item)
                {
                    InventoryItems[i] = null;
                    //itemNum--;
                    removed = true;
                    break;
                }
            }
            return removed;
        }
    }
}
