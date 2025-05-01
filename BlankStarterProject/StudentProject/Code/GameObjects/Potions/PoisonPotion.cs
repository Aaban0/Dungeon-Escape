using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Code.GameObjects
{
    //Inherits from Inventory Item 
    internal class PoisonPotion : InventoryItem
    {
        public PoisonPotion()
        {
            //constructor sets the damage points, sprite and order in layer
            DamagePoints = 1;
            SetSprite("potion_puce");
            GetSprite().SetLayerDepth(7);
        }
        public PoisonPotion(string name, int healPoints, int damagePoints)
        {
            //overloaded constructor for the poison potion 
            DamagePoints = damagePoints;
            SetSprite("potion_puce");
        }
        public override void Update(float deltaTime)
        {

        }

    }
}
