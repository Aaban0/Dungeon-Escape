using Microsoft.Xna.Framework.Input;
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
        private bool _flipped { get; set; }
        private int _keys {  get; set; }
        private bool _doorCollision { get; set; }

        public InventoryManager inventoryManager { get; set; }
        public InventoryItem currentItem1 { get; set; }
        public InventoryItem currentItem2 { get; set; }
        public InventoryItem currentItem3 { get; set; }
        public InventoryItem currentItem4 { get; set; }

        public Player()
        {
            inventoryManager = new InventoryManager();
            currentItem1 = null;
            currentItem2 = null;
            currentItem3 = null;
            currentItem4 = null;

            //Sets up players inital sprite
            SetSprite("Priest", 32, 32, 0.1f, new int[] { 10, 10, 10, 10, 10 }, LoopType.Bounce);
            GetSprite().SetScale(2, 2);

            death = false;
            _lives = 3;
            _speed = 4;
            _flipped = false;
            _doorCollision = false;
            _keys = 0;
        }

        public override void Update(float deltaTime)
        {
            ItemCheck();
            DoorCheck();

            CheckForObstacles();
            HandleInputs();

            EnemyAttack();
            PlayerCollision();

            KeyCheck();
        }
        private void ItemCheck()
        {
            InventoryItem inventoryItem = (InventoryItem)GetOneIntersectingObject<InventoryItem>();
            if (inventoryItem is InventoryItem)
            {
                if (GameInput.IsKeyPressed("q"))
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

                /*if (inventoryManager.InventoryItems.Length > 0)
                {
                    currentItem1 = item;
                    inventoryManager.InventoryItems[0] = currentItem1;
                }*/

                for (int i = 0; i < inventoryManager.InventoryItems.Length; i++)
                {
                    if (inventoryManager.InventoryItems[0] == item)
                    {
                        currentItem1 = item;
                    }
                    if (inventoryManager.InventoryItems[1] == item)
                    {
                        currentItem2 = item;
                    }
                    if (inventoryManager.InventoryItems[2] == item)
                    {
                        currentItem3 = item;
                    }
                    if (inventoryManager.InventoryItems[3] == item)
                    {
                        currentItem4 = item;
                    }
                }

                /*currentItem1 = item;
                currentItem1 = inventoryManager.InventoryItems[0];*/

                if (inventoryManager.itemNum > 1 /*&& currentItem != null*/)
                {
                    item.SetPosition(new Vector2(1557.5f + 75, 57));
                }
                if (inventoryManager.itemNum > 2)
                {
                    item.SetPosition(new Vector2(1557.5f + 150, 57));
                }
                if (inventoryManager.itemNum > 3)
                {
                    item.SetPosition(new Vector2(1557.5f + 225, 57));
                }
            }
        }

        public void UseItem1()
        {
            InventoryItem potion = (InventoryItem)currentItem1;
            _lives += potion.HealPoints;
            _lives -= potion.DamagePoints;
            currentItem1 = null;
            inventoryManager.itemNum = 0;
            inventoryManager.RemoveItem(potion);
            potion.GetSprite().SetInWorldSpace(true);

            potion.SetActive(false);
            GetScreen().RemoveObject(potion);
        }
        public void UseItem2()
        {
            InventoryItem potion = (InventoryItem)currentItem2;
            _lives += potion.HealPoints;
            _lives -= potion.DamagePoints;
            currentItem2 = null;
            inventoryManager.itemNum = 1;
            inventoryManager.RemoveItem(potion);
            potion.GetSprite().SetInWorldSpace(true);

            potion.SetActive(false);
            GetScreen().RemoveObject(potion);
        }
        public void UseItem3()
        {
            InventoryItem potion = (InventoryItem)currentItem3;
            _lives += potion.HealPoints;
            _lives -= potion.DamagePoints;
            currentItem3 = null;
            inventoryManager.itemNum--;
            inventoryManager.RemoveItem(potion);
            potion.GetSprite().SetInWorldSpace(true);

            potion.SetActive(false);
            GetScreen().RemoveObject(potion);
        }
        public void UseItem4()
        {
            InventoryItem potion = (InventoryItem)currentItem4;
            _lives += potion.HealPoints;
            _lives -= potion.DamagePoints;
            currentItem4 = null;
            inventoryManager.RemoveItem(potion);
            potion.GetSprite().SetInWorldSpace(true);

            potion.SetActive(false);
            GetScreen().RemoveObject(potion);
        }

        private void EnemyAttack()
        {
            if (GameInput.IsKeyPressed("e"))
            {
                SetSprite("Priest", 32, 32, 0.1f, new int[] { 10, 10, 10, 10, 10 }, LoopType.None);
                GetSprite().SetScale(2, 2);
                GetAnimatedSprite().StartAnimation(3, 0.01f, LoopType.None);
            }
            if (GameInput.IsKeyPressed("e") && _flipped == true)
            {
                SetSprite("Priest", 32, 32, 0.1f, new int[] { 10, 10, 10, 10, 10 }, LoopType.None);
                GetSprite().SetScale(2, 2);
                GetAnimatedSprite().StartAnimation(3, 0.01f, LoopType.None);
                GetSprite().FlipHorizontally(true);
            }

            Enemy enemy = (Enemy)GetOneIntersectingObject<Enemy>();
            if (enemy is Enemy)
            {
                if (GameInput.IsKeyPressed("e"))
                {
                    GetScreen().RemoveObject(enemy);
                }
            }
        }

        private void DoorCheck()
        {
            Door door = (Door)GetOneIntersectingObject<Door>();
            if (door != null)
            {
                //if player is touching door then variable set to true
                _doorCollision = true;
            }
        }

        private void KeyCheck()
        {
            GameObject key = GetOneIntersectingObject<Key>();
            if (key != null)
            {
                //if player touches key then keys = +1 and key gets removed
                GetScreen().RemoveObject(key);
                _keys++;
            }
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
                if (currentItem1 is InventoryItem || currentItem1 != null)
                {
                    UseItem1();
                    //currentItem1 = inventoryManager.InventoryItems[0];
                }
            }
            if (GameInput.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.D2))
            {
                //prevents program break if there are no items
                if (currentItem2 is InventoryItem || currentItem2 != null)
                {
                    UseItem2();
                }
            }
            if (GameInput.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.D3))
            {
                //prevents program break if there are no items
                if (currentItem3 is InventoryItem || currentItem3 != null)
                {
                    UseItem3();
                }
            }
            if (GameInput.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.D4))
            {
                //prevents program break if there are no items
                if (currentItem4 is InventoryItem || currentItem4 != null)
                {
                    UseItem4();
                }
            }


            if (GameInput.IsKeyPressed("W"))
            {
                CheckForObstacles();
            }
            else if (GameInput.IsKeyHeld("W"))
            {
                SetPosition(GetX(), GetY() - _speed);
                CheckForObstacles();
            }
            else if (GameInput.IsKeyReleased("W"))
            {

            }


            if (GameInput.IsKeyPressed("S"))
            {
                CheckForObstacles();
            }
            else if (GameInput.IsKeyHeld("S"))
            {
                SetPosition(GetX(), GetY() + _speed);
                CheckForObstacles();
            }
            else if (GameInput.IsKeyReleased("S"))
            {

            }


            if (GameInput.IsKeyPressed("A"))
            {
                SetSprite("Priest", 32, 32, 0.05f, new int[] { 10, 10, 10, 10, 10 }, LoopType.None);
                GetSprite().SetScale(2, 2);
                GetAnimatedSprite().StartAnimation(2, 0.05f, LoopType.Bounce);

                _flipped = true;
                CheckForObstacles();
            }
            else if (GameInput.IsKeyHeld("A"))
            {
                SetPosition(GetX() - _speed, GetY());

                GetSprite().FlipHorizontally(true);
                _flipped = true;
                CheckForObstacles();
            }
            else if (GameInput.IsKeyReleased("A"))
            {
                SetSprite("Priest", 32, 32, 0.1f, new int[] { 10, 10, 10, 10, 10 }, LoopType.None);
                //GetAnimatedSprite().StartAnimation(0, 0.1f, LoopType.Bounce);
                GetSprite().SetScale(2, 2);

                GetSprite().FlipHorizontally(true);
                _flipped = true;
                CheckForObstacles();
            }

            if (GameInput.IsKeyPressed("D"))
            {
                SetSprite("Priest", 32, 32, 0.05f, new int[] { 10, 10, 10, 10, 10 }, LoopType.None);
                GetSprite().SetScale(2, 2);
                GetAnimatedSprite().StartAnimation(2, 0.05f, LoopType.Bounce);

                _flipped = false;
                CheckForObstacles();
            }
            else if (GameInput.IsKeyHeld("D"))
            {
                SetPosition(GetX() + _speed, GetY());

                GetSprite().FlipHorizontally(false);
                _flipped = false;
                CheckForObstacles();
            }
            else if (GameInput.IsKeyReleased("D"))
            {
                SetSprite("Priest", 32, 32, 0.1f, new int[] { 10, 10, 10, 10, 10 }, LoopType.None);
                //GetAnimatedSprite().StartAnimation(0, 0.1f, LoopType.Bounce);
                GetSprite().SetScale(2, 2);

                GetSprite().FlipHorizontally(false);
                _flipped = false;
                CheckForObstacles();
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

        public bool DoorCollision()
        {
            return _doorCollision;
        }
        public int GetKeys()
        {
            return _keys;
        }
    }

}
