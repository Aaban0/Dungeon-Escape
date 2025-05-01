using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Code.GameObjects.map
{
    internal class Wall_Tint2 : GameObject
    {
        public Wall_Tint2()
        {
            //sets the sprite and the scale 
            //sets the tint and also the order in layer
            SetSprite("_wall");
            GetSprite().SetScale(3f, 3.7f);
            GetSprite().SetTint(140, 140, 140);
            GetSprite().SetLayerDepth(5);
        }
        public override void Update(float deltaTime)
        {

        }
    }
}
