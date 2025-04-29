using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Code.GameObjects.map
{
    internal class Floor : GameObject
    {
        public Floor()
        {
            SetSprite("floor");
            GetSprite().SetScale(3, 3);
        }
        public override void Update(float deltaTime)
        {

        }
    }
}
