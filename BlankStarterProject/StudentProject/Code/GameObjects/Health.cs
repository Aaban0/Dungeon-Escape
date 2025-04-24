using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Code.GameObjects
{
    internal class Health : GameObject
    {
        public int _health {  get; set; }

        public Health()
        {
            //sets sprite and not set in game world
            SetSprite("Heart");
            GetSprite().SetInWorldSpace(false);
        }

        public override void Update(float deltaTime)
        {
            //nothing is done so kept empty 
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            //implementing new rendering code using a For Loop

            //HealthDisplay’s sprite holds on to that texture.
            //Draw() takes a position on-screen to draw at
            //Draw() takes a colour to draw with
            for (int i = 0; i < _health; i++)
            {
                spriteBatch.Draw(GetSprite().GetTexture(), new Vector2(GetX() + (i * GetSprite().GetWidth()), GetY()), Colour.White);
            }
        }

        public void SetHealth(int health)
        {
            //Keeps in sync with the players lives
            _health = health;
        }
    }
}
