using StudentProject.Code.GameObjects.map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Code.GameObjects
{
    internal class Mummy : Enemy
    {
        public bool _flip { get; set; }

        public Mummy()
        {
            SetSprite("mummy", 48, 64, 0.1f, new int[] { 3, 3, 3, 3 });
            GetAnimatedSprite().StartAnimation(1);
            GetSprite().SetLayerDepth(4);
            SetBounds(100, 100);

            SetVelocity(3.0f, 0);
            _flip = false;
        }

        public Mummy(int health, bool newFlip) : base(health)
        {
            SetSprite("mummy", 48, 64, 0.1f, new int[] { 3, 3, 3, 3 });
            GetAnimatedSprite().StartAnimation(1);

            _flip = newFlip;
        }

        public override void Update(float deltaTime)
        {
            Movement();
        }

        protected override void CheckCollisions()
        {
            if (IsTouching<Wall>())
            {
                SetVelocity(GetVelocity().X * -1, GetVelocity().Y);
            }
        }

        protected override void Movement()
        {
            base.Movement();

            CheckCollisions();

            if (/*IsTouching<Wall_Left>() || */IsTouching<Wall>() && _flip == false)
            {
                RevertPosition();
                GetAnimatedSprite().StartAnimation(3);
                _flip = true;
            }
            if (IsTouching<Wall>() /*|| IsTouching<Wall_Right>() */&& _flip == true)
            {
                RevertPosition();
                GetAnimatedSprite().StartAnimation(1);

                _flip = false;
            }
        }
    }
}
