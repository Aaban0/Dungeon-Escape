using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Code.GameObjects.map
{
    internal class Floor1 : GameObject
    {
        //sets the floor sprite, the scale and the order in layer
        //also sets bounds to prevent it from dissapering while on screen, becasue the scale is increased
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
