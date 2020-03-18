using GeonBit.UI;
using GeonBit.UI.Entities;
using GeonBit.UI.Enums;
using Microsoft.Xna.Framework;

namespace GameInterface.Screens {

    public class MainMenuScreen : Screen {
        
        public override void InitializeScreen() {
            Panel menuPanel = new Panel(new Vector2(350, -1), PanelSkin.None, Anchor.Center, new Vector2(0));
            this.AddChild(menuPanel);

            Button onlineButton = new Button("Online Mode", ButtonSkin.Default, Anchor.Auto, new Vector2(0, 50), new Vector2(0));
            onlineButton.OnClick = (Entity btn) => {
                UserInterface.Instance.AddScreen(new OnlineModeScreen());
                UserInterface.Instance.SetCurrentScreen(typeof(OnlineModeScreen));
            };
            Button aiButton = new Button("AI Mode", ButtonSkin.Default, Anchor.Auto, new Vector2(0, 50), new Vector2(0));
            Button replayButton = new Button("Replay Mode", ButtonSkin.Default, Anchor.Auto, new Vector2(0, 50), new Vector2(0));
            Button editDeckButton = new Button("Edit Deck", ButtonSkin.Default, Anchor.Auto, new Vector2(0, 50), new Vector2(0));
            Button settingsButton = new Button("Settings", ButtonSkin.Default, Anchor.Auto, new Vector2(0, 50), new Vector2(0));
            Button exitButton = new Button("Exit", ButtonSkin.Default, Anchor.Auto, new Vector2(0, 50), new Vector2(0, 20));
            exitButton.OnClick = (Entity btn) => {
                UserInterface.Instance.Dispose();
            };

            menuPanel.AddChild(onlineButton);
            menuPanel.AddChild(aiButton);
            menuPanel.AddChild(replayButton);
            menuPanel.AddChild(editDeckButton);
            menuPanel.AddChild(settingsButton);
            menuPanel.AddChild(exitButton);
        }

        public override void UpdateScreen(GameTime gameTime) {

        }

        public override void DrawScreen(GameTime gameTime) {

        }

    }

}
