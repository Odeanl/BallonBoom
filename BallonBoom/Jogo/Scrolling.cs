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
    class Scrolling
    {
        public Texture2D Texture;
        public Rectangle rec1 = new Rectangle(0, 0, 800, 600);
        public Rectangle rec2 = new Rectangle(0, -600, 800, 600);



        public Scrolling(Texture2D Tex)
        {
            this.Texture = Tex;
        }
        
        public void atualizar()
        {
            rec1.Y += 1;
            rec2.Y += 1;
            if (rec1.Y >= 600)
            {
                rec1.Y = -600;
            }
            if (rec2.Y >= 600)
            {
                rec2.Y = -600;
            }
        }
        public void desenhar(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, rec1, Color.White);
            spriteBatch.Draw(Texture, rec2, Color.White);
        }
    }
}
