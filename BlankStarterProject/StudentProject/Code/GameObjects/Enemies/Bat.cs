using StudentProject.Code.GameObjects.map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Code.GameObjects
{
    internal class Bat : Enemy
    {
        public int _speed {  get; set; }

        public Bat()
        {
            //set sprite 
            SetSprite("bat", 48, 64, 0.1f, new int[] { 3, 3, 3, 3 });
            SetVelocity(4.0f, 0);
            GetSprite().SetLayerDepth(6);

            _speed = 5;
        }

        public Bat(int health, int speed) : base(health)
        {
            SetSprite("werewolf", 48, 64, 0.1f, new int[] { 3, 3, 3, 3 });

            _speed = speed;
        }

        public override void Update(float deltatime)
        {
            Movement();
        }

        protected override void CheckCollisions()
        {
            if (IsTouching<Wall>() || IsTouching<Wall_Left>() || IsTouching<Wall_Right>())
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
