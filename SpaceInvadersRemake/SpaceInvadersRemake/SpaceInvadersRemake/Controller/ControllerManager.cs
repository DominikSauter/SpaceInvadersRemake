using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvadersRemake.StateMachine;
using SpaceInvadersRemake.ModelSection;

namespace SpaceInvadersRemake.Controller
{

    /// <summary>
    /// Stellt den Einstiegspunkt des Controllers-Namespaces dar.
    /// </summary>
    /// <remarks>
    /// Die Controllers-Eigenschaft hält alle Controller, die im Spiel sind.
    /// Im Architekturstil MVC fungiert sie als Controller.
    /// </remarks>
public class ControllerManager : IController
    {
        /// <summary>
        /// Erzeugt eine neue Instanz des ControllerManagers.
        /// </summary>
        /// <remarks>
        /// Im Konstruktor wird eine neue Liste für Controller erstellt.
        /// Desweiteren wird ein PlayerController erstellt und diesen der Liste hinzugefügt.
        /// Und es ist sich bei allen für den ControllerManager wichtigen Events anzumelden.
        /// An folgenden Events ist sich zu registrieren:
        /// Alle von ModelSection.Ship erbenden Klassen
        /// </remarks>
    public ControllerManager()
    {
        throw new System.NotImplementedException();
        //TODO Subsribe to Created Event from ModelGod Class
        
       
    }

    /// <summary>
    /// Getter/Setter der Controllers Liste.
    /// </summary>
    /// <value>
    /// Die Liste der Controller.
    /// </value>
    public ICollection<ICommander> Controllers
    {
        get
        {
            throw new System.NotImplementedException();
        }
        set
        {
        }
    }

    /// <summary>
    /// Erlaubt die Ausführung der im Controllers enthalten Spielmechanik.
    /// </summary>
    /// <remarks>
    /// In dieser Methode werden sämmtliche Controller durchiteriert und zum update angeregt.
    /// </remarks>
    /// <param name="game">Referenz des Games aus dem XNA Framework.</param>
    /// <param name="gameTime">Bietet die aktuelle Spielzeit an.</param>
    /// <param name="state">Gibt den aktuellen State an von dem diese Funktion aufgerufen wurde.</param>
    public void Update(Microsoft.Xna.Framework.Game game, Microsoft.Xna.Framework.GameTime gameTime, State state)
    {
       
        
         throw new NotImplementedException();
    }

    /// <summary>
    /// Generiert einen Controller.
    /// </summary>
    /// <remarks>
    /// Diese Methode ist bei dem EventHandler der ModelSection.Ship Klassen zu registrieren.
    /// Die ControllerEventArgs enthalten die relevanten Daten zur Controller Generierung.
    /// Das ControllerEnum beschreibt das vom Model gewünschte Verhalten.
    /// <see cref="ModelSection.ControllerParameters"/>
    /// </remarks>
    /// <param name="sender">Absender des Events.</param>
    /// <param name="desiredController">Gibt an welchen Controllers man generiert haben möchte.</param>
    public void CreateController(object sender, ControllerEventArgs desiredController) 
        

    {
        throw new System.NotImplementedException();
    }



    public void Dispose()
    {
        throw new NotImplementedException();
    }
    }
}
