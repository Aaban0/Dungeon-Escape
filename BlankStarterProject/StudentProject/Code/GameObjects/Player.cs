using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Code.GameObjects
{
    internal class Player : GameObject
    {
        public int _lives {  get; set; }
        public bool death {  get; set; }
        private int _speed { get; set; }

        public InventoryManager inventoryManager { get; set; }
        public InventoryItem currentItem{ get; set; }

        public Player()
        {
            inventoryManager = new InventoryManager();
            currentItem = null;

            //Sets up players inital sprite
            SetSprite("user", 48, 64, 0.1f, new int[] { 3, 3, 3, 3 }, LoopType.None);
            death = false;
            _lives = 3;
            _speed = 4;
        }

        public override void Update(float deltaTime)
        {
            ItemCheck();

            CheckForObstacles();
            HandleInputs();

            PlayerCollision();
        }
        private void ItemCheck()
        {
            InventoryItem inventoryItem = (InventoryItem)GetOneIntersectingObject<InventoryItem>();
            if (inventoryItem is InventoryItem)
            {
                if (GameInput.IsKeyPressed("e"))
                {
                    InventoryItem ii = (InventoryItem)inventoryItem;
                    ItemPickUp(ii);
                }
            }
        }

        public void ItemPickUp(InventoryItem item)
        {
            if (inventoryManager.AddItem(item))
            {
                //item.SetVisible(false);
                item.GetSprite().SetInWorldSpace(false);
                item.GetSprite().SetScale(2, 2);
                item.SetPosition(new Vector2(1557.5f, 57));
                currentItem = item;
            }
        }

        public void UseItem()
        {
            InventoryItem potion = (InventoryItem)currentItem;
            _lives += potion.HealPoints;
            currentItem = null;
            inventoryManager.RemoveItem(potion);
            potion.GetSprite().SetInWorldSpace(true);
            potion.SetVisible(false);
        }

        private void CheckForObstacles()
        {
            if (IsTouching<Wall>())
            {
                RevertPosition();
            }
        }

        private void PlayerCollision()
        {
            Enemy enemy = (Enemy)GetOneObjectAtOffset<Enemy>(0, 0);

            if (enemy != null)
            {
                _lives--;
                death = true;
            }
            else
            {
                death = false;
            }

            if (_lives == 0)
            {
                Transition.Instance.ToScreen<DeathScreen>();
            }
        }

        private void HandleInputs()
        {
            if (GameInput.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.D1))
            {
                //prevents program break if there are no items 
                if (currentItem != null)
                {
                    UseItem();
                }
            }
            if (GameInput.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.D2))
            {
                currentItem = inventoryManager.GetItem2();
                //prevents program break if there are no items 
                if (currentItem != null && inventoryManager.currentItem == 1)
                {
                    //edit this if statement
                    //test 1 potion at a time 
                    //test 2 potions then 2, 1
                    //test 2 potions then 1, 2
                    UseItem();
                }
            }


            if (GameInput.IsKeyPressed("W"))
            {
                SetSprite("user", 48, 64, 0.1f, new int[] { 3, 3, 3, 3 }, LoopType.None);
                GetAnimatedSprite().StartAnimation(0);
                CheckForObstacles();
            }
            else if (GameInput.IsKeyHeld("W"))
            {
                SetPosition(GetX(), GetY() - _speed);
                CheckForObstacles();
            }
            else if (GameInput.IsKeyReleased("W"))
            {
                GetAnimatedSprite().StartAnimation(0, null, LoopType.None);
                //GetAnimatedSprite().SetPaused(true);
                CheckForObstacles();
            }


            if (GameInput.IsKeyPressed("S"))
            {
                SetSprite("user", 48, 64, 0.1f, new int[] { 3, 3, 3, 3 }, LoopType.None);
                GetAnimatedSprite().StartAnimation(2);
                CheckForObstacles();
            }
            else if (GameInput.IsKeyHeld("S"))
            {
                SetPosition(GetX(), GetY() + _speed);
                CheckForObstacles();
            }
            else if (GameInput.IsKeyReleased("S"))
            {
                GetAnimatedSprite().StartAnimation(2, null, LoopType.None);
            }


            if (GameInput.IsKeyPressed("A"))
            {
                SetSprite("user", 48, 64, 0.1f, new int[] { 3, 3, 3, 3 }, LoopType.None);
                GetAnimatedSprite().StartAnimation(3);
                CheckForObstacles();
            }
            else if (GameInput.IsKeyHeld("A"))
            {
                SetPosition(GetX() - _speed, GetY());
            }
            else if (GameInput.IsKeyReleased("A"))
            {
                GetAnimatedSprite().StartAnimation(3, null, LoopType.None);
                //GetAnimatedSprite().SetPaused(true);
                CheckForObstacles();
            }

            if (GameInput.IsKeyPressed("D"))
            {
                SetSprite("user", 48, 64, 0.1f, new int[] { 3, 3, 3, 3 }, LoopType.None);
                GetAnimatedSprite().StartAnimation(1);
            }
            else if (GameInput.IsKeyHeld("D"))
            {
                SetPosition(GetX() + _speed, GetY());
                CheckForObstacles();
            }
            else if (GameInput.IsKeyReleased("D"))
            {
                GetAnimatedSprite().StartAnimation(1, null, LoopType.None);
            }
        }

        public bool Death()
        {
            return death;
        }

        public int Lives()
        {
            return _lives;
        }
    }

}
