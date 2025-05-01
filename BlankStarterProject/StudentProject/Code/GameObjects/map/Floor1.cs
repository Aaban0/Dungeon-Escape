using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Code.GameObjects.map
{
    internal class Floor1 : GameObject
    {
        public Floor1()
        {
            SetSprite("floor1");
            GetSprite().SetScale(5, 5);
            GetSprite().SetLayerDepth(7);
            SetBounds(1000, 1000);
        }
        public override void Update(float deltaTime)
        {

        }
    }
}
