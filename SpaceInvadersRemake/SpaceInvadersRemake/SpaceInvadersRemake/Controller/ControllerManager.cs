using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvadersRemake.StateMachine;
using SpaceInvadersRemake.ModelSection;

namespace SpaceInvadersRemake.Controller
{

    /// <summary>
    /// Stellt den Einstiegspunkt des Controller-Namespaces dar.
    /// </summary>
    /// <remarks>
    /// Die Controller-Eigenschaft hält alle Controller, die im Spiel sind.
    /// Im Architekturstil MVC fungiert sie als Controller.
    /// </remarks>
public class ControllerManager : IController
    {
    public ControllerManager()
    {
        throw new System.NotImplementedException();
        //TODO Subsribe to Created Event from ModelGod Class

        //TODO Subscribe to Destroyed Event from Controller.controllee
    }

    public ICollection<Controller> Controller
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
    /// Erlaubt die Ausführung der im Controller enthalten Spielmechanik.
    /// </summary>
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
    /// <param name="sender">Absender des Events.</param>
    /// <param name="desiredController">Gibt an welchen Controller man generieert haben möchte.</param>
    public void CreateController(object sender, ControllerEventArgs desiredController) 
        

    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Destroys the controller.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The e.</param>
    //TODO Decide wether it's needed or not
    //Alternative isAlive prüfen bzw 
    public void DestroyController(object sender, EventHandler e)
    {

        throw new System.NotImplementedException();
    }

    }
}
