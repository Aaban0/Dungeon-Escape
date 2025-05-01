using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Code.GameObjects
{
    internal class Potion : InventoryItem
    {
        public Potion() : base()
        {
            //constructor sets the health points, sprite and order in layer

            HealPoints = 1;

            SetSprite("potion_2_ruby");
            GetSprite().SetLayerDepth(7);
        }

        public Potion(string name, int healPoints, int damagePoints)
        {
            //overloaded constructor for the potion 
            HealPoints = healPoints;
            SetSprite("potion_2_ruby");
        }

        public override void Update(float deltaTime)
        {
            
        }
    }
}
