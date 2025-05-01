using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Code.GameObjects
{
    internal class Door : GameObject
    {
        public Door()
        {
            //Sets sprite and scale
            SetSprite("door locked");
            GetSprite().SetScale(5, 5);
        }
        private void DoorCollison()
        {
            //if player is touching the door it calls player.DoorCollision
            Player player = (Player)GetOneIntersectingObject<Player>();
            if (player != null)
            {
                player.DoorCollision();
            }
        }

        public override void Update(float deltaTime)
        {
            DoorCollison();
        }
    }
}
