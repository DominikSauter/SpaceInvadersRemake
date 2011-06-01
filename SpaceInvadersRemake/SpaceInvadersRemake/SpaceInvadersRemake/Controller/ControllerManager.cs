using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvadersRemake.StateMachine;

namespace SpaceInvadersRemake.Controller
{
    
class ControllerManager : IStateController
    {
    public ControllerManager()
    {
        throw new System.NotImplementedException();
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

    public void CreateController(ControllerEnum desiredController, IGameItem Controllee)
    {
        throw new System.NotImplementedException();
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

    public void CreateController(ControllerEnum desiredController, ICollection<IGameItem> Controllee, int shootingFrequenz)
    {
        throw new System.NotImplementedException();
    }

    public void CreateController(ControllerEnum desiredController, IGameItem Controllee, int shootingFrequenz)
    {
        throw new System.NotImplementedException();
    }
    }
}
