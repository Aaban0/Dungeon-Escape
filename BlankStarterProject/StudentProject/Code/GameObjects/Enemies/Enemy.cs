using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Code.GameObjects
{
    internal class Enemy : GameObject
    {
        // partent class for enemies 

        //variable for health 
        public int Health {  get; set; }

        //health is equal to 1
        public Enemy()
        {
            Health = 1;
        }

        public Enemy(int health)
        {
            Health = health;
        }

        public override void Update(float deltaTime)
        {
            Movement();
        }

        //editable methods for enemy 
        protected virtual void CheckCollisions(){ }
        protected virtual void Movement() { SetPosition(GetPosition() + GetVelocity()); }

        

    }
}
