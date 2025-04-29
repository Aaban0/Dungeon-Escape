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
            SetSprite("row up");
        }

        public override void Update(float deltaTime)
        {

        }
    }
}
