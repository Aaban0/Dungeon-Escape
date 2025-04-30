using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Code.Screens
{
    internal class EndScreen : Screen
    {
        private Text _text;
        private float _transparent = 0;

        private Text _enter;
        private float _transparent3 = 0;

        private Text _exit;
        private float _transparent4 = 0;

        private float _time = 0;

        private bool _onScreen;
        private bool _onScreen2;

        public override void Start(Core core)
        {
            base.Start(core);

            //Background colour is changed
            Settings.BackgroundFill = Colour.Gray;

            AudioManager.Instance.StopBGM();
            AudioManager.Instance.PlayBGM("WinMusic");

            //sets a text on screen with the colour white and sets scale increase by 2
            //also has changed the font type
            _text = new Text("You Escaped", Colour.White);
            AddText(_text, 620, 150);
            //_text.SetFont("BKANT.TTF");
            _text.SetScale(2);

            //sets a text on screen with the colour white
            //also has changed the font type
            _enter = new Text("Press Enter to Return to Main Menu", Colour.White);
            AddText(_enter, 470, 800);
            //_enter.SetFont("BKANT.TTF");

            //sets a text on screen with the colour white
            //also has changed the font type
            _exit = new Text("  Press Esc To Exit", Colour.White);
            AddText(_exit, 680, 870);
            //_exit.SetFont("BKANT.TTF");

            Transition.Instance.EndTransition();
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            InputCheck();


            //the text is initially set to transparent
            //timer is used and if it is not equal to 255 then
            //transparency goes up untill reaches 255

            _text.SetColour(255, 255, 0, (int)_transparent);
            if (_transparent != 255)
            {
                _transparent += deltaTime * 190;
                if (_transparent >= 255)
                {
                    _onScreen = true;
                }
            }

            _enter.SetColour(255, 255, 0, (int)_transparent3);
            if (_transparent3 != 255 && _onScreen == true)
            {
                _transparent3 += deltaTime * 200;
                if (_transparent3 >= 255)
                {
                    _onScreen2 = true;
                }
            }

            //if _onScreen3 = true then this next text starts the same loop
            //the text is initially set to transparent
            //timer is used and if it is not equal to 255 then
            //transparency goes up untill reaches 255

            _exit.SetColour(255, 255, 0, (int)_transparent4);
            if (_transparent4 != 255 && _onScreen2 == true)
            {
                _transparent4 += deltaTime * 200;
            }
        }

        private void InputCheck()
        {
            if (GameInput.IsKeyPressed("Enter"))
            {
                //if enter is pressed player transitioned to new screen
                //a sound clip is also played when enter is pressed
                AudioManager.Instance.PlaySFX("click");
                Transition.Instance.ToScreen<MainMenu>();
            }
            else if (GameInput.IsKeyPressed("Esc"))
            {
                //if esc is pressed player transitioned to new screen
                //a sound clip is also played when enter is pressed
                AudioManager.Instance.PlaySFX("click");
                Core.EndGame();
                Core.CloseGame();
            }
        }
    }
}
