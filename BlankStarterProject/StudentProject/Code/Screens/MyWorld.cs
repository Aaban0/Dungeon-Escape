using StudentProject.Code.GameObjects.map;
using System;

namespace StudentProject.Code.Screens
{
    public class MyWorld : Screen
    {
        //variables for the screen

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

        private Text _item1;
        private Text _item2;
        private Text _item3;
        private Text _item4;
        private Text _enter;

        private Vector2 _position;

        public override void Start(Core core)
        {
            base.Start(core);
            // TODO: Add your Screen start code below here

            //adds all the game objects into the scene

            inventoryManager = new InventoryManager();
            AddObject(inventoryManager, 1550, 50);

            _item1 = new Text("[1]", Colour.White);
            AddText(_item1, 1570, 130);
            _item1.SetScale(0.45f);
            //_item1.SetOrigin(-10, -10);

            _item2 = new Text("[2]", Colour.White);
            AddText(_item2, 1647, 130);
            _item2.SetScale(0.45f);

            _item3 = new Text("[3]", Colour.White);
            AddText(_item3, 1724, 130);
            _item3.SetScale(0.45f);

            _item4 = new Text("[4]", Colour.White);
            AddText(_item4, 1801, 130);
            _item4.SetScale(0.45f);

            _enter = new Text("[ENTER]", Colour.White);
            AddText(_enter, 1758, 250);
            _enter.SetScale(0.5f);

            _keyManager = new KeyManager();
            AddObject(_keyManager, 1779, 170);

            _door = new Door();
            AddObject(_door, 900, 900);

            //uses overloaded constructor for the wolf
            _wolf = new Wolf(1, false);
            AddObject(_wolf, 150, 400);
            AddObject(new Wolf(), 1680, 700);

            //uses overloaded constructor for the mummy
            _mummy = new Mummy(1, false);
            AddObject(_mummy, 1100, 900);
            AddObject(new Mummy(1, false), 550, 105);

            //uses overloaded constructor for the bat
            _bat = new Bat(1, 5);
            AddObject(_bat, 1050, 400);
            AddObject(new Bat(1, 5), 1330, 330);
            AddObject(new Bat(1, 5), 930, 600);

            _player = new Player();
            AddObject(_player, 70, 880);

            //uses overloaded constructor for health potion
            _potion2 = new Potion("Health Potion", 1, 0);
            AddObject(_potion2, 60, 500);

            //uses overloaded constructor for health potion
            _potion = new Potion("Health Potion", 1, 0);
            AddObject(_potion, 1690, 700);

            //uses overloaded constructor for mega potion
            _mPotion = new MegaPotion("Mega Potion", 2, 0);
            AddObject(_mPotion, 895, 670);

            //uses overloaded constructor for poison potion
            _pPotion = new PoisonPotion("Poison Potion", 0, 1);
            AddObject(_pPotion, 750, 115);

            _key = new Key();
            AddObject(_key, 1700, 120);

            _health = new Health();
            AddObject(_health, 40, 50);


            BuildWalls();

            Transition.Instance.EndTransition();
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
            // TODO: Add your Screen update code below here

            //calls the camera method
            SceneCamera();

            //respawns player after death
            if (_player.Death() == true)
            {
                _player.SetPosition(70, 880);
            }

            //players health updates 
            _health.SetHealth(_player.Lives());

            //calls door check method 
            DoorCheck();
        }

        private void SceneCamera()
        {
            //position is set to the players X and Y coordinates
            _position = new Vector2(_player.GetX(), _player.GetY());

            //camera looks at the players position
            Camera.Instance.LookAt(_position);
            Camera.Instance.Zoom = 2.3f;
        }

        //This method builds the walls, floor and all scene elements 
        //The reason for its size is becasue each object was added manually 

        private void BuildWalls()
        {
            var floor = new Floor1();
            AddObject(floor, -1, 189);
            floor.GetSprite().SetScale(8.15f, 8.15f);
            floor.SetBounds(1000, 1000);

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

            AddObject(new Floor(), 1635, 505);
            AddObject(new Floor(), 1635, 400);
            AddObject(new Floor(), 1635, 297);
            
            AddObject(new Floor1(), 1585, 80);

            AddObject(new Floor(), 1335, 598);
            AddObject(new Floor(), 1485, 598);
            AddObject(new Floor(), 1635, 610);
            AddObject(new Floor(), 1635, 715);
            AddObject(new Floor(), 1635, 820);
            AddObject(new Floor(), 1635, 925);
            AddObject(new Floor(), 1485, 925);
            AddObject(new Floor(), 1485, 820);
            AddObject(new Floor(), 1335, 925);
            AddObject(new Floor(), 1335, 820);
            AddObject(new Floor(), 1185, 925);
            AddObject(new Floor(), 1185, 820);
            AddObject(new Floor(), 1035, 925);
            AddObject(new Floor(), 1035, 820);
            AddObject(new Floor(), 885, 925);
            AddObject(new Floor(), 885, 820);

            /*AddObject(new Wall(), 1167, 742);
            AddObject(new Wall(), 1167, 790);
            AddObject(new Wall(), 1191, 742);
            AddObject(new Wall(), 1191, 790);
            AddObject(new Wall(), 1215, 742);
            AddObject(new Wall(), 1215, 790);*/

            AddObject(new Wall_Tint1(), 1239, 190);
            AddObject(new Wall_Tint1(), 1239, 220);

            AddObject(new Wall_Tint1(), 1078, 190);
            AddObject(new Wall_Tint1(), 1078, 220);

            AddObject(new Wall(), 1030, 190);
            AddObject(new Wall(), 1030, 238);

            AddObject(new Wall(), 982, 190);
            AddObject(new Wall(), 982, 238);

            AddObject(new Wall(), 934, 190);
            AddObject(new Wall(), 934, 238);

            AddObject(new Wall(), 886, 190);
            AddObject(new Wall(), 886, 238);

            AddObject(new Wall(), 838, 190);
            AddObject(new Wall(), 838, 238);

            /*AddObject(new Wall(), 1239, 742);
            AddObject(new Wall(), 1239, 790);*/
            AddObject(new Wall(), 1263, 190);
            AddObject(new Wall(), 1263, 220);

            /*AddObject(new Wall(), 711, 790);
            AddObject(new Wall(), 711, 742);
            AddObject(new Wall(), 759, 790);
            AddObject(new Wall(), 759, 742);*/
            /*AddObject(new Wall(), 807, 790);
            AddObject(new Wall(), 807, 742);*/


            AddObject(new Wall(), 885, 790);
            AddObject(new Wall(), 885, 742);
            AddObject(new Wall(), 903, 790);
            AddObject(new Wall(), 903, 742);
            AddObject(new Wall(), 951, 790);
            AddObject(new Wall(), 951, 742);
            AddObject(new Wall(), 999, 790);
            AddObject(new Wall(), 999, 742);
            AddObject(new Wall(), 1047, 790);
            AddObject(new Wall(), 1047, 742);
            AddObject(new Wall(), 1095, 790);
            AddObject(new Wall(), 1095, 742);
            AddObject(new Wall(), 1143, 790);
            AddObject(new Wall(), 1143, 742);
            AddObject(new Wall(), 1191, 790);
            AddObject(new Wall(), 1191, 742);
            AddObject(new Wall(), 1239, 790);
            AddObject(new Wall(), 1239, 742);

            AddObject(new Wall(), 1287, 742);
            AddObject(new Wall(), 1287, 790);
            AddObject(new Wall(), 1287, 190);
            AddObject(new Wall(), 1287, 220);
            AddObject(new Wall(), 1335, 190);
            AddObject(new Wall(), 1335, 220);
            AddObject(new Wall(), 1335, 502);
            AddObject(new Wall(), 1335, 550);
            AddObject(new Wall(), 1335, 742);
            AddObject(new Wall(), 1335, 790);
            AddObject(new Wall(), 1383, 742);
            AddObject(new Wall(), 1383, 790);
            AddObject(new Wall(), 1383, 190);
            AddObject(new Wall(), 1383, 220);
            AddObject(new Wall(), 1383, 502);
            AddObject(new Wall(), 1383, 550);
            AddObject(new Wall(), 1431, 742);
            AddObject(new Wall(), 1431, 790);
            AddObject(new Wall(), 1431, 502);
            AddObject(new Wall(), 1431, 550);
            AddObject(new Wall(), 1431, 190);
            AddObject(new Wall(), 1431, 220);
            AddObject(new Wall(), 1479, 742);
            AddObject(new Wall(), 1479, 790);
            AddObject(new Wall(), 1479, 502);
            AddObject(new Wall(), 1479, 550);
            AddObject(new Wall(), 1479, 454);
            AddObject(new Wall(), 1479, 406);
            AddObject(new Wall(), 1479, 358);
            AddObject(new Wall(), 1479, 310);
            AddObject(new Wall(), 1479, 262);
            AddObject(new Wall(), 1479, 220);
            AddObject(new Wall(), 1479, 190);
            AddObject(new Wall_Tint1(), 1527, 502);
            AddObject(new Wall_Tint1(), 1527, 454);
            AddObject(new Wall_Tint2(), 1527, 406);
            AddObject(new Wall_Tint2(), 1527, 358);
            AddObject(new Wall_Tint1(), 1527, 310);
            AddObject(new Wall(), 1527, 262);
            AddObject(new Wall(), 1527, 220);
            AddObject(new Wall(), 1527, 190);
            AddObject(new Wall(), 1527, 550);
            AddObject(new Wall(), 1527, 742);
            AddObject(new Wall(), 1527, 790);
            AddObject(new Wall(), 1575, 406);
            AddObject(new Wall(), 1575, 358);
            AddObject(new Wall(), 1575, 310);
            AddObject(new Wall_Tint1(), 1575, 262);
            AddObject(new Wall_Tint1(), 1575, 214);
            AddObject(new Wall_Tint1(), 1575, 166);
            AddObject(new Wall(), 1575, 454);
            AddObject(new Wall(), 1575, 502);
            AddObject(new Wall(), 1575, 550);
            AddObject(new Wall(), 1575, 742);
            AddObject(new Wall(), 1575, 790);
            AddObject(new Wall_Tint1(), 1623, 454);
            AddObject(new Wall_Tint1(), 1623, 406);
            AddObject(new Wall_Tint1(), 1623, 358);
            AddObject(new Wall_Tint1(), 1623, 310);
            AddObject(new Wall_Tint1(), 1623, 502);
            AddObject(new Wall_Tint1(), 1623, 550);

            AddObject(new Wall_Tint1(), 1623, 694);
            AddObject(new Wall(), 1575, 694);
            AddObject(new Wall(), 1527, 694);
            AddObject(new Wall(), 1479, 694);
            AddObject(new Wall(), 1431, 694);
            AddObject(new Wall(), 1383, 694);
            AddObject(new Wall(), 1335, 694);

            AddObject(new Wall_Tint1(), 1623, 742);
            AddObject(new Wall_Tint1(), 1623, 790);

            AddObject(new Wall(), 1479, 454);



            /*AddObject(new Wall(), -3, -5);
            AddObject(new Wall(), -3, 40);*/
            AddObject(new Wall(), -3, 85);
            AddObject(new Wall(), -3, 130);
            AddObject(new Wall(), -3, 175);

            AddObject(new Wall_Tint1(), -50, -5);
            AddObject(new Wall_Tint2(), -50, -50);
            AddObject(new Wall_Tint2(), -95, -50);
            AddObject(new Wall_Tint3(), -50, -95);
            AddObject(new Wall_Tint3(), -95, -95);

            AddObject(new Wall(), -50, 1030);
            AddObject(new Wall_Tint1(), -50, 1075);
            AddObject(new Wall_Tint1(), -95, 1075);

            AddObject(new Wall_Tint2(), -50, 1118);
            AddObject(new Wall_Tint2(), -95, 1118);
            AddObject(new Wall_Tint2(), -140, 1118);
            AddObject(new Wall_Tint2(), -140, 1075);

            AddObject(new Wall_Tint3(), -50, 1163);
            AddObject(new Wall_Tint3(), -95, 1163);

            AddObject(new Wall_Tint1(), 1900, -5);
            AddObject(new Wall_Tint1(), 1945, -5);
            AddObject(new Wall_Tint2(), 1900, -50);
            AddObject(new Wall_Tint2(), 1945, -50);

            AddObject(new Wall_Tint3(), 1900, -95);
            AddObject(new Wall_Tint3(), 1945, -95);
            AddObject(new Wall_Tint3(), 1990, -95);

            AddObject(new Wall_Tint1(), 1900, 1075);
            AddObject(new Wall_Tint1(), 1945, 1075);

            AddObject(new Wall_Tint2(), 1900, 1118);
            AddObject(new Wall_Tint2(), 1945, 1118);
            AddObject(new Wall_Tint2(), 1990, 1118);
            AddObject(new Wall_Tint2(), 1990, 1075);
            AddObject(new Wall_Tint3(), 1900, 1163);

            //these for loops are used throughout the scene
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
                // The Wall's sprite is 47px wide, so move each new Wall by 47 before placing it in the world
                int xPosition = column * (47 + gapBetweenWalls);

                // Place a Wall object coming in from the left and includes the tinted walls at the back 
                AddObject(new Wall(), xPosition, yPosition + 70);
                AddObject(new Wall_Tint1(), xPosition, yPosition + 114);
                AddObject(new Wall_Tint2(), xPosition, yPosition + 158);
                AddObject(new Wall_Tint3(), xPosition, yPosition + 202);

                // Place a Wall object coming in from the right and includes the tinted walls at the back 
                AddObject(new Wall(), screenRightEdge - xPosition, yPosition + 70);
                AddObject(new Wall_Tint1(), screenRightEdge - xPosition, yPosition + 114);
                AddObject(new Wall_Tint2(), screenRightEdge - xPosition, yPosition + 158);
                AddObject(new Wall_Tint3(), screenRightEdge - xPosition, yPosition + 202);


                AddObject(new Wall_Tint3(), xPosition - 1, yPosition - 1055);

                AddObject(new Wall_Tint2(), xPosition - 1, yPosition - 1010);
                AddObject(new Wall_Tint1(), xPosition - 1, yPosition - 965);

                AddObject(new Wall(), xPosition - 1, yPosition - 920);
                AddObject(new Wall(), screenRightEdge - 1 - xPosition, yPosition - 920);

                AddObject(new Wall_Tint3(), screenRightEdge - 1 - xPosition, yPosition - 1055);
                AddObject(new Wall_Tint2(), screenRightEdge - 1 - xPosition, yPosition - 1010);
                AddObject(new Wall_Tint1(), screenRightEdge - 1 - xPosition, yPosition - 965);
            }
            for (int column = 0;column < numberOfWalls + 4; column++)
            {

                int yposition = column * (46 - gapBetweenWalls);

                AddObject(new Wall(), -50, yposition - 50);
                AddObject(new Wall_Tint1(), -95, yposition - 50);
                AddObject(new Wall_Tint2(), -140, yposition - 50);
                AddObject(new Wall_Tint3(), -185, yposition - 50);


                AddObject(new Wall(), 1900, yposition - 50);
                AddObject(new Wall_Tint1(), 1945, yposition - 50);
                AddObject(new Wall_Tint2(), 1990, yposition - 50);
                AddObject(new Wall_Tint3(), 2035, yposition - 50);

                AddObject(new Wall(), 1852, yposition - 50);
                AddObject(new Wall(), 1804, yposition - 50);
                AddObject(new Wall_Tint1(), 1759, yposition - 50);

            }
            for (int column = 0; column < numberOfWalls - 2; column++)
            {
                int yposition2 = column * (46 - gapBetweenWalls);
                AddObject(new Wall(), 692, yposition2 + 185);
                AddObject(new Wall(), 740, yposition2 + 185);
                AddObject(new Wall(), 788, yposition2 + 185);
                AddObject(new Wall(), 836, yposition2 + 185);

                
            }
            for (int column = 0; column < numberOfWalls - 17; column++)
            {
                int yposition3 = column * (46 - gapBetweenWalls);

                AddObject(new Wall(), 644, yposition3 + 185);
                AddObject(new Wall_Tint1(), 644, yposition3 + 190);

                AddObject(new Wall(), 596, yposition3 + 185);
                AddObject(new Wall_Tint1(), 596, yposition3 + 190);

                AddObject(new Wall(), 548, yposition3 + 185);
                AddObject(new Wall_Tint1(), 548, yposition3 + 190);

                AddObject(new Wall(), 500, yposition3 + 185);
                AddObject(new Wall_Tint1(), 500, yposition3 + 190);

                AddObject(new Wall(), 452, yposition3 + 185);
                AddObject(new Wall_Tint1(), 452, yposition3 + 190);

                AddObject(new Wall(), 404, yposition3 + 185);
                AddObject(new Wall_Tint1(), 404, yposition3 + 190);

                AddObject(new Wall_Tint1(), 356, yposition3 + 190);
            }

            for (int column = 0; column < numberOfWalls - 10; column++)
            {
                int xPosition2 = column * (47 + gapBetweenWalls);
                AddObject(new Wall(), xPosition2 - 1, yPosition - 380);
                AddObject(new Wall(), xPosition2 - 1, yPosition - 332);
                AddObject(new Wall(), xPosition2 - 1, yPosition - 284);
                AddObject(new Wall(), xPosition2 - 1, yPosition - 236);
                AddObject(new Wall(), xPosition2 - 1, yPosition - 215);
            }

            for (int column = 0; column < numberOfWalls - 11; column++)
            {
                int xPosition3 = column * (47 + gapBetweenWalls);
                AddObject(new Wall(), xPosition3 + 250, yPosition + 24);
                AddObject(new Wall(), xPosition3 + 250, yPosition - 24);
                AddObject(new Wall(), xPosition3 + 250, yPosition - 72);
            }

            AddObject(new Wall_Tint1(), 527, 580);
            AddObject(new Wall_Tint1(), 527, 628);
            AddObject(new Wall_Tint1(), 527, 676);
            AddObject(new Wall_Tint1(), 527, 724);
            AddObject(new Wall_Tint1(), 527, 772);

            AddObject(new Wall_Tint1(), 205, 984);
            AddObject(new Wall_Tint1(), 205, 936);
            AddObject(new Wall_Tint1(), 205, 888);
        }

        //method checks if the player is colliding with the door, if they pressed enter while having the key
        //the door changes to being opened
        //screen transitioned to the win screen 
        private void DoorCheck()
        {
            if (_player.DoorCollision() == true && GameInput.IsKeyPressed("enter") && _player.GetKeys() == 1)
            {
                AudioManager.Instance.PlaySFX("DoorEnter");
                _door.SetSprite("door unlocked");
                _door.GetSprite().SetScale(5, 5);
                Transition.Instance.ToScreen<EndScreen>();
            }
        }
    }
}

