using StudentProject.Code.GameObjects.map;
using System;

namespace StudentProject.Code.Screens
{
    public class MyWorld : Screen
    {
        private Player _player;

        private Wolf _wolf;
        private Mummy _mummy;
        private Bat _bat;

        private Potion _potion;
        private Potion _potion2;
        private MegaPotion _mPotion;
        private PoisonPotion _pPotion;

        private Door _door;
        private Key _key;

        private Health _health;
        private InventoryManager inventoryManager;
        private KeyManager _keyManager;

        private Vector2 _position;

        public override void Start(Core core)
        {
            base.Start(core);
            // TODO: Add your Screen start code below here
            //SetBackground("tempBackground", BackgroundType.FullScroll);


            inventoryManager = new InventoryManager();
            AddObject(inventoryManager, 1550, 50);

            _keyManager = new KeyManager();
            AddObject(_keyManager, 1779, 160);

            _door = new Door();
            AddObject(_door, 900, 900);

            _wolf = new Wolf();
            AddObject(_wolf, 200, 800);

            _mummy = new Mummy();
            AddObject(_mummy, 600, 900);

            _bat = new Bat();
            AddObject(_bat, 1000, 300);

            _player = new Player();
            AddObject(_player, 70, 880);

            _potion2 = new Potion("Health Potion", 1, 0);
            AddObject(_potion2, 60, 500);

            _potion = new Potion("Health Potion", 1, 0);
            AddObject(_potion, 1690, 700);

            _mPotion = new MegaPotion("Health Potion", 2, 0);
            AddObject(_mPotion, 895, 670);

            _pPotion = new PoisonPotion("Poison Potion", 0, 1);
            AddObject(_pPotion, 750, 115);

            _key = new Key();
            //AddObject(_key, 800, 950);
            AddObject(_key, 1700, 120);

            _health = new Health();
            AddObject(_health, 40, 50);


            BuildWalls();
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
            // TODO: Add your Screen update code below here

            SceneCamera();

            if (_player.Death() == true)
            {
                _player.SetPosition(70, 880);
            }

            _health.SetHealth(_player.Lives());

            DoorCheck();
        }

        private void SceneCamera()
        {
            _position = new Vector2(_player.GetX(), _player.GetY());

            Camera.Instance.LookAt(_position);
            Camera.Instance.Zoom = 2f;
        }

        private void BuildWalls()
        {
            var floor = new Floor1();
            AddObject(floor, -1, 189);
            floor.GetSprite().SetScale(8.15f, 8.15f);

            AddObject(new Floor1(), 0, 790);
            AddObject(new Floor1(), 855, 265);
            AddObject(new Floor1(), 855, 505);
            AddObject(new Floor1(), 1095, 505);
            AddObject(new Floor1(), 1245, 265);

            AddObject(new Floor(), 240, 790);
            AddObject(new Floor(), 390, 790);
            AddObject(new Floor(), 540, 790);
            AddObject(new Floor(), 540, 685);
            AddObject(new Floor(), 540, 580);
            AddObject(new Floor(), 540, 475);
            AddObject(new Floor(), 540, 370);
            AddObject(new Floor(), 390, 475);
            AddObject(new Floor(), 390, 370);

            AddObject(new Floor(), 45, 85);
            AddObject(new Floor(), 195, 85);
            AddObject(new Floor(), 345, 85);
            AddObject(new Floor(), 495, 85);
            AddObject(new Floor(), 645, 85);
            AddObject(new Floor(), 795, 85);
            AddObject(new Floor(), 945, 85);
            AddObject(new Floor(), 1095, 85);
            AddObject(new Floor(), 1245, 85);
            AddObject(new Floor(), 1395, 85);
            AddObject(new Floor(), 1545, 85);

            AddObject(new Floor(), 1095, 190);
            AddObject(new Floor(), 1095, 295);
            AddObject(new Floor(), 1095, 400);

            AddObject(new Floor(), 1635, 493);
            AddObject(new Floor(), 1635, 388);
            AddObject(new Floor(), 1635, 283);
            
            AddObject(new Floor1(), 1585, 43);

            AddObject(new Floor(), 1335, 598);
            AddObject(new Floor(), 1485, 598);
            AddObject(new Floor(), 1635, 598);
            AddObject(new Floor(), 1635, 703);
            AddObject(new Floor(), 1635, 808);
            AddObject(new Floor(), 1635, 913);
            AddObject(new Floor(), 1485, 913);
            AddObject(new Floor(), 1485, 808);
            AddObject(new Floor(), 1335, 913);
            AddObject(new Floor(), 1335, 808);
            AddObject(new Floor(), 1185, 913);
            AddObject(new Floor(), 1185, 808);
            AddObject(new Floor(), 1035, 913);
            AddObject(new Floor(), 1035, 808);
            AddObject(new Floor(), 885, 913);
            AddObject(new Floor(), 885, 808);

            AddObject(new Wall(), 1335, 502);
            AddObject(new Wall(), 1335, 550);
            AddObject(new Wall(), 1383, 502);
            AddObject(new Wall(), 1383, 550);
            AddObject(new Wall(), 1431, 502);
            AddObject(new Wall(), 1431, 550);
            AddObject(new Wall(), 1479, 502);
            AddObject(new Wall(), 1479, 550);
            AddObject(new Wall(), 1479, 454);

            AddObject(new Wall_Left(), -3, -4);
            AddObject(new Wall_Left(), -3, 44);
            AddObject(new Wall_Left(), -3, 91);
            AddObject(new Wall_Left(), -3, 138);


            // Place each wall halfway down the screen
            int yPosition = (int)Settings.ScreenDimensions.X / 2;

            // This is the size of the game, minus 1 Wall width (32px)
            int screenRightEdge = (int)Settings.ScreenDimensions.X - 32;

            // The number of walls to place / how many iterations of our loop to run
            int numberOfWalls = 21;

            // The number of pixels between each consecutive Wall.
            int gapBetweenWalls = 1;

            for (int column = 0; column < numberOfWalls; column++)
            {
                // The Wall's sprite is 64px wide, so move each new Wall by 64 before placing it in the world
                int xPosition = column * (47 + gapBetweenWalls);

                // Place a Wall object coming in from the left
                AddObject(new Wall(), xPosition, yPosition + 70);
                /*AddObject(new Wall(), xPosition, yPosition + 120);
                AddObject(new Wall(), xPosition, yPosition + 170);
                AddObject(new Wall(), xPosition, yPosition + 220);*/

                // Place a Wall object coming in from the right
                AddObject(new Wall(), screenRightEdge - xPosition, yPosition + 70);


                //places walls on the top of the screen
                AddObject(new Wall(), xPosition, yPosition - 1015);

                AddObject(new Wall(), screenRightEdge - xPosition, yPosition - 1015);
            }
            for (int column = 0;column < numberOfWalls + 4; column++)
            {

                int yposition = column * (46 - gapBetweenWalls);

                AddObject(new Wall_Left(), -50, yposition - 50);
                AddObject(new Wall_Right(), 1900, yposition - 50);
            }


        }

        private void DoorCheck()
        {
            if (_player.DoorCollision() == true && GameInput.IsKeyPressed("enter") && _player.GetKeys() == 1)
            {
                _door.SetSprite("door unlocked");
                _door.GetSprite().SetScale(5, 5);
                Transition.Instance.ToScreen<EndScreen>();
            }
        }
    }
}

