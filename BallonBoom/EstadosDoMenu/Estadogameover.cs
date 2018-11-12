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
    class Estadogameover
    {
        private Game1 game;

        public Rectangle Retangulo = new Rectangle(0, 0, 800, 480);
        public Texture2D Textura;
        long tempodetroca;
        public bool troca = false;
        

        public Estadogameover(Game1 game)
        {
            this.game = game;
        }
        public void LoadContent()
        {
            this.Textura = game.Content.Load<Texture2D>("ArteDoMenu\\GameOver");
        }
        public void Update(GameTime gameTime)
        {
            tempodetroca += gameTime.ElapsedGameTime.Milliseconds;
            if (tempodetroca >= 4000)
            {
                troca = true;
            }
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(Textura, Retangulo, Color.White);
        }
    }
}
