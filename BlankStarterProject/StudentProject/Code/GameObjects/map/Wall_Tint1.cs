using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Code.GameObjects.map
{
    internal class Wall_Tint1 : GameObject
    {
        public Wall_Tint1()
        {
            SetSprite("_wall");
            GetSprite().SetLayerDepth(6);
            GetSprite().SetScale(3f, 3.7f);
            GetSprite().SetTint(200, 200, 200);
        }
        public override void Update(float deltaTime)
        {

        }
    }
}
