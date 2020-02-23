using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;

namespace GameInterface.Screens {
    
    public class OnlineModeScreen : Screen {
        
        public override void InitializeScreen() {
            Panel menuPanel = new Panel(new Vector2(350, -1), PanelSkin.Default, Anchor.Center, new Vector2(0));
            this.AddChild(menuPanel);

            Button multiplayerButton = new Button("Multiplayer Mode", ButtonSkin.Default, Anchor.Auto, new Vector2(0, 50), new Vector2(0));
            Button lanButton = new Button("LAN Mode", ButtonSkin.Default, Anchor.Auto, new Vector2(0, 50), new Vector2(0));
            Button statisticsButton = new Button("Statistics", ButtonSkin.Default, Anchor.Auto, new Vector2(0, 50), new Vector2(0));
            Button backButton = new Button("Back", ButtonSkin.Default, Anchor.Auto, new Vector2(0, 50), new Vector2(0, 20));
            backButton.OnClick = (Entity btn) => {
                UserInterface.Active.SetCurrentScreen(typeof(MainMenuScreen));
            };

            menuPanel.AddChild(multiplayerButton);
            menuPanel.AddChild(lanButton);
            menuPanel.AddChild(statisticsButton);
            menuPanel.AddChild(backButton);
        }

        public override void UpdateScreen(GameTime gameTime) {

        }

        public override void DrawScreen(GameTime gameTime) {

        }

    }

}
