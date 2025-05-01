using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Code.GameObjects
{
    internal class Wall : GameObject
    {
        public Wall()
        {
            //sets the sprite and the scale 
            //sets the tint and also the order in layer
            SetSprite("_wall");
            GetSprite().SetScale(3f, 3.7f);
            GetSprite().SetTint(230, 230, 230);
            GetSprite().SetLayerDepth(9);
        }

        public override void Update(float deltaTime)
        {

        }
    }
}
