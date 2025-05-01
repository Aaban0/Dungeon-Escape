using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Code.GameObjects.map
{
    internal class Wall_Tint3 :GameObject
    {
        public Wall_Tint3()
        {
            //sets the sprite and the scale 
            //sets the tint and also the order in layer
            SetSprite("_wall");
            GetSprite().SetScale(3f, 3.7f);
            GetSprite().SetTint(70, 70, 70);
            GetSprite().SetLayerDepth(6);
        }
        public override void Update(float deltaTime)
        {

        }
    }
}
