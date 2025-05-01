using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Code.GameObjects
{
    internal class MegaPotion : InventoryItem
    {
        public MegaPotion() : base() 
        {
            //constructor sets the health points, sprite and order in layer
            HealPoints = 2;
            SetSprite("potion_gold");
            GetSprite().SetLayerDepth(7);
        }
        public MegaPotion(string name, int healPoints, int damagePoints)
        {
            //overloaded constructor for the mega potion 
            HealPoints = healPoints;
            SetSprite("potion_gold");
        }

        public override void Update(float deltaTime)
        {

        }
    }
}
