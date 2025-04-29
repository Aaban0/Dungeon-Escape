using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Code.GameObjects
{
    internal class PoisonPotion : InventoryItem
    {
        public PoisonPotion()
        {
            DamagePoints = 1;
            SetSprite("potion_puce");
        }
        public PoisonPotion(string name, int healPoints, int damagePoints)
        {
            DamagePoints = damagePoints;
            SetSprite("potion_puce");
        }
        public override void Update(float deltaTime)
        {

        }

    }
}
