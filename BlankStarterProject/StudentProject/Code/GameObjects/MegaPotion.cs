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
            HealPoints = 2;
            SetSprite("potion_gold");
        }
        public MegaPotion(string name, int healPoints, int damagePoints)
        {
            HealPoints = healPoints;
            SetSprite("potion_gold");
        }

        public override void Update(float deltaTime)
        {

        }
    }
}
