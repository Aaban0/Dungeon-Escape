using Microsoft.Xna.Framework.Input;
using StudentProject.Code.GameObjects.map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Code.GameObjects
{
    internal class Player : GameObject
    {
        //variables for the player
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
            //sets positions to null
            inventoryManager = new InventoryManager();
            currentItem1 = null;
            currentItem2 = null;
            currentItem3 = null;
            currentItem4 = null;

            //Sets up players inital sprite and animation
            //sets the order in layer and the scale
            //sets the bounds becasue the scale is changed 
            SetSprite("Priest", 32, 32, 0.1f, new int[] { 10, 10, 10, 10, 10 }, LoopType.Bounce);
            GetSprite().SetScale(2, 2);
            GetSprite().SetLayerDepth(4);
            SetBounds(10,10);

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
            //if player is close to an item and presses q
            //player can pick up the item
            InventoryItem inventoryItem = (InventoryItem)GetOneIntersectingObject<InventoryItem>();
            if (inventoryItem is InventoryItem)
            {
                if (GameInput.IsKeyPressed("q"))
                {
                    InventoryItem ii = (InventoryItem)inventoryItem;
                    ItemPickUp(ii);
                    AudioManager.Instance.PlaySFX("PotionPickUp");
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

                //sets the items to the position in the arrays (so individual key is mapped) - this is later in the scirpt
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

                //sets the position of the items in the world once collected

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

        /// <summary>
        /// 
        /// this manages the item use process
        /// 
        /// first adds the health points or deducts the damage points depending on the potion.
        /// Then sets the current position of the item in the array to null. 
        /// Then sets the item number in the array. It removes the item in the array and sets it's world position to false.
        /// finally sets the potion to innactive and plays an audio clip of using the potion 
        /// 
        /// This process is repeated for all elements in the array.
        /// 
        /// </summary>

        public void UseItem1()
        {
            InventoryItem potion = (InventoryItem)currentItem1;
            _lives += potion.HealPoints;
            _lives -= potion.DamagePoints;
            currentItem1 = null;
            inventoryManager.itemNum = 0;
            inventoryManager.RemoveItem(potion);
            potion.GetSprite().SetInWorldSpace(false);

            potion.SetActive(false);
            GetScreen().RemoveObject(potion);

            AudioManager.Instance.PlaySFX("UsePotion");
        }
        public void UseItem2()
        {
            InventoryItem potion = (InventoryItem)currentItem2;
            _lives += potion.HealPoints;
            _lives -= potion.DamagePoints;
            currentItem2 = null;
            inventoryManager.itemNum = 1;
            inventoryManager.RemoveItem(potion);
            potion.GetSprite().SetInWorldSpace(false);

            potion.SetActive(false);
            GetScreen().RemoveObject(potion);

            AudioManager.Instance.PlaySFX("UsePotion");
        }
        public void UseItem3()
        {
            InventoryItem potion = (InventoryItem)currentItem3;
            _lives += potion.HealPoints;
            _lives -= potion.DamagePoints;
            currentItem3 = null;
            inventoryManager.itemNum--;
            inventoryManager.RemoveItem(potion);
            potion.GetSprite().SetInWorldSpace(false);

            potion.SetActive(false);
            GetScreen().RemoveObject(potion);

            AudioManager.Instance.PlaySFX("UsePotion");
        }
        public void UseItem4()
        {
            InventoryItem potion = (InventoryItem)currentItem4;
            _lives += potion.HealPoints;
            _lives -= potion.DamagePoints;
            currentItem4 = null;
            inventoryManager.RemoveItem(potion);
            potion.GetSprite().SetInWorldSpace(false);

            potion.SetActive(false);
            GetScreen().RemoveObject(potion);

            AudioManager.Instance.PlaySFX("UsePotion");
        }

        /// <summary>
        /// 
        /// Method is to attack the enemies in the game.
        /// Checks if the player is pressing e and sets it's sprite and animation
        /// sets the scale, bounds, order in layer and changes the animation
        /// 
        /// Also checks if the player presses e while close to and enemy and removes the enemy if hit
        /// 
        /// </summary>

        private void EnemyAttack()
        {
            if (GameInput.IsKeyPressed("e"))
            {
                SetSprite("Priest", 32, 32, 0.1f, new int[] { 10, 10, 10, 10, 10 }, LoopType.None);
                GetSprite().SetScale(2, 2);
                SetBounds(100, 100);
                GetSprite().SetLayerDepth(4);
                GetAnimatedSprite().StartAnimation(3, 0.01f, LoopType.None);
                AudioManager.Instance.PlaySFX("EveMelee");
            }
            if (GameInput.IsKeyPressed("e") && _flipped == true)
            {
                SetSprite("Priest", 32, 32, 0.1f, new int[] { 10, 10, 10, 10, 10 }, LoopType.None);
                GetSprite().SetScale(2, 2);
                SetBounds(100, 100);
                GetSprite().SetLayerDepth(4);
                GetAnimatedSprite().StartAnimation(3, 0.01f, LoopType.None);
                GetSprite().FlipHorizontally(true);
                AudioManager.Instance.PlaySFX("EveMelee");
            }

            Enemy enemy = (Enemy)GetOneIntersectingObject<Enemy>();
            if (enemy != null)
            {
                if (GameInput.IsKeyPressed("e"))
                {
                    AudioManager.Instance.PlaySFX("EnemyHit");
                    Camera.Instance.Shake(5, 0.1f);
                    GetScreen().RemoveObject(enemy);
                }
            }
        }

        private void DoorCheck()
        {
            Door door = (Door)GetOneIntersectingObject<Door>();
            if (door != null)
            {
                //if player is touching door then variable set to true and is able to go through the door
                _doorCollision = true;
            }
        }

        private void KeyCheck()
        {
            GameObject key = GetOneIntersectingObject<Key>();
            if (key != null)
            {
                //if player touches key - keys = 1, key gets moved and can be used
                AudioManager.Instance.PlaySFX("KeyPickUp");
                key.GetSprite().SetInWorldSpace(false);
                key.GetSprite().SetScale(1.7f, 1.7f);
                key.SetPosition(new Vector2(1557.5f + 232, 183));
                _keys++;
            }
        }

        private void CheckForObstacles()
        {
            //if player is touching wall 
            //position is reverted 
            if (IsTouching<Wall>())
            {
                RevertPosition();
            }
        }

        /// <summary>
        /// 
        /// Method check is the player has been hit by an enemy. 
        /// If his then the player gets moved to spawn and the player looses a life
        /// Once lives reach 0, the screen gets changed to the death screen
        /// 
        /// </summary>

        private void PlayerCollision()
        {
            Enemy enemy = (Enemy)GetOneObjectAtOffset<Enemy>(-25, -25);

            if (enemy != null)
            {
                AudioManager.Instance.PlaySFX("PlayerHit");
                Camera.Instance.Shake(10, 0.1f);
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

        /// <summary>
        /// 
        /// This method handles input and the inputs animation 
        /// 
        /// First it checks for the number keys 1,2,3,4
        /// Checks if pressed and there is an item associated in the inventory
        /// Player then uses the item if there is an item to be used
        /// 
        /// Later on it checks for the players inputs for movment. 
        /// Once the player inputs any WASD key, the player is able to move in the game world
        /// Animation is also associated with a WASD key press
        /// Order in layer is set and checks for obstacles while player is moving
        /// 
        /// </summary>

        private void HandleInputs()
        {
            if (GameInput.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.D1))
            {
                // if statment prevents program break if there are no items
                if (currentItem1 is InventoryItem || currentItem1 != null)
                {
                    UseItem1();
                    //currentItem1 = inventoryManager.InventoryItems[0];
                }
            }
            if (GameInput.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.D2))
            {
                // if statment prevents program break if there are no items
                if (currentItem2 is InventoryItem || currentItem2 != null)
                {
                    UseItem2();
                }
            }
            if (GameInput.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.D3))
            {
                // if statment prevents program break if there are no items
                if (currentItem3 is InventoryItem || currentItem3 != null)
                {
                    UseItem3();
                }
            }
            if (GameInput.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.D4))
            {
                // if statment prevents program break if there are no items
                if (currentItem4 is InventoryItem || currentItem4 != null)
                {
                    UseItem4();
                }
            }


            if (GameInput.IsKeyPressed("W"))
            {
                CheckForObstacles();
                SetBounds(100, 100);
                GetSprite().SetLayerDepth(4);
            }
            else if (GameInput.IsKeyHeld("W"))
            {
                SetPosition(GetX(), GetY() - _speed);
                CheckForObstacles();
                SetBounds(100, 100);
                GetSprite().SetLayerDepth(4);
            }
            else if (GameInput.IsKeyReleased("W"))
            {
                CheckForObstacles();
                SetBounds(100, 100);
                GetSprite().SetLayerDepth(4);
            }


            if (GameInput.IsKeyPressed("S"))
            {
                CheckForObstacles();
                SetBounds(100, 100);
                GetSprite().SetLayerDepth(4);
            }
            else if (GameInput.IsKeyHeld("S"))
            {
                SetPosition(GetX(), GetY() + _speed);
                CheckForObstacles();
                SetBounds(100, 100);
                GetSprite().SetLayerDepth(4);
            }
            else if (GameInput.IsKeyReleased("S"))
            {
                CheckForObstacles();
                SetBounds(100, 100);
                GetSprite().SetLayerDepth(4);
            }


            if (GameInput.IsKeyPressed("A"))
            {
                SetSprite("Priest", 32, 32, 0.05f, new int[] { 10, 10, 10, 10, 10 }, LoopType.None);
                GetSprite().SetScale(2, 2);
                GetSprite().SetLayerDepth(4);
                GetAnimatedSprite().StartAnimation(2, 0.05f, LoopType.Bounce);

                _flipped = true;
                CheckForObstacles();
                SetBounds(100, 100);
            }
            else if (GameInput.IsKeyHeld("A"))
            {
                SetPosition(GetX() - _speed, GetY());
                GetSprite().SetLayerDepth(4);

                GetSprite().FlipHorizontally(true);
                _flipped = true;
                CheckForObstacles();
                SetBounds(100, 100);
            }
            else if (GameInput.IsKeyReleased("A"))
            {
                SetSprite("Priest", 32, 32, 0.1f, new int[] { 10, 10, 10, 10, 10 }, LoopType.None);
                //GetAnimatedSprite().StartAnimation(0, 0.1f, LoopType.Bounce);
                GetSprite().SetLayerDepth(4);
                GetSprite().SetScale(2, 2);

                GetSprite().FlipHorizontally(true);
                _flipped = true;
                CheckForObstacles();
                SetBounds(100, 100);
            }

            if (GameInput.IsKeyPressed("D"))
            {
                SetSprite("Priest", 32, 32, 0.05f, new int[] { 10, 10, 10, 10, 10 }, LoopType.None);
                GetSprite().SetScale(2, 2);
                GetSprite().SetLayerDepth(4);
                GetAnimatedSprite().StartAnimation(2, 0.05f, LoopType.Bounce);

                _flipped = false;
                CheckForObstacles();
                SetBounds(100, 100);
            }
            else if (GameInput.IsKeyHeld("D"))
            {
                SetPosition(GetX() + _speed, GetY());
                GetSprite().SetLayerDepth(4);

                GetSprite().FlipHorizontally(false);
                _flipped = false;
                CheckForObstacles();
                SetBounds(100, 100);
            }
            else if (GameInput.IsKeyReleased("D"))
            {
                SetSprite("Priest", 32, 32, 0.1f, new int[] { 10, 10, 10, 10, 10 }, LoopType.None);
                //GetAnimatedSprite().StartAnimation(0, 0.1f, LoopType.Bounce);
                GetSprite().SetLayerDepth(4);
                GetSprite().SetScale(2, 2);

                GetSprite().FlipHorizontally(false);
                _flipped = false;
                CheckForObstacles();
                SetBounds(100, 100);
            }
        }

        //returns variables to be used in other classes 

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
