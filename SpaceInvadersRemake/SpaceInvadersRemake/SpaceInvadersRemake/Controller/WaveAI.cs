using System.Collections.Generic;
using SpaceInvadersRemake.ModelSection;
using Microsoft.Xna.Framework;
using System.Linq;


//Implementiert von Chris
namespace SpaceInvadersRemake.Controller
{
    /// <summary>
    /// Diese Klasse abstrahiert von den verschiedenen KIs zur Steurerung einer Welle von Gegnern
    /// </summary>
    /// <remarks>
    /// Von dieser Klasse ist für die Implementierung einer Wellen KI zu erben.
    /// </remarks>
    public abstract class WaveAI : AIController
    {
        // by STST
        // ADDED (by STST): 29.06.2011
        /// <summary>
        /// Anordnung: [Spalte][Zeile]
        /// </summary>
        protected LinkedList<LinkedList<IGameItem>> AlienMatrix;

        /// <summary>
        /// Erstellt eine neue Instanz eines allgemeinen WaveAI Controllers.
        /// </summary>
        /// <remarks>
        /// Da dies eine Abstrakte Klasse ist, wird dieser innerhalb des Konstruktors der konkreten Klasse aufgerufen.
        /// </remarks>
        /// <param name="shootingFrequency">Die Schussfrequenz.</param>
        /// <param name="controllees">Die GameItem, die der Controller kontrollieren soll.</param>
        /// <param name="velocityIncrease">Geschwindigkeitserhöhung</param>
        protected WaveAI(float shootingFrequency, ICollection<IGameItem> controllees, Vector2 velocityIncrease)
            : base(shootingFrequency, null, velocityIncrease) //null wird das single controllee gesetzt 
        {
            this.Controllees = controllees;
            // <STST>
            this.AlienMatrix = AliensInMatrix();
            // </STST>
        }

        /// <summary>
        /// Eigenschaft Controllees Liste (kontrollierte Objekt)
        /// </summary>
        protected ICollection<IGameItem> Controllees { get; set; }

        // by STST
        // ADDED (by STST): 29.06.2011
        /// <summary>
        /// Ordnet die Aliens in einer Matrix an.
        /// </summary>
        /// <remarks>
        /// Eine Spalte ist ein float-x-Wert.
        /// </remarks>
        /// <returns>Anordnung: [Spalte][Zeile]</returns>
        protected LinkedList<LinkedList<IGameItem>> AliensInMatrix()
        {
            LinkedList<LinkedList<IGameItem>> col = new LinkedList<LinkedList<IGameItem>>();
            SortedDictionary<float, LinkedList<IGameItem>> colDict = new SortedDictionary<float, LinkedList<IGameItem>>();

            //Spalte festlegen:
            foreach (IGameItem gi in Controllees)
            {
                if (!colDict.ContainsKey(gi.Position.X))
                {
                    colDict.Add(gi.Position.X, new LinkedList<IGameItem>());
                }
                colDict[gi.Position.X].AddLast(gi);
            }

            // Spalten ordnen
            foreach (var c in colDict)
            {
                col.AddLast(new LinkedList<IGameItem>(c.Value.OrderBy(gi => gi.Position.Y)));
            }

            return col;
        }
    }
}
