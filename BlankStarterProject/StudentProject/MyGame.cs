using StudentProject.Code.Screens;
using System;

namespace StudentProject
{
    public class MyGame : Core
    { 
        protected override void Initialize()
        {
            Window.Title = "Dungeon's Grip";
            // TODO: Add your game's initialization logic below here
            Settings.BackgroundFill = Colour.Black;
            StartScreen<MainMenu>();
            base.Initialize();
        }
    }
}
