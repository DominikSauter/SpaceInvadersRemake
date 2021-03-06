﻿//Implementiert von Dodo
using System.Collections.Generic;
using System.Diagnostics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvadersRemake.ModelSection;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Die GameUI(GameUserInterface) Klasse stellt die Spieloberfläche während des Spiels via der <c>Draw()</c> Methode dar.
    /// </summary>
    public class GameUI : IView
    {
        private GraphicsDeviceManager graphics;

        private Texture2D gameBackgroundImage;
        private Texture2D hudBackgroundTexture;
        private SpriteFont fontText;
        private SpriteFont fontScore;
        private Texture2D liveIcon;
        private StateMachine.InGameState inGameState;

        //Textur, Rectangles und float's um die Sternenanimation zu ermöglichen
        private Texture2D starAnimation;
        private Rectangle starsTarget_1;
        private Rectangle starsTarget_2;
        private float starsOffset;
        private float starsSpeed;

        /// <summary>
        /// Initialisiert die Spieloberfläche
        /// </summary>
        /// <param name="currentState">akuteller State</param>
        /// <param name="graphics">Handlingobejekt für Grafikeinstellungen</param>
        public GameUI(StateMachine.InGameState currentState, GraphicsDeviceManager graphics)
        {
            this.graphics = graphics;

            this.inGameState = currentState;
            this.fontText = ViewContent.UIContent.Font;
            this.fontScore = ViewContent.UIContent.FontScore;
            this.gameBackgroundImage = ViewContent.UIContent.GameBackgroundImage;
            this.hudBackgroundTexture = ViewContent.UIContent.HUDBackground;
            this.liveIcon = ViewContent.UIContent.LiveIcon;

            //Rectangles werden übereinander positioniert, das 2te ausserhalb des bildes.
            this.starAnimation = ViewContent.UIContent.StarAnimation;
            this.starsTarget_1 = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            this.starsTarget_2 = new Rectangle(0, -graphics.PreferredBackBufferHeight, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            this.starsOffset = 0.0f;
            this.starsSpeed = 0.2f;
        }

        /// <summary>
        /// Zeichnet die Spieloberfläche zu einem Zeitpunkt des Spiels.
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch um auf den Bildschirm zu zeichnen.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            GameCourseManager gameCourseMngr = (GameCourseManager)this.inGameState.Model;

            //Anzahl an Leben und Punkte aus dem Model
            int lives = gameCourseMngr.GameCourse.Player.Lives;
            int score = gameCourseMngr.GameCourse.Player.Score;

            //List der aktiven PowerUp's
            List<ActivePowerUp> powerUps = gameCourseMngr.GameCourse.Player.ActivePowerUps;
            List<Texture2D> powerUpIcons = getPowerUpIcons(powerUps);

            //Prüfen ob das Schild-PowerUp aktiv ist.
            bool shielded = false;
            if (gameCourseMngr.GameCourse.Player.Hitpoints > GameItemConstants.PlayerHitpoints)
            {
                shielded = true;
            }
            

            //Counter, der angibt wie oft die HUD Grafik (32x60) gezeichnet werden muss. 1 Kachel mehr, da nicht alle Maße durch 32 teilbar sind.
            int hudTileCount = graphics.PreferredBackBufferWidth / this.hudBackgroundTexture.Width + 1;

            //Farbe für die Spielerleben Icons, abhängig von der Anzahl der Leben
            Color liveColor;

            //Vektor mit Länge/Breite für den String welcher die Punktzahl darstellt
            Vector2 scoreStringLength = this.fontText.MeasureString(score.ToString());

            //Zentrierte Y Position der Punktzahl im HUD
            float scoreCenterPosition = (this.hudBackgroundTexture.Height - scoreStringLength.Y) / 2.0f;

            /*  Festlegen der Farben:
             *      1 Leben => ROT
             *      2 Leben => GELB
             *      3 Leben => GRÜN
             * */
            if (lives == 1)
            {
                liveColor = Color.Red;
            }
            else if (lives == 2)
            {
                liveColor = Color.Yellow;
            }
            else
            {
                liveColor = Color.Green;
            }

            //Sollte der Spieler ein aktives Schild haben werden die Leben Hellblau angezeigt
            if (shielded)
            {
                liveColor = Color.LightBlue;
            }

            //berechnen der neuen Position der Rectanlges für die Bilder.
            this.starsTarget_1.Y += (int)this.starsOffset;
            this.starsTarget_2.Y += (int)this.starsOffset;
            //sobald Bild1 den unteren Rand erreicht hat, werden beide zurückgesetzt.
            if (starsTarget_1.Y > graphics.PreferredBackBufferHeight)
            {
                this.starsTarget_1.Y = 0;
                this.starsTarget_2.Y = -graphics.PreferredBackBufferHeight;
            }
            //erhöhen und evtl zurücksetzten des Offsets
            //da float um eine Verzögerung des Neuzeichnens zu erreichen, da Rectangles als Position nur int's fassen.
            this.starsOffset += this.starsSpeed;
            if (this.starsOffset >= 1.1f)
            {
                this.starsOffset = 0.0f;
            }

            //neuer DepthStencilState, damit keine Objekte über dem HUD gezeichnet werden.
            DepthStencilState drawStencil = new DepthStencilState();
            drawStencil.StencilEnable = true;


            spriteBatch.Begin();

            //zeichnet das Hintergrundbild in Abhängigkeit von der Auflösung des Fensters
            spriteBatch.Draw(this.gameBackgroundImage, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            //zeichnet die Sternenanimation
            spriteBatch.Draw(this.starAnimation, starsTarget_1, Color.White);
            spriteBatch.Draw(this.starAnimation, this.starsTarget_2, Color.White);

            spriteBatch.End();


            //Um zu erreichen, das kein Objekt über den HUD gezeichnet wird, wird der zuvor erzeugte DepthStencilState verwendet.
            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, drawStencil, null);
            //zeichnet die HUD-Kacheln abhängig von der Breite des Fensters
            for (int tileCount = 0; tileCount < hudTileCount; tileCount++)
            {
                spriteBatch.Draw(this.hudBackgroundTexture, new Vector2((float)(tileCount * this.hudBackgroundTexture.Width),
                    (float)(graphics.PreferredBackBufferHeight - this.hudBackgroundTexture.Height)), Color.White);
            }

            //zeichnet 1-3 Lebens Icons
            for (int liveCount = 0; liveCount < lives; liveCount++)
            {
                //Zentrierung erfolgt dadurch, dass beide Grafiken 50Pixel hoch sind.
                spriteBatch.Draw(this.liveIcon, new Vector2((float)((liveCount) * this.liveIcon.Width),
                    (float)(graphics.PreferredBackBufferHeight - this.hudBackgroundTexture.Height)), liveColor);
            }

            //beschriftet den HUD mit der aktuellen Punktzahl
            spriteBatch.DrawString(this.fontScore, score.ToString(), new Vector2((float)(graphics.PreferredBackBufferWidth - scoreStringLength.X - 20.0f),
                (float)(graphics.PreferredBackBufferHeight - this.hudBackgroundTexture.Height + scoreCenterPosition)), Color.Green);

            for (int i = 0; i < powerUpIcons.Count; i++)
            {
                Texture2D icon = powerUpIcons[i];
                Rectangle position = new Rectangle(10 , 70 * i, icon.Width, icon.Height);
                spriteBatch.Draw(icon, position, Color.White);
                spriteBatch.DrawString(this.fontText, ((int)powerUps[i].TimeLeft).ToString(), new Vector2(icon.Width + 20, 70 * i), Color.Yellow);
            }

            spriteBatch.End();
        }

        /// <summary>
        /// Füllt anhand der aktiven PowerUp's die passenden Icons in eine Liste.
        /// </summary>
        /// <param name="powerUps">List der aktiven PowerUp's</param>
        /// <returns>Liste der Icons für die aktiven PowerUp's</returns>
        private List<Texture2D> getPowerUpIcons(List<ActivePowerUp> powerUps)
        {
            Debug.Assert(powerUps != null, "Die Referenz auf die List der Power Ups ist nicht vorhanden!");
            List<Texture2D> icons = new List<Texture2D>();

            foreach (ActivePowerUp item in powerUps)
            {
                if (item.Type == PowerUpEnum.Speedboost)
                {
                    icons.Add(ViewContent.UIContent.SpeedUpIcon);
                }
                else if (item.Type == PowerUpEnum.MultiShot)
                {
                    icons.Add(ViewContent.UIContent.MultishotIcon);
                }
                else if (item.Type == PowerUpEnum.PiercingShot)
                {
                    icons.Add(ViewContent.UIContent.PiercingShotIcon);
                }
                else if (item.Type == PowerUpEnum.Rapidfire)
                {
                    icons.Add(ViewContent.UIContent.RapidFireIcon);
                }
                else if (item.Type == PowerUpEnum.SlowMotion)
                {
                    icons.Add(ViewContent.UIContent.SlowMotionIcon);
                }
            }

            return icons;
        }
    }
}
