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
    class Gerenciador
    {
        

        public static Rectangle ponteiro = Rectangle.Empty;

        public static int x;
        public static int y;

        public static Estatosjogo cenas = Estatosjogo.Menu;

        
        
        public  Texture2D instrucao;
        public  Texture2D voltar;
        public  Texture2D sair;
        public  Texture2D jogar;
        public Texture2D telamenu;
        public Texture2D voltarmenu;
        public Texture2D creditts;
        
        public static Rectangle rectelamenu = new Rectangle(0, 0, 800, 480);
        public static Rectangle recinstrucao = new Rectangle(315, 250, 120, 55);
        public static Rectangle recsair = new Rectangle(315, 400, 120, 55);
        public static Rectangle recjogar = new Rectangle(315, 170, 120, 55);
        public static Rectangle reccreditts = new Rectangle(315,330,120,55);
        public static Rectangle recvoltar = new Rectangle(510, 425, 120, 55);
        public static Rectangle recvoltarmenu = new Rectangle(510, 360, 120, 55);
        
        public Estadoinstrucao instrucao1;
        public Estadocredito credito1;
        public EstadoPause PAUSE;
        public Estadogameover gameover1;

        public Texture2D texbalãovermelho1;
        public Texture2D texbalãodourado1;
        public Texture2D texbalãoazul1;
        public Texture2D texbalãopreto1;
        public Texture2D texbalãorosa1;
        public Texture2D balaovida1;
        public Texture2D texturadainterface;
        public Texture2D cenario1;
        public SpriteFont score1;
        public SpriteFont tempo1;
        public Texture2D TexturaDaInterface1;
        public Texture2D TexVida1;
        public Jogando jogos;
        public SoundEffect musicas1;
        public SoundEffect musicadojogo;
        long tempodetroca = 0;
        SpriteFont Pontuacaonogame;

        public Gerenciador(Game1 game)
        {

            
            this.credito1 = new Estadocredito(game);
            this.instrucao1 = new Estadoinstrucao(game);
            this.PAUSE = new EstadoPause(game);
            this.gameover1 = new Estadogameover(game);

            
            
        }

        public void LoadContent(Game1 game)
        {
            jogar = game.Content.Load<Texture2D>("ArteDoMenu\\Play");
            instrucao = game.Content.Load<Texture2D>("ArteDoMenu\\Instructions");
            sair = game.Content.Load<Texture2D>("ArteDoMenu\\Exit");
            creditts = game.Content.Load<Texture2D>("ArteDoMenu//credit");
            voltar = game.Content.Load<Texture2D>("ArteDoMenu\\Back");
            telamenu = game.Content.Load<Texture2D>("ArteDoMenu\\Menu");
            voltarmenu = game.Content.Load<Texture2D>("ArteDoMenu\\ReturnToMenu");
            texbalãovermelho1 = game.Content.Load<Texture2D>("ArteDoJogo//BalaoVermelho");
            texbalãopreto1 = game.Content.Load<Texture2D>("ArteDoJogo//BalaoAmarelo");
            texbalãoazul1 = game.Content.Load<Texture2D>("ArteDoJogo//BalaoAzul");
            texbalãorosa1 = game.Content.Load<Texture2D>("ArteDoJogo//BalaoPreto");
            texbalãodourado1 = game.Content.Load<Texture2D>("ArteDoJogo//BalaoDourado");
            texturadainterface = game.Content.Load<Texture2D>("ArteDoJogo\\barra");
            balaovida1 = game.Content.Load<Texture2D>("ArteDoJogo\\balaoDeVida");
            score1 = game.Content.Load<SpriteFont>("ArteDoJogo\\Fonte");
            tempo1 = game.Content.Load<SpriteFont>("ArteDoJogo//Fonte");
            cenario1 = game.Content.Load<Texture2D>("Back");
            Pontuacaonogame = game.Content.Load<SpriteFont>("ArteDoJogo//Fonte2");
            musicas1 = game.Content.Load<SoundEffect>("explosao");
            musicadojogo = game.Content.Load<SoundEffect>("sondojogo");
            //jogos.Load(game);
            gameover1.LoadContent();
            credito1.LoadContent();
            instrucao1.LoadContent();
            PAUSE.LoadContent();

        }

        public void atualizar(GameTime gameTime, Game1 game)
        {
            x = Mouse.GetState().X;
            y = Mouse.GetState().Y;
            ponteiro.X = x;
            ponteiro.Y = y;
            ponteiro.Width = 1;
            ponteiro.Height = 1;

            switch (cenas)
            {
                case Estatosjogo.Menu:
                    //musicadojogo.Play();
                    if (recjogar.Contains(ponteiro))
                    {
                        if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                        {
                            
                            jogos = new Jogando(texbalãovermelho1, texbalãodourado1, texbalãoazul1, texbalãopreto1, texbalãorosa1, balaovida1, score1, texturadainterface, tempo1, cenario1, musicas1);
                            VidasEPontos.Pontos = 0;
                            cenas = Estatosjogo.Jogo;
                            //musicas1.Dispose();
                            
                            
                        }
                    }
                    //if (Keyboard.GetState().IsKeyDown(Keys.P))
                    //{
                    //    //if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    //        cenas = Estatosjogo.Pause;
                    //}
                    if (recinstrucao.Contains(ponteiro))
                    {
                        if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                            cenas = Estatosjogo.instrucoes;
                    }
                    /*if (recCreditos.Contains(posMouse))
                    {
                        if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                            cenasJogo = Cenas.Creditos;
                    }*/
                    if (reccreditts.Contains(ponteiro))
                    {
                        if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                        {
                            cenas = Estatosjogo.Creditos;
                        }
                    }
                    if (recsair.Contains(ponteiro))
                    {
                        if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                            cenas = Estatosjogo.Sair;
                         if (recvoltar.Contains(ponteiro))
                    {
                        if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                            cenas = Estatosjogo.Menu;
                    }

                    }
                    break;
                
                case Estatosjogo.Jogo :
                    jogos.atualizar(gameTime, game);
                    if (Keyboard.GetState().IsKeyDown(Keys.P))
                    {
                        //if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                        cenas = Estatosjogo.Pause;
                    }
                    if (VidasEPontos.Vida <= 0)
                    {
                        cenas = Estatosjogo.Gameover;
                    }
                    break;
                case Estatosjogo.Sair :
                    game.Exit();
                    break;
                case Estatosjogo.Gameover :
                    jogos = new Jogando(texbalãovermelho1, texbalãodourado1, texbalãoazul1, texbalãopreto1, texbalãorosa1, balaovida1, score1, texturadainterface, tempo1, cenario1,musicas1);
                    credito1.Update(gameTime);
                    break;

            }
        }
            public void desenhar(SpriteBatch spriteBatch)
        {
            
            switch (cenas)
            {
                case Estatosjogo.Menu :

                    
                    spriteBatch.Draw(telamenu, rectelamenu, Color.White);
                    spriteBatch.Draw(jogar, recjogar, Color.White);
                    spriteBatch.Draw(instrucao, recinstrucao, Color.White);
                    spriteBatch.Draw(sair,recsair, Color.White);
                    spriteBatch.Draw(creditts, reccreditts, Color.White);
                    break;

                case Estatosjogo.Jogo :
                    jogos.desenhar(spriteBatch);
                    //spriteBatch.Draw(voltar, recvoltar, Color.White);
                    if (Keyboard.GetState().IsKeyDown(Keys.P))
                    {
                        //if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                        
                            cenas = Estatosjogo.Pause;

                        

                    }
                    break;
                case Estatosjogo.instrucoes :
                    instrucao1.Draw(spriteBatch);
                    spriteBatch.Draw(voltar, recvoltar, Color.White);
                    if (recvoltar.Contains(ponteiro))
                    {
                        if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                            cenas = Estatosjogo.Menu;

                    }
                      
                    break;

                case Estatosjogo.Gameover:
                    gameover1.Draw(spriteBatch);
                    spriteBatch.DrawString(Pontuacaonogame, "Your score was :" + VidasEPontos.Pontos, new Vector2(300, 300), Color.White);
                    if (VidasEPontos.Pontos <= 1000)
                    {
                        spriteBatch.DrawString(score1, "Need More Training!", new Vector2(300, 200), Color.White);
                    }
                    if (VidasEPontos.Pontos >= 1001 && VidasEPontos.Pontos <= 3000)
                    {
                        spriteBatch.DrawString(score1, "You Can Do Better!", new Vector2(300, 200), Color.White);
                    }
                    if (VidasEPontos.Pontos >= 3001 && VidasEPontos.Pontos <= 6999)
                    {
                        spriteBatch.DrawString(score1, "Well it was, but there are people who do best ...", new Vector2(300, 200), Color.White);
                    }
                    if (VidasEPontos.Pontos >=7000  && VidasEPontos.Pontos <= 20000)
                    {
                        spriteBatch.DrawString(score1, "Very Good! ", new Vector2(300, 200), Color.White);
                    }
                    if (VidasEPontos.Pontos >= 20001)
                    {
                        spriteBatch.DrawString(score1, "Are you God?", new Vector2(300, 200), Color.White);
                    }
                    spriteBatch.Draw(voltarmenu, recvoltar, Color.White);
                    if (recvoltar.Contains(ponteiro))
                    {
                        if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                            
                            cenas = Estatosjogo.Menu;

                    }
                    break;
                case Estatosjogo.Creditos :
                    credito1.Draw(spriteBatch);
                    spriteBatch.Draw(voltar, recvoltar, Color.White);
                    if (recvoltar.Contains(ponteiro))
                    {
                        if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                            cenas = Estatosjogo.Menu;

                    }
                    break;
                
                case Estatosjogo.Pause :
                    PAUSE.Draw(spriteBatch);
                    spriteBatch.Draw(voltar, recvoltar, Color.White);
                    spriteBatch.Draw(voltarmenu , recvoltarmenu , Color.White);
                    if (recvoltar.Contains(ponteiro))
                    {
                        if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                            cenas = Estatosjogo.Jogo;

                    }
                    if (recvoltarmenu.Contains(ponteiro))
                    {
                        if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                        {
                            cenas = Estatosjogo.Menu;
                        }
                    }
                    break;
                case Estatosjogo.Sair:


                    //this.Exit();



                    break;

            }

            
            
                   


        }
    }
}
