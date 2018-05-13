//Implementiert von Dodo
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Utilityklasse welche alle Texturen und Schriften hält die für die Darstellung der Spieloberflächen benötigt werden.
    /// </summary>
    public class UIContent
    {
        /// <summary>
        /// Textur eines normalen Menübuttons
        /// </summary>
        public Texture2D MenuButton
        {
            get;
            set;
        }

        /// <summary>
        /// Schrift für normalen Text
        /// </summary>
        public SpriteFont Font
        {
            get;
            set;
        }

        /// <summary>
        /// Schrift für die Anzeige der Punktzahl
        /// </summary>
        public SpriteFont FontScore
        {
            get;
            set;
        }

        /// <summary>
        /// Schrift für die Auswahlbuttons in den Untermenü's Audio, Video und Sprache.
        /// </summary>
        public SpriteFont FontSelect
        {
            get;
            set;
        }

        /// <summary>
        /// Hintergrundbild für das Spiel
        /// </summary>
        public Texture2D GameBackgroundImage
        {
            get;
            set;
        }

        /// <summary>
        /// Textur für das HUD (Heads Up Display) im Spiel
        /// </summary>
        public Texture2D HUDBackground
        {
            get;
            set;
        }

        /// <summary>
        /// Hintergrundbild für das Menü
        /// </summary>
        public Texture2D MenuBackgroundImage
        {
            get;
            set;
        }

        /// <summary>
        /// Textur für die Einstellungsbuttons in den Untermenü's, Audio, Video und Sprache.
        /// </summary>
        public Texture2D SettingsButton
        {
            get;
            set;
        }

        /// <summary>
        /// Hintergrundtext für die Untermenü's
        /// </summary>
        public Texture2D SettingsBackground
        {
            get;
            set;
        }

        /// <summary>
        /// Textur zum Anzeigen der Spielerleben
        /// </summary>
        public Texture2D LiveIcon
        {
            get;
            set;
        }

        //[Anji]
        /// <summary>
        /// Grafik für den Spieltitel
        /// </summary>
        public Texture2D GameTitle
        {
            get;
            set;
        }

        /// <summary>
        /// Hintergrundbild um ein bewegtes Weltraumbild darzustellen
        /// </summary>
        public Texture2D StarAnimation
        {
            get;
            set;
        }

        /// <summary>
        /// PowerUp Icon für SpeedUp
        /// </summary>
        public Texture2D SpeedUpIcon
        {
            get;
            set;
        }

        /// <summary>
        /// PowerUp Icon für SlowMotion
        /// </summary>
        public Texture2D SlowMotionIcon
        {
            get;
            set;
        }

        /// <summary>
        /// PowerUp Icon für Multishot
        /// </summary>
        public Texture2D MultishotIcon
        {
            get;
            set;
        }

        /// <summary>
        /// PowerUp Icon für Rapid Fire
        /// </summary>
        public Texture2D RapidFireIcon
        {
            get;
            set;
        }

        /// <summary>
        /// PowerUp Icon für Piercingshot
        /// </summary>
        public Texture2D PiercingShotIcon
        {
            get;
            set;
        }
    }
}
