using SpaceInvadersRemake.Settings;
using SpaceInvadersRemake.Resources;

//Implementiert von Tobias

// Wusste nicht genau wo ich die Klasse hinstecken soll, deshalb ist sie ertmal im Obernamespace
namespace SpaceInvadersRemake
{
    /// <summary>
    /// Diese Klasse speichert einen <c>bool</c> und bietet eine <c>ToString</c>-Methode,
    /// die an eine Ressource-Datei gebúnden werden kann.
    /// </summary>
    class OnOff
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="on">An/Aus</param>
        public OnOff(bool on)
        {
            this.On = on;
        }

        /// <summary>
        /// Gibt an ob An oder Aus
        /// </summary>
        public bool On
        {
            get;
            set;
        }

        /// <summary>
        /// Gibt eine string-Repräsentation zurück. Kann durch Ressource-Datei lokalisiert werden.
        /// </summary>
        /// <returns>String-Repräsentation</returns>
        public override string ToString()
        {
            string result = "";


            //TODO: An eine Ressource-Datei binden
            if (On)
            {
                result += Resource.Label_ON;
            }
            else
            {
                result += Resource.Label_OFF;
            }

            return result;
        }
    }
}
