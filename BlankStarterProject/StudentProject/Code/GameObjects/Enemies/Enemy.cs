using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Code.GameObjects
{
    internal class Enemy : GameObject
    {
        public int Health {  get; set; }

        public Enemy()
        {
            Health = 100;
        }

        public Enemy(int health)
        {
            Health = health;
        }

        public override void Update(float deltaTime)
        {
            Movement();
        }

        protected virtual void CheckCollisions(){ }
        protected virtual void Movement() { SetPosition(GetPosition() + GetVelocity()); }

        

    }
}
