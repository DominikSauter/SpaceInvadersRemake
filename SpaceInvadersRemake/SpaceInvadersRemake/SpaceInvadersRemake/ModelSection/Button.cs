using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse stellt einen Button im Menü dar
    /// </summary>
    public class Button : MenuControl
    {
        private Action action;
        /// <summary>
        /// Erstellt einen Button
        /// </summary>
        /// <param name="text">Beschriftung</param>
        public Button(string text, Action action)
        {
            throw new System.NotImplementedException();
        }

        public override void Action()
        {
            throw new NotImplementedException();
        }
    }
}
