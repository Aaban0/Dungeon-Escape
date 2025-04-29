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
            AddObject(_player, 850, 400);

            _potion2 = new Potion("Health Potion", 1, 0);
            AddObject(_potion2, 450, 450);

            _potion = new Potion("Health Potion", 1, 0);
            AddObject(_potion, 500, 500);

            _mPotion = new MegaPotion("Health Potion", 2, 0);
            AddObject(_mPotion, 550, 550);

            _pPotion = new PoisonPotion("Poison Potion", 0, 1);
            AddObject(_pPotion, 600, 600);

            _key = new Key();
            AddObject(_key, 950, 950);

            _health = new Health();
            AddObject(_health, 40, 50);


            BuildWalls();
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
            // TODO: Add your Screen update code below here

            //SceneCamera();

            if (_player.Death() == true)
            {
                _player.SetPosition(100, 850);
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
            // Place each wall halfway down the screen
            int yPosition = (int)Settings.ScreenDimensions.X / 2;

            // This is the size of the game, minus 1 Wall width (64px)
            int screenRightEdge = (int)Settings.ScreenDimensions.X - 64;

            // The number of walls to place / how many iterations of our loop to run
            int numberOfWalls = 15;

            // The number of pixels between each consecutive Wall.
            int gapBetweenWalls = 1;

            for (int column = 0; column < numberOfWalls; column++)
            {
                // The Wall's sprite is 64px wide, so move each new Wall by 64 before placing it in the world
                int xPosition = column * (64 + gapBetweenWalls);

                // Place a Wall object coming in from the left
                AddObject(new Wall(), xPosition, yPosition + 70);

                // Place a Wall object coming in from the right
                AddObject(new Wall(), screenRightEdge - xPosition, yPosition + 70);


                //places walls on the top of the screen
                AddObject(new Wall(), xPosition, yPosition - 1015);

                AddObject(new Wall(), screenRightEdge - xPosition, yPosition - 1015);
            }
            for (int column = 0;column < numberOfWalls + 3; column++)
            {

                int yposition = column * (64 - gapBetweenWalls);

                AddObject(new Wall(), -50, yposition);
                AddObject(new Wall(), 1900, yposition);
            }


        }

        private void DoorCheck()
        {
            if (_player.DoorCollision() == true && GameInput.IsKeyPressed("enter") && _player.GetKeys() == 1)
            {
                Transition.Instance.ToScreen<EndScreen>();
            }
        }
    }
}

