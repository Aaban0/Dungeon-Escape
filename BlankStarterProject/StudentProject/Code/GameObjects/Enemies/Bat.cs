using StudentProject.Code.GameObjects.map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Code.GameObjects
{
    //Inherits from Enemy 
    internal class Bat : Enemy
    {
        //variable for bat speed
        public int _speed {  get; set; }

        public Bat()
        {
            //set sprite, velocity and the order in layer
            SetSprite("bat", 48, 64, 0.1f, new int[] { 3, 3, 3, 3 });
            SetVelocity(4.0f, 0);
            GetSprite().SetLayerDepth(6);

            //speed is also set
            _speed = 5;
        }

        public Bat(int health, int speed) : base(health)
        {
            //overloaded constructer for bat
            SetSprite("bat", 48, 64, 0.1f, new int[] { 3, 3, 3, 3 });
            SetVelocity(4.0f, 0);
            GetSprite().SetLayerDepth(6);

            _speed = speed;
        }

        public override void Update(float deltatime)
        {
            Movement();
        }

        protected override void CheckCollisions()
        {
            //if bat touches wall then changes positions
            if (IsTouching<Wall>())
            {
                RevertPosition();
            }
        }

        protected override void Movement()
        {
            //if a valid random number is picked 
            int moveDirection = Core.GetRandomNumber(4);
            switch (moveDirection)
            {
                case 0: // move right
                    SetPosition(GetX() + _speed, GetY());
                    break;
                case 1://moves left
                    SetPosition(GetX() - _speed, GetY());
                    break;
                case 2://moves down
                    SetPosition(GetX(), GetY() + _speed);
                    break;
                case 3://moves up
                    SetPosition(GetX(), GetY() - _speed);
                    break;
            }

            //method for if enemy is touching the wall or edge of the screen
            CheckCollisions();
        }
    }
}
