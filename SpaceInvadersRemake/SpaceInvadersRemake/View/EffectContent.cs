//Implementiert von Dodo
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Utilityklasse welche alle Texturen und Sounds hält, die mit Grafik- oder Soundeffekten zu tun haben.
    /// </summary>
    public class EffectContent
    {
        /// <summary>
        /// Sound für das Erscheinen des Mutterschiffs
        /// </summary>
        public SoundEffect MothershipSound
        {
            get;
            set;
        }

        /*
         * <WAHL>
         * Wird nur benötigt wenn noch eine Partikel Engine eingebaut wird.
        public Texture2D EngineTexture
        {
            get;
            set;
        }
         * */

        /*
         *Wird bisher nich benutzt da noch keine Explosionssounds vorhanden sind.
         *Diese werden erst mit der zugehörigen Partikel Engine eingeführt.
        public SoundEffect ExplosionSound
        {
            get;
            set;
        }
         * */

        /*
         * <WAHL>
         * Wird nur benötigt wenn noch eine Partikel Engine eingebaut wird.
        public Texture2D ExplosionTexture
        {
            get;
            set;
        }
         * */

        /// <summary>
        /// Sound für einen Treffer an einem der Schilde
        /// </summary>
        public SoundEffect ShieldHit
        {
            get;
            set;
        }

        /// <summary>
        /// Sound für einen Treffer am Spielerschiff
        /// </summary>
        public SoundEffect PlayerHit
        {
            get;
            set;
        }

        /// <summary>
        /// Sound für einen Treffer an einem Alienschiff
        /// </summary>
        public SoundEffect EnemyHit
        {
            get;
            set;
        }

        /// <summary>
        /// Hintergrundmusik für das Spiel
        /// </summary>
        public Song GameSong
        {
            get;
            set;
        }

        /// <summary>
        /// Hintergrundmusik für das Menü
        /// </summary>
        public Song MenuSong
        {
            get;
            set;
        }

        /// <summary>
        /// Introvideo
        /// </summary>
        public Video IntroVideo
        {
            get;
            set;
        }

        /*
         * Bisher kein Sound vorhanden. Da die PowerUp's gut sichtbar sind, wird dieser eventuell nicht benötigt.
        public SoundEffect PowerUpSound
        {
            get;
            set;
        }
         * */

        /*
         * <WAHL>
         * Wird nur benötigt wenn noch eine Partikel Engine eingebaut wird.
        public Texture2D PowerUpGlow
        {
            get;
            set;
        }
         * */

        /// <summary>
        /// Sound für das Abfeuern der Multishot-Waffe
        /// </summary>
        public SoundEffect WeaponMultishot
        {
            get;
            set;
        }

        /// <summary>
        /// Sound für das Abfeuern der Piercingshot-Waffe
        /// </summary>
        public SoundEffect WeaponPiercingshot
        {
            get;
            set;
        }

        /// <summary>
        /// Sound für die normale Spielerwaffe
        /// </summary>
        public SoundEffect WeaponPlayer
        {
            get;
            set;
        }

        /// <summary>
        /// Sound für das Abfeuern der RapidFire-Waffe
        /// </summary>
        public SoundEffect WeaponRapidFire
        {
            get;
            set;
        }

        /// <summary>
        /// Sound für die normale Alienwaffe
        /// </summary>
        public SoundEffect WeaponEnemy
        {
            get;
            set;
        }
    }
}
