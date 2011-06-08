using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse stellt ein Menü dar, das mit verschiedenen Steuerelementen initialisiert wird. Von Außen kann ein Controller über die Funktionen "Up", "Down", "Left", "Right" und "Action" das Menü beeinflussen.
    /// </summary>
    public class Menu : SpaceInvadersRemake.StateMachine.IModel
    {
        /// <summary>
        /// Speichert die Menüelemente
        /// </summary>
        private System.Collections.Generic.List<SpaceInvadersRemake.ModelSection.MenuControl> controls;

        /// <summary>
        /// Ertellt ein neues Menü
        /// </summary>
        /// <param name="controls">Die Liste der Menüeinträge</param>
        public Menu(List<MenuControl> controls)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gibt die Menüelemente als Array zurück
        /// </summary>
        public SpaceInvadersRemake.ModelSection.MenuControl[] Controls
        {
            get
            {
                return controls.ToArray();
            }
        }

        /// <summary>
        /// Das derzeit aktive Menüelement
        /// </summary>
        public MenuControl ActiveControl
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
        /// Ruft die "Action"-Methode des aktiven Elements auf
        /// </summary>
        public void Action()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Updatet das Menü (momentan ohne Funktion)
        /// </summary>
        /// <param name="game">Referenz zum aktuellen Spiel</param>
        /// <param name="gameTime">Spielzeit</param>
        /// <param name="state">Referenz zum Zustand, der die Methode aufgerufen hat</param>
        public void Update(Microsoft.Xna.Framework.Game game, Microsoft.Xna.Framework.GameTime gameTime, StateMachine.State state)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Wählt das untere Menüelement aus. Wenn das unterste Element bereits gewählt ist, dann springt die Auswahl zum obersten Element.
        /// </summary>
        public void Down()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Wählt das obere Menüelement aus. Wenn das oberste Element bereits gewählt ist, dann springt die Auswahl zum untersten Element.
        /// </summary>
        public void Up()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Ruft die "Prev"-Methode des aktiven Elements auf
        /// </summary>
        public void Left()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Ruft die "Next"-Methode des aktiven Elements auf
        /// </summary>
        public void Right()
        {
            throw new System.NotImplementedException();
        }
    }
}
