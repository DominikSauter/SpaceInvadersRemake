using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake
{

    /// <summary>
    /// Die Klasse dient dazu sich Gegner (<c>GameItem</c>) in einer Blockformation generieren zu lassen
    /// </summary>
    public class BlockWave : WaveGenerator
    {
        /// <summary>
        /// Generiert eine standard Welle von Gegnern in Blockformation
        /// </summary>
        /// <returns>Ein Array der generierten <c>GameItem</c></returns>
        protected override IGameItem[] GetWave()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Generiert eine individuelle Welle von Gegnern in Blockformation
        /// </summary>
        /// <param name="columns">Anzahl der Spalten der Formation</param>
        /// <param name="lines">Anzahl der Zeilen der Formation.</param>
        /// <returns>Ein Array der generierten <c>GameItem mit <c>columns</c>x <c>lines</c> Einträgen </returns>
        protected override IGameItem[] GetWave(int columns, int lines)
        {
            throw new NotImplementedException();
        }
    }
}
