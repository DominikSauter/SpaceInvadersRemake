

// Wusste nicht genau wo ich die Klasse hinstecken soll, deshalb ist sie ertmal im Obernamespace
namespace SpaceInvadersRemake
{
    /// <summary>
    /// Diese Klasse speichert die Information über eine Bildschirmauflösung und
    /// bietet eine passende <c>ToString</c>-Methode.
    /// </summary>
    class Resolution
    {
        /// <summary>
        /// Konstruktor 
        /// </summary>
        /// <param name="width">Breite</param>
        /// <param name="height">Höhe</param>
        public Resolution(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// Konstruktor, der die benötigten Werte aus einem <c>DisplayMode</c>-Objekt ausliest
        /// </summary>
        /// <param name="displayMode">Anzeigemodus</param>
        public Resolution(Microsoft.Xna.Framework.Graphics.DisplayMode displayMode)
        {
            this.Width = displayMode.Width;
            this.Height = displayMode.Height;
        }

        /// <summary>
        /// Breite der Auflösung
        /// </summary>
        public int Width
        {
            get;
            set;
        }

        /// <summary>
        /// Höhe der Auflösung
        /// </summary>
        public int Height
        {
            get;
            set;
        }

        /// <summary>
        /// Generiert eine String-Darstellung
        /// </summary>
        /// <returns>Die Auflösung als string</returns>
        public override string ToString()
        {
            string result = "";

            result += Width.ToString() + " x " + Height.ToString();

            return result;
        }
    }
}
