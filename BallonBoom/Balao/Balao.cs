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
    class Balao
    {
        public Texture2D Textura;
        public Rectangle Rec = new Rectangle(100, 600, 50, 75);
        Rectangle RecMouse = new Rectangle(8000, 8000, 1, 1);
        public Vector2 VetorBalo = new Vector2(100, 600);
        public Random R = new Random();
        int atm = 40;
        public int frameatual = 1;
        public int Pontos;
        public int Resistencia;
        public const int tamanhodoframe = 132;
        public long tempodesdeultimoframe;
        public bool BolDoJogo = true;
        public bool EBalaoVermelho = false;
        public bool EBalaoPreto = false;
        public bool EntrouEmJogo = false;

        public void atualizar(GameTime gameTime)
        {
            if (EntrouEmJogo)
            {
                VetorBalo.Y -= 1;
                Rec.X = (int)VetorBalo.X;
                Rec.Y = (int)VetorBalo.Y;
                tempodesdeultimoframe += gameTime.ElapsedGameTime.Milliseconds;
                if (tempodesdeultimoframe >= 140)
                {
                    frameatual++;
                    if (frameatual >= 3)
                        frameatual = 1;
                    tempodesdeultimoframe = 0;
                }
                RecMouse.X = Mouse.GetState().X;
                RecMouse.Y = Mouse.GetState().Y;
                if (Mouse.GetState().LeftButton == ButtonState.Released)
                {
                    atm = 40;
                }
                if (RecMouse.Intersects(Rec))
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed && atm == 40)
                    {
                        
                        atm = 0;
                        Resistencia -= 1;
                    }
                    RecMouse.X += 8000;
                    RecMouse.Y += 8000;

                }
                if (Resistencia <= 0)
                {
                    if (EBalaoVermelho == false)
                    {
                        Jogando.musicas.Play();
                        this.VetorBalo.X = 8000;
                        this.Rec.X = 8000;
                        VidasEPontos.Pontos += Pontos;
                        EntrouEmJogo = false;
                    }
                    if (EBalaoPreto == true)
                    {
                      Jogando.balaopretoativo = true;
			        }    
                    }
                }
            }
        }
    }

