using Microsoft.Xna.Framework;
using SpaceInvadersRemake.ModelSection;

//Implementiert von Christian (CK)
namespace SpaceInvadersRemake.Controller
{
    /// <summary>
    /// Diese Klasse abstrahiert von den verschiedenen Steuerungen durch die KI
    /// </summary>
    /// <remarks>
    /// In den Abgeleiteten Klassen wird das Verhalten des Controllers durch die KI bestimmt
    /// Von dieser KLasse muss geerbt werden um eine KI-Eingabe zu impelmentieren.
    /// </remarks>
    public abstract class AIController : SpaceInvadersRemake.Controller.Controller
    {

        /// <summary>
        /// Erstellt eine neue Instanz eines algemeinen AIControllers.
        /// </summary>
        /// <remarks>
        /// Da dies eine Abstrakte Klasse ist, wird dieser Konstruktor innerhalb des Konstruktors der konkreten Klasse aufgerufen.
        /// </remarks>
        /// <param name="shootingFrequency">Die Schussfrequenz.</param>
        /// <param name="controllee">Das GameItem, das der Controller kontrollieren soll.</param>
        /// <param name="velocityIncrease">Geschwindigkeitserhöhung</param>
        /// <param name="controllerManager">Verweis auf Verwaltungsklasse</param>
        protected AIController(ControllerManager controllerManager, float shootingFrequency, IGameItem controllee, Vector2 velocityIncrease)
            : base(controllerManager, controllee)
        {
            this.ShootingFrequency = shootingFrequency;
            this.VelocityIncrease = velocityIncrease;

            // STST
            Alien.Destroyed += new System.EventHandler(Alien_Destroyed);
        }


        // ADDED (by STST): 2.7.2011
        /// <summary>
        /// Löscht sich aus ControllerManager.Controllers-Liste, falls Alien zerstört wurde.
        /// </summary>
        /// <param name="sender">Das zu löschende Alien</param>
        /// <param name="e">Leere event args</param>
        /// <remarks>
        /// Behandelt das Destroyed Ereignis der Alienklasse
        /// </remarks>
        protected virtual void Alien_Destroyed(object sender, System.EventArgs e)
        {
            IGameItem item = (IGameItem)sender;

            if (this.Controllee == item)
                controllerManager.Controllers.Remove(this);
        }

        /// <summary>
        /// Getter/Setter der Schussfrequenz.
        /// </summary>
        /// <value>
        /// Die Schussfrequenz.
        /// </value>
        protected float ShootingFrequency { get; set; }


        /// <summary>
        /// Getter/Setter der Geschwindigkeitserhöhung.
        /// </summary>
        /// <value>
        /// Die Geschwindigkeitserhöhung.
        /// </value>
       public Vector2 VelocityIncrease { get; set; }
    }
}
