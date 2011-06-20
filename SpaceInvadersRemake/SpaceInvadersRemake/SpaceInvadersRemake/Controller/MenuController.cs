using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using SpaceInvadersRemake.StateMachine;
using SpaceInvadersRemake.ModelSection;
using SpaceInvadersRemake.Settings;



namespace SpaceInvadersRemake.Controller
{
    /// <summary>
    /// Diese Klasse stellt die Menüsteuerung dar.
    /// </summary>
    /// <remarks>
    /// Für die Menüsteurung sind folgende Interaktionsmöglichkeiten vorgesehen:
    /// "Cursor" nach oben/unten
    /// Menüpunkt Bestätigen
    /// Zurück 
    /// Falls ein Menüpunkt Einstellungsmöglichkeiten bietet, werden diese mit rechts/links ausgewählt.
    /// </remarks>
    public class MenuController : IController
    {
        /// <summary>
        /// Generiert eine neue Instanz der <see cref="MenuController"/> Klasse.
        /// </summary>
        public MenuController(IModel controllee)
        {
            this.KBconfig = KeyboardConfig.Default;
            this.Controllee = controllee;
        }

        /// <summary>
        /// Eigenschaft Controllees (kontrolliertes Objekt)
        /// </summary>
        /// <value>
        /// kontrolliertes Objekt 
        /// </value>
        public IModel Controllee { get; set; }


        public KeyboardConfig KBconfig { get; set; }


        /// <summary>
        /// Erlaubt die Ausführung der Steuerung.
        /// </summary>
        public void Update(Game game, GameTime gameTime, State state)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
