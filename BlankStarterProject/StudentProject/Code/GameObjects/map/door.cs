using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Code.GameObjects.map
{
    internal class door : GameObject
    {
        //initial sprite for the locked door
        public door()
        {
            SetSprite("door locked");
        }

        public override void Update(float deltaTime)
        {

        }
    }
}
