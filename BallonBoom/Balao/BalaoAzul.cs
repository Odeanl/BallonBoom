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
    class BalaoAzul : Balao
    {
        public BalaoAzul(Texture2D Tex)
        {
            Resistencia = 2;
            Pontos = 25;
            this.Textura = Tex;
            VetorBalo.X = R.Next(750);
            EntrouEmJogo = true;
        }
        public void desenhar(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Textura, VetorBalo, new Rectangle(frameatual * tamanhodoframe, 0, 133, 224), Color.White, 0, Vector2.Zero, 0.3f, SpriteEffects.None, 0);
        }
    }
}
