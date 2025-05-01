using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Code.GameObjects
{
    internal class Key : GameObject
    {
        public Key()
        {
            //Sets Sprite and order in layer
            SetSprite("Key");
            GetSprite().SetLayerDepth(1);
        }
        public override void Update(float deltaTime)
        {

        }
    }
}
