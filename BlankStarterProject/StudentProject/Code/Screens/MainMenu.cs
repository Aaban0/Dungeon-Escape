using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Code.Screens
{
    internal class MainMenu : Screen
    {
        private Text _title;
        private Text _enter;
        private Text _exit;
        private float _transparent = 0;
        private float _transparent2 = 0;
        private float _transparent3 = 0;

        private bool _onScreen;
        private bool _onScreen2;

        public override void Start(Core core)
        {
            base.Start(core);

            //sets manu backgrund and sets audio 
            //AudioManager.Instance.StopBGM();
            //AudioManager.Instance.PlayBGM("Stage1");
            //SetBackground("MainMenu", BackgroundType.Wrap);

            //sets a text on screen with the colour white and increases the scale by 3
            //also has changed the font type
            _title = new Text("Dungeon's Grip", Colour.White);
            AddText(_title, 475, 200);
            //_title.SetFont("BELL.TTF");
            _title.SetScale(2.5f);

            //sets a text on screen with the colour white
            //also has changed the font type
            _enter = new Text("Press Enter to Begin", Colour.White);
            AddText(_enter, 680, 830);
            //_enter.SetFont("BKANT.TTF");

            //sets a text on screen with the colour white
            //also has changed the font type
            _exit = new Text("  Press Esc To Exit", Colour.White);
            AddText(_exit, 680, 900);
            //_exit.SetFont("BKANT.TTF");

            Transition.Instance.EndTransition();
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            if (GameInput.IsKeyPressed("Enter"))
            {
                //if enter is pressed player transitioned to new screen
                //a sound clip is also played when enter is pressed
                //AudioManager.Instance.PlaySFX("click");
                Transition.Instance.ToScreen<MyWorld>();
            }
            else if (GameInput.IsKeyPressed("Esc"))
            {
                //if esc is pressed player transitioned to new screen
                //a sound clip is also played when enter is pressed
                //AudioManager.Instance.PlaySFX("click");
                Core.EndGame();
                Core.CloseGame();
            }


            //the text is initially set to transparent
            //timer is used and if it is not equal to 255 then
            //transparency goes up untill reaches 255

            _title.SetColour(254, 57, 57, (int)_transparent);
            if (_transparent != 255)
            {
                _transparent += deltaTime * 150;
                if (_transparent >= 255)
                {
                    _onScreen = true;
                }
            }

            //if _onScreen = true then this next text starts the same loop
            //the text is initially set to transparent
            //timer is used and if it is not equal to 255 then
            //transparency goes up untill reaches 255

            _enter.SetColour(254, 57, 57, (int)_transparent2);
            if (_transparent2 != 255 && _onScreen == true)
            {
                _transparent2 += deltaTime * 200;
                if (_transparent2 >= 255)
                {
                    _onScreen2 = true;
                }
            }

            //if _onScreen2 = true then this next text starts the same loop
            //the text is initially set to transparent
            //timer is used and if it is not equal to 255 then
            //transparency goes up untill reaches 255

            _exit.SetColour(254, 57, 57, (int)_transparent3);
            if (_transparent3 != 255 && _onScreen2 == true)
            {
                _transparent3 += deltaTime * 200;
            }
        }
    }
}
