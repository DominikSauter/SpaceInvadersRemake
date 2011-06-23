using System;
using System.Collections.Generic;

// Implementiert von Tobias

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse stellt ein Menü dar, das mit verschiedenen Steuerelementen initialisiert wird. 
    /// Von Außen kann ein Controller über die Funktionen "Up", "Down", "Left", "Right" und "Action" 
    /// das Menü beeinflussen.
    /// </summary>
    public class Menu : SpaceInvadersRemake.StateMachine.IModel
    {
        /// <summary>
        /// Speichert die Menüelemente
        /// </summary>
        private List<MenuControl> controls;

        /// <summary>
        /// Ertellt ein neues Menü
        /// </summary>
        /// <param name="controls">Die Liste der Menüeinträge</param>
        public Menu(List<MenuControl> controls)
        {
            this.controls = controls;
            controls[0].Active = true;
            ActiveControl = controls[0];
            
        }

        /// <summary>
        /// Gibt die Menüelemente als Array zurück
        /// </summary>
        public MenuControl[] Controls
        {
            get
            {
                return controls.ToArray();
            }
            private set
            {
            }
        }

        /// <summary>
        /// Das derzeit aktive Menüelement
        /// </summary>
        public MenuControl ActiveControl
        {
            get;
            private set;
        }

        /// <summary>
        /// Ruft die <c>Action-Methode</c> des aktiven Elements auf
        /// </summary>
        public void Action()
        {
            ActiveControl.Action();
        }

        public void Update(Microsoft.Xna.Framework.Game game, Microsoft.Xna.Framework.GameTime gameTime, StateMachine.State state)
        {
            // nicht benötigt
        }

        /// <summary>
        /// Wählt das Menüelement unter dem derzeit aktiven aus. Wenn das unterste Element bereits gewählt 
        /// ist, dann springt die Auswahl zum obersten Element.
        /// </summary>
        public void Down()
        {
            ActiveControl.Active = false;
            int i = controls.IndexOf(ActiveControl);
            ActiveControl = controls[(i+1)%controls.Count];
            ActiveControl.Active = true;
        }

        /// <summary>
        /// Wählt das Menüelement über dem derzeit aktiven aus. Wenn das oberste Element bereits gewählt 
        /// ist, dann springt die Auswahl zum untersten Element.
        /// </summary>
        public void Up()
        {
            ActiveControl.Active = false;
            int i = controls.IndexOf(ActiveControl);
            ActiveControl = controls[(i - 1) % controls.Count];
            ActiveControl.Active = true;
        }

        /// <summary>
        /// Ruft die <c>Prev</c>-Methode des aktiven Elements auf
        /// </summary>
        public void Left()
        {
            ActiveControl.Prev();
        }

        /// <summary>
        /// Ruft die <c>Next</c>-Methode des aktiven Elements auf
        /// </summary>
        public void Right()
        {
            ActiveControl.Next();
        }

        public void Dispose()
        {
            controls.Clear();
        }
    }
}
