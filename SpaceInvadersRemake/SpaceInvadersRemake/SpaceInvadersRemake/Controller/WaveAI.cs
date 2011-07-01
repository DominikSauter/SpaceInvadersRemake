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

            Alien.Destroyed += new System.EventHandler(Alien_Destroyed);
        }

        /// <summary>
        /// Löscht tote IGameItem aus der Controllees Liste
        /// </summary>
        /// <param name="sender">Das zu löschende Alien</param>
        /// <param name="e">Leere event args</param>
        /// <remarks>
        /// Behandelt das Destroyed Ereignis der Alienklasse
        /// </remarks>
        protected virtual void Alien_Destroyed(object sender, System.EventArgs e)
        {
            IGameItem item = (IGameItem)sender;

            this.Controllees.Remove(item);
            // <STST>
            // Alien aus AlienMatrix
            foreach (var col in this.AlienMatrix)
            {
                if (col.Contains(item))
                {
                    col.Remove(item); // HACK: Hier gibt's wohl ne Fehler
                    break;
                }
            }
            // </STST>
        }

        /// <summary>
        /// Eigenschaft Controllees Liste (kontrollierte Objekt)
        /// </summary>
        // DESIGN (by STST): 29.06.2011
        protected virtual ICollection<IGameItem> Controllees { get; set; }


        /// <summary>
        /// Erlaubt die Ausführung der Steuerung.
        /// </summary>
        /// <param name="game">Referenz des Games aus dem XNA Framework.</param>
        /// <param name="gameTime">Bietet die aktuelle Spielzeit an.</param>
        /// <param name="state">Gibt den aktuellen State an von dem diese Funktion aufgerufen wurde.</param>
        public override void Update(Game game, GameTime gameTime, StateMachine.State state)
        {
            
            //UNDONE Test BUG ID5
           // Controllees.Last().IsAlive = false;
          
            
            //Entferne Tote GameItem
            foreach (IGameItem item in Controllees.ToArray())
            {
                if (!(item.IsAlive))
                {
                    Controllees.Remove(item);
                }
                
            }

            base.Update(game, gameTime, state);
        }

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
