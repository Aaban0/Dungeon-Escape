using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Code.GameObjects
{
    internal class KeyManager : GameObject
    {
        public KeyManager()
        {
            //sets the sprite, world space and the scale
            SetSprite("frame");
            GetSprite().SetInWorldSpace(false);
            GetSprite().SetScale(2, 2);
        }

        public override void Update(float deltaTime)
        {

        }
    }
}
