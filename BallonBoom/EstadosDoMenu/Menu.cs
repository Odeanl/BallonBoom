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
    class Menu
    {
        //public Jogando jogo;
        public Estadoinstrucao instrucao1;
        //public Estadorank rank1;
        public Estadocredito credito1;
        public Gerenciador ger;
       

        private Game1 game;

        

        public Menu(Game1 game)
        {

            this.game = game;
      
            //this.credito = new Estadocredito(game);
            this.instrucao1 = new Estadoinstrucao(game);
            //this.rank1 = new Estadorank(game);

            
            
        }

        public void Update(GameTime gameTime, Game1 game)
        {
            ger.atualizar(gameTime, game);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            ger.desenhar(spriteBatch);
        }
    }
}
