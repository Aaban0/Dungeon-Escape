using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Code.GameObjects
{
    internal class KeyManager : GameObject
    {
        private Player _player;
        private Key _key;

        public KeyManager()
        {
            _player = new Player();
            _key = new Key();

            SetSprite("frame");
            GetSprite().SetInWorldSpace(false);
            GetSprite().SetScale(2, 2);
        }

        public override void Update(float deltaTime)
        {
            MoveKey();
        }

        private void MoveKey()
        {
            if (_player.GetKeys() == 1)
            {
                
            }
        }
    }
}
