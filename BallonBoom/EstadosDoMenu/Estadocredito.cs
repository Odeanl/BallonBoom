using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace BallonBoom
{
    class Estadocredito
    {
        private Game1 game;
        public Texture2D Textura;
        public Rectangle Retangulo = new Rectangle(0, 0, 800, 480);
        
        public Estadocredito(Game1 game)
        {
            this.game = game;
        }
        public void LoadContent()
        {
            this.Textura = game.Content.Load<Texture2D>("ArteDoMenu\\credito");
        }
        public void Update(GameTime gameTime)
        {
            
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(Textura, Retangulo, Color.White);
        }
    }
}
