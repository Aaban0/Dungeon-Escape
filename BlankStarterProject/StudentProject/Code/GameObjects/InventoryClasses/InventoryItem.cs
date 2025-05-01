using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Code.GameObjects
{
    internal class InventoryItem : GameObject
    {
        //partent class for the inventory items 

        //variables for the items
        public int HealPoints {  get; set; }
        public int DamagePoints { get; set; }
        public string Name { get; set; }

        public InventoryItem()
        {
            Name = string.Empty;
        }

        public InventoryItem(string name, int healPoints, int damagePoints)
        {
            //overloaded constructor for the inventory items 
            //takes in the parameters of name, health and damage
            Name = name;
            HealPoints = healPoints;
            DamagePoints = damagePoints;
        }

        public override void Update(float deltaTime)
        {
            
        }
    }
}
