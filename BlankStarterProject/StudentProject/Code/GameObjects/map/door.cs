using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Code.GameObjects.map
{
    internal class door : GameObject
    {
        public door()
        {
            SetSprite("door locked");
        }

        public override void Update(float deltaTime)
        {

        }
    }
}
