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
            HealPoints = 25;

            SetSprite("potion_2_ruby");
        }

        public Potion(string name, int healPoints, int damagePoints)
        {
            HealPoints = healPoints;
            SetSprite("potion_2_ruby");
        }

        public override void Update(float deltaTime)
        {
            
        }
    }
}
