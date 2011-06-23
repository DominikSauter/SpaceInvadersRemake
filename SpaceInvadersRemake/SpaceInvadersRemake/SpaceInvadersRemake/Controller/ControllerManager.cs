﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvadersRemake.StateMachine;
using SpaceInvadersRemake.ModelSection;
using Microsoft.Xna.Framework;
using SpaceInvadersRemake.Settings;

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
       
        //Init Liste
        Controllers = new List<ICommander>();
        
        
        //Registriere Player EventHandler
        Player.Created += new EventHandler(this.CreatePlayerController);
       
        //Registriere AI EventHandler
        WaveGenerator.WaveGenerated += new EventHandler<ControllerEventArgs>(this.CreateController);




    }

   //Private Fields


    
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
            return Controllers;
        }
       private set
        {
            Controllers = value;
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
    public void Update(Game game,GameTime gameTime, State state)
    {


        foreach (ICommander item in Controllers)
        {
            item.Update(game, gameTime,state);
        }
    }

    /// <summary>
    /// Generiert einen Controller für eine KI Steuerung.
    /// </summary>
    /// <remarks>
    /// Diese Methode ist bei dem EventHandler der WaveGenerator Klasse zu registrieren.
    /// Die ControllerEventArgs enthalten die relevanten Daten zur Controller Generierung.
    /// Das BehaviourEnum beschreibt das vom Model gewünschte Verhalten.
    /// <see cref="ModelSection.BehaviourEnum"/>
    /// </remarks>
    /// <param name="sender">Absender des Events.</param>
    /// <param name="desiredController">Gibt an welchen Controllers man generiert haben möchte.</param>
    public void CreateController(object sender, ControllerEventArgs desiredController) 
    {
        
        //Aus dem Event extrahierte Werte
        IGameItem mySender = (IGameItem) sender;
        ICollection<IGameItem> controllees = desiredController.Controllees;
        int shootingFrequency = desiredController.DifficultyLevel.ShootingFrequency;
        Vector2 velocityIncrease = desiredController.DifficultyLevel.VelocityIncrease;
        
        //Zwischenspeicher für den generierten Controller
        ICommander temp;

        switch (desiredController.Behaviour)
        {
            case BehaviourEnum.BlockMovement:

                temp = new BlockWaveAI(shootingFrequency, controllees, velocityIncrease);

                Controllers.Add(temp);
               
                break;
            
            case BehaviourEnum.MothershipMovement:

                temp = new MothershipAI(shootingFrequency, controllees.First(), velocityIncrease);
                Controllers.Add(temp);

                break;
           
        }


    }


    /// <summary>
    /// Creates the player controller.
    /// </summary>
    /// <remarks>
    /// Sofern eine neue Eingabemöglichkeit Implementiert wurde, muss diese im SupportedInput aufgeführt werden 
    /// und hier ein neuer case hinzugefügt werden.
    /// </remarks>
    /// <param name="sender">Absender des Events</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    public void CreatePlayerController(object sender, EventArgs e) 
    {
        IGameItem  mycontrollee = (IGameItem) sender;
     
        
        switch (GameConfig.Default.Input)
        {
            //HACK hier für neue Eingabemöglichkeit neuen case einfügen.
            
            case SupportedInputEnum.Keyboard: 
            //Keyboard ist auch default, daher Durchreichung an Default case.
            //Kein break
            default:
                Controllers.Add(new KeyboardController(mycontrollee));
                break;


        }
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
