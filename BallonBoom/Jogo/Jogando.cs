using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace BallonBoom
{
    class Jogando 
    {
        public List<BalaoPreto> baloesPreto = new List<BalaoPreto>();
        public List<BalaoAmarelo> baloesAmarelo = new List<BalaoAmarelo>();
        public List<BalaoVermelho> baloesVermelho = new List<BalaoVermelho>();
        public List<BalaoAzul> baloesAzul = new List<BalaoAzul>();
        public List<BalaoDourado> baloesDourado = new List<BalaoDourado>();
        public Texture2D texbalaovermelho;
        public Texture2D texbalaodourado;
        public Texture2D texbalaoazul;
        public Texture2D texbalaopreto;
        public Texture2D texbalaorosa;
        public Texture2D TexturaDaInterface;
        public Texture2D cenario;
        public Rectangle RecDaInterface = new Rectangle(0, 0, 800, 25);
        public static SoundEffect musicas;

        Rectangle RecMouse = new Rectangle(8000, 8000, 1, 1);
        Scrolling scrolling;
        long freqenc; int TempRespawn; long MudancaDeTempo; int Tempodojogo = 0; int tempodojogoegundos = 0; int ttt = 0;
        public Texture2D TexVida;
        public Rectangle RecVida1 = new Rectangle(0, 5, 15, 15);
        public Rectangle RecVida2 = new Rectangle(15, 5, 15, 15);
        public Rectangle RecVida3 = new Rectangle(30, 5, 15, 15);
        Random R = new Random(); int NRandom;
        SpriteFont pontuacao;
        SpriteFont tempo;
        public static bool balaopretoativo = false;
        public bool VARJOGANDO = true;
        Game1 game;
        VidasEPontos VEP;
        public Jogando(Texture2D bv, Texture2D bp, Texture2D ba, Texture2D br, Texture2D bd, Texture2D tv, SpriteFont sc, Texture2D tdi, SpriteFont tdj , Texture2D CN , SoundEffect msb )
        {
            //this.Game1 = game;
            musicas = msb;
            tempo = tdj;
            TexturaDaInterface = tdi;
            pontuacao = sc;
            TexVida = tv;
            texbalaovermelho = bv;
            texbalaopreto = bp;
            texbalaoazul = ba;
            texbalaorosa = br;
            texbalaodourado = bd;
            scrolling = new Scrolling(CN);
            TempRespawn = 3000;
            VEP = new VidasEPontos();

        }
        public void Load(Game1 game)
        {
            //cenario = game.Content.Load<Texture2D>("Scrolling");
            tempo = game.Content.Load<SpriteFont>("ArteDoJogo//Fonte");
            pontuacao = game.Content.Load<SpriteFont>("ArteDoJogo\\Fonte");
            texbalaovermelho = game.Content.Load<Texture2D>("ArteDoJogo//BalaoVermelho");
            texbalaopreto = game.Content.Load<Texture2D>("ArteDoJogo//BalaoAmarelo");
            texbalaoazul = game.Content.Load<Texture2D>("ArteDoJogo\\BalaoAzul");
            texbalaorosa = game.Content.Load<Texture2D>("ArteDoJogo\\BalaoPreto");
            texbalaodourado = game.Content.Load<Texture2D>("ArteDoJogo\\BalaoDourado");
            

        }

        public void atualizar(GameTime gameTime, Game1 game)
        {
            // pegar o game1\a classe balão e por aqui
            if (VARJOGANDO == true)
            {
                if(Keyboard.GetState().IsKeyDown(Keys.S))
                    if (Keyboard.GetState().IsKeyDown(Keys.C))
                        if (Keyboard.GetState().IsKeyDown(Keys.O))
                            if (Keyboard.GetState().IsKeyDown(Keys.R))
                                if (Keyboard.GetState().IsKeyDown(Keys.R))
                                {
                                    VidasEPontos.Pontos = 40000;
                                }
                if (Keyboard.GetState().IsKeyDown(Keys.J))
                    if (Keyboard.GetState().IsKeyDown(Keys.U) && VidasEPontos.Vida <= 3)
                {
                    VidasEPontos.Vida = 3;
                }
                freqenc += gameTime.ElapsedGameTime.Milliseconds;
                MudancaDeTempo += gameTime.ElapsedGameTime.Milliseconds;
                Tempodojogo += gameTime.ElapsedGameTime.Milliseconds; 
                ttt = Tempodojogo/1000 ;
                if (ttt >= 60)
                {
                    Tempodojogo = 0;
                    ttt = 0;
                    tempodojogoegundos += 1;
                    
                }

                //tempodojogoegundos += ttt;
                if (tempodojogoegundos <= 1)
                {
                    if (freqenc >= TempRespawn)
                    {
                        NRandom = R.Next(100);
                        if (NRandom <= 40)
                        {
                            baloesAmarelo.Add(new BalaoAmarelo(texbalaorosa));
                        }
                        if (NRandom > 40 && NRandom <= 55)
                        {
                            baloesAzul.Add(new BalaoAzul(texbalaoazul));
                        }
                        if (NRandom > 55 && NRandom <= 70)
                        {
                            baloesVermelho.Add(new BalaoVermelho(texbalaovermelho));
                        }
                        if (NRandom > 70 && NRandom <= 80)
                        {
                            baloesDourado.Add(new BalaoDourado(texbalaodourado));
                        }
                        if (NRandom > 95 && NRandom <= 100)
                        {
                            baloesPreto.Add(new BalaoPreto(texbalaopreto));

                        }
                        freqenc = 0;
                    }
                }
                if (tempodojogoegundos > 1 && tempodojogoegundos <= 2)
                {
                    if (freqenc >= TempRespawn)
                    {
                        NRandom = R.Next(100);
                        if (NRandom <= 35)
                        {
                            baloesAmarelo.Add(new BalaoAmarelo(texbalaorosa));
                        }
                        if (NRandom > 35 && NRandom <= 60)
                        {
                            baloesAzul.Add(new BalaoAzul(texbalaoazul));
                        }
                        if (NRandom > 60 && NRandom <= 80)
                        {
                            baloesVermelho.Add(new BalaoVermelho(texbalaovermelho));
                        }
                        if (NRandom > 80 && NRandom <= 95)
                        {
                            baloesDourado.Add(new BalaoDourado(texbalaodourado));
                        }
                        if (NRandom > 95 && NRandom <= 100)
                        {
                            baloesPreto.Add(new BalaoPreto(texbalaopreto));

                        }
                        freqenc = 0;
                    }
                }
                if (tempodojogoegundos > 2 && tempodojogoegundos <= 4)
                {
                    if (freqenc >= TempRespawn)
                    {
                        NRandom = R.Next(100);
                        if (NRandom <= 25)
                        {
                            baloesAmarelo.Add(new BalaoAmarelo(texbalaorosa));
                        }
                        if (NRandom > 25 && NRandom <= 50)
                        {
                            baloesAzul.Add(new BalaoAzul(texbalaoazul));
                        }
                        if (NRandom > 50 && NRandom <= 75)
                        {
                            baloesVermelho.Add(new BalaoVermelho(texbalaovermelho));
                        }
                        if (NRandom > 75 && NRandom <= 97)
                        {
                            baloesDourado.Add(new BalaoDourado(texbalaodourado));
                        }
                        if (NRandom > 97 && NRandom <= 100)
                        {
                            baloesPreto.Add(new BalaoPreto(texbalaopreto));

                        }
                        freqenc = 0;
                    }
                }
                if (tempodojogoegundos >= 5)
                {
                    if (freqenc >= TempRespawn)
                    {
                        NRandom = R.Next(100);
                        if (NRandom <= 15)
                        {
                            baloesAmarelo.Add(new BalaoAmarelo(texbalaorosa));
                        }
                        if (NRandom > 15 && NRandom <= 45)
                        {
                            baloesAzul.Add(new BalaoAzul(texbalaoazul));
                        }
                        if (NRandom > 45 && NRandom <= 65)
                        {
                            baloesVermelho.Add(new BalaoVermelho(texbalaovermelho));
                        }
                        if (NRandom > 65 && NRandom <= 98)
                        {
                            baloesDourado.Add(new BalaoDourado(texbalaodourado));
                        }
                        if (NRandom > 98 && NRandom <= 100)
                        {
                            baloesPreto.Add(new BalaoPreto(texbalaopreto));

                        }
                        freqenc = 0;
                    }
                }
                for (int i = 0; i < baloesAmarelo.Count; i++)
                {
                    baloesAmarelo[i].atualizar(gameTime);

                }
                for (int i = 0; i < baloesAzul.Count; i++)
                {
                    baloesAzul[i].atualizar(gameTime);
                }
                for (int i = 0; i < baloesDourado.Count; i++)
                {
                    baloesDourado[i].atualizar(gameTime);
                }
                for (int i = 0; i < baloesPreto.Count; i++)
                {
                    baloesPreto[i].atualizar(gameTime);

                }
                for (int i = 0; i < baloesVermelho.Count; i++)
                {
                    baloesVermelho[i].atualizar(gameTime);
                }
                if (MudancaDeTempo >= 1000)
                {
                    TempRespawn -= 35;
                    MudancaDeTempo = 0;
                }
                if (MudancaDeTempo >= 2000)
                {
                    TempRespawn -= 50;
                    MudancaDeTempo = 0;
                }
                if (TempRespawn <= 700)
                {
                    TempRespawn = 700;
                }
                ////////////////////////////////////////
                if (VidasEPontos.Vida <= 0)
                {
                    VARJOGANDO = false;
                }
                //////////////////////////////////////
            }
            #region Excluindo Baloes
            /*for (int i = 0  ; i <baloesRosa.Count ; i++)
            {
                if (baloesRosa[i].Rec.Y <= -25)
                {

                    VidasEpontos.Vida -= 1;
                    

                }
            }*/
            /*for (int i = 0; i < baloesAzul.Count; i++)
            {
                if (baloesAzul[i].Rec.Y <= -25)
                {

                    VidasEpontos.Vida -= 1;
                    
                }
            }*/
            /*for (int i = 0; i < baloesDourado.Count; i++)
            {
                if (baloesDourado[i].Rec.Y <= -25)
                {

                    VidasEpontos.Vida -= 1;
                    
                }
            }*/
            for (int i = baloesAmarelo.Count - 1; i > -1; i--)
            {

                if (baloesAmarelo[i].Rec.Y <= -25)
                {
                    //musicas.Play();
                    VidasEPontos.Vida -= 1;
                    baloesAmarelo.RemoveAt(i);
                }
            }
            for (int i = baloesAzul.Count - 1; i > -1; i--)
            {
                if (baloesAzul[i].Rec.Y <= -25)
                {
                    //musicas.Play();
                    VidasEPontos.Vida -= 1;
                    baloesAzul.RemoveAt(i);
                }
            }
            for (int i = baloesDourado.Count - 1; i > -1; i--)
            {
                if (baloesDourado[i].Rec.Y <= -25)
                {
                    //musicas.Play();
                    VidasEPontos.Vida -= 1;

                    baloesDourado.RemoveAt(i);
                }
            }
            for (int i = baloesPreto.Count - 1; i > -1; i--)
            {
                if (baloesPreto[i].Rec.Y <= 25)
                {
                    //musicas.Play();
                    VidasEPontos.Vida -= 1;
                    baloesPreto.RemoveAt(i);
                }
            }
            for (int i = baloesVermelho.Count - 1; i > -1; i--)
            {

                if (baloesVermelho[i].Resistencia <= 0)
                {
                    //musicas.Play();
                    VidasEPontos.Vida -= 1;
                    baloesVermelho.RemoveAt(i);

                }



            }
            #endregion
            scrolling.atualizar();
            //removendo baloes pelo efeito do balao preto
            if (balaopretoativo)
            {

                if (baloesAzul.Count >= 1)
                {
                    for (int i = 0; i < baloesAzul.Count; i++)
                    {
                        
                      baloesAzul[i].Resistencia = 0;
                     
                    }
                }
                if (baloesDourado.Count >= 1)
                {
                    for (int u = 0; u < baloesDourado.Count; u++)
                    {
                       
                      baloesDourado[u].Resistencia = 0;
                        
                    }
                }
                if (baloesAmarelo.Count >= 1)
                {
                    for (int f = 0; f < baloesAmarelo.Count; f++)
                    {
                         baloesAmarelo[f].Resistencia = 0;
                      
                    }
                }
                if (baloesPreto.Count >= 1)
                {
                    for (int z = 0; z < baloesPreto.Count; z++)
                    {
                         baloesPreto[z].Resistencia = 0;
                     
                    }
                }
                if (baloesVermelho.Count >= 1)
                {
                    for (int t = baloesVermelho.Count; t > 0; t--)
                    {
                        baloesVermelho.RemoveAt(t - 1);
                    }
                }
                balaopretoativo = false;
            }
        }
        public void desenhar(SpriteBatch spritebatch)
        {
            scrolling.desenhar(spritebatch);
            for (int i = 0; i < baloesAmarelo.Count; i++)
            {
                baloesAmarelo[i].desenhar(spritebatch);
            }
            for (int i = 0; i < baloesAzul.Count; i++)
            {
                baloesAzul[i].desenhar(spritebatch);
            }
            for (int i = 0; i < baloesDourado.Count; i++)
            {
                baloesDourado[i].desenhar(spritebatch);
            }
            for (int i = 0; i < baloesVermelho.Count; i++)
            {
                baloesVermelho[i].desenhar(spritebatch);
            }
            for (int i = 0; i < baloesPreto.Count; i++)
            {
                baloesPreto[i].desenhar(spritebatch);
            }
            spritebatch.Draw(TexturaDaInterface, RecDaInterface, Color.White);
            spritebatch.DrawString(pontuacao, "Score : " + VidasEPontos.Pontos.ToString(), new Vector2(60, 0), Color.WhiteSmoke);
            spritebatch.DrawString(tempo, "Time  " + tempodojogoegundos+ " : " +ttt, new Vector2(400, 0), Color.WhiteSmoke);
            if (VidasEPontos.Vida == 3)
            {
                spritebatch.Draw(TexVida, RecVida1, Color.White);
                spritebatch.Draw(TexVida, RecVida2, Color.White);
                spritebatch.Draw(TexVida, RecVida3, Color.White);
                //GraphicsDevice.Clear(Color.CornflowerBlue);
            }
            if (VidasEPontos.Vida == 2)
            {
                spritebatch.Draw(TexVida, RecVida1, Color.White);
                spritebatch.Draw(TexVida, RecVida2, Color.White);
                //GraphicsDevice.Clear(Color.CornflowerBlue);
            }
            if (VidasEPontos.Vida == 1)
            {
                spritebatch.Draw(TexVida, RecVida1, Color.White);
                //GraphicsDevice.Clear(Color.CornflowerBlue);
            }
            /*if (VidaEpontos.Vida <= 0)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
            }*/

        }
    }
}
