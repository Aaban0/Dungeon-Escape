using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Code.GameObjects
{
    internal class Wolf : Enemy
    {
        public bool _flip {  get; set; }

        public Wolf()
        {
            SetSprite("werewolf", 48, 64, 0.1f, new int[] { 3, 3, 3, 3 });
            GetSprite().SetScale(1.5f, 1.5f);
            GetSprite().SetLayerDepth(4);
            SetBounds(100, 100);
            SetVelocity(0, -3.0f);

            _flip = false;
        }

        public Wolf(int health, bool newFlip) : base(health)
        {
            //Health = health;
            SetSprite("werewolf", 48, 64, 0.1f, new int[] { 3, 3, 3, 3 });
            _flip = newFlip;
        }

        public override void Update(float deltatime)
        {
            Movement();
        }

        protected override void CheckCollisions()
        {
            if (IsTouching<Wall>())
            {
                SetVelocity(GetVelocity().X, GetVelocity().Y * -1);
            }
        }

        protected override void Movement()
        {
            base.Movement();

            CheckCollisions();

            if (IsTouching<Wall>() && _flip == false)
            {
                RevertPosition();
                GetAnimatedSprite().StartAnimation(2);
                _flip = true;
            }
            if (IsTouching<Wall>() && _flip == true)
            {
                RevertPosition();
                GetAnimatedSprite().StartAnimation(0);

                _flip = false;
            }
        }
    }
}
