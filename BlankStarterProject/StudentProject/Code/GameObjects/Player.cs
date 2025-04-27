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

            EnemyAttack();
            PlayerCollision();
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
            Enemy enemy = (Enemy)GetOneIntersectingObject<Enemy>();
            if (enemy is Enemy)
            {
                if (GameInput.IsKeyPressed("e"))
                {
                    GetScreen().RemoveObject(enemy);
                }
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
