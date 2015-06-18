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

namespace ship_movement_borders
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Nave:
        Texture2D texturaNave;
        Rectangle rectanguloNave;

        //Asteriode:
        Texture2D texturaAsteriode;
        Rectangle rectanguloAsteroide;

        //Velocidad:
        Vector2 velocidad;

        //Pantalla:
        int screenHeight;
        int screenWidth;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        //Inicialización:
        protected override void Initialize()
        {
            // Lógica del programa:
            base.Initialize();
        }

        /// LoadContent:llamado una vez por juego, carga todos los contenidos. 
        protected override void LoadContent()
        {
            //SpriteBatch: dibuja texturas.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here

            //Load parámetros pantalla.
            screenHeight = GraphicsDevice.Viewport.Height;
            screenWidth = GraphicsDevice.Viewport.Width;

            //Load nave
            texturaNave = Content.Load<Texture2D>("nave");
            rectanguloNave = new Rectangle(20, 100, 100, 100);

            //Load asteriode.
            texturaAsteriode = Content.Load<Texture2D>("asteriode");
            rectanguloAsteroide = new Rectangle(20, 100, 100, 100);

            velocidad.X = 3f;
            velocidad.Y = 3f;

        }

        /// UnloadContent: llamado una vez por juego, descarga todos los contenidos.
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// Ejecuta lógica como actualizar el mundo, chequear colisiones, recolectar input y tocar audio
        /// <param name="gameTime">Provee un snapshot of valores de tiempo.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            //Control nave por teclado.
            if (Keyboard.GetState().IsKeyDown(Keys.Right))  {
                rectanguloNave.X += 3;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))   {
                rectanguloNave.X -= 3;                
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))   {
                rectanguloNave.Y += 3;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))     {
                rectanguloNave.Y -= 3;
            }

            //Límites pantalla para nave.
            if (rectanguloNave.X <= 0)  {
                rectanguloNave.X = 0;
            }

            if (rectanguloNave.X + texturaNave.Width >= screenWidth)    {
                rectanguloNave.X = screenWidth - texturaNave.Width;
            }

            if (rectanguloNave.Y <= 0)  {
                rectanguloNave.Y = 0;
            }

            if (rectanguloNave.Y + texturaNave.Height >= screenHeight)  {
                rectanguloNave.Y = screenHeight - texturaNave.Height;
            }

            //Movimiento asteriode.
            rectanguloAsteroide.X = rectanguloAsteroide.X + (int)velocidad.X;
            rectanguloAsteroide.Y = rectanguloAsteroide.Y + (int)velocidad.Y;

            //Rebote pantalla asteroide.
            if (rectanguloAsteroide.X <= 0)
                velocidad.X = -velocidad.X;
            if (rectanguloAsteroide.X + texturaAsteriode.Width >= screenWidth)
                velocidad.X = -velocidad.X;
            if (rectanguloAsteroide.Y <= 0)
                velocidad.Y = -velocidad.Y;
            if (rectanguloAsteroide.Y + texturaAsteriode.Height >= screenHeight)
                velocidad.Y = -velocidad.Y;

            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        // Es llamado cuando el juego se dibuja a si mismo.
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            spriteBatch.Draw(texturaNave, rectanguloNave, Color.White);
            spriteBatch.Draw(texturaAsteriode, rectanguloAsteroide, Color.White);
            spriteBatch.End();
            // TODO: Código a ser dibujado.

            base.Draw(gameTime);
        }
    }
}
