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

        // MODIFIED (by STST): 2.7.2011
        /// <summary>
        /// Erstellt eine neue Instanz eines allgemeinen WaveAI Controllers.
        /// </summary>
        /// <remarks>
        /// Da dies eine Abstrakte Klasse ist, wird dieser innerhalb des Konstruktors der konkreten Klasse aufgerufen.
        /// </remarks>
        /// <param name="shootingFrequency">Die Schussfrequenz.</param>
        /// <param name="controllees">Die GameItem, die der Controller kontrollieren soll.</param>
        /// <param name="velocityIncrease">Geschwindigkeitserhöhung</param>
        /// <param name="controllerManager">Verweis auf Verwaltungsklasse</param>
        protected WaveAI(ControllerManager controllerManager, float shootingFrequency, ICollection<IGameItem> controllees, Vector2 velocityIncrease)
            : base(controllerManager, shootingFrequency, null, velocityIncrease) //null wird das single controllee gesetzt 
        {
            this.Controllees = controllees;
            // <STST>
            this.AlienMatrix = AliensInMatrix();
            // </STST>
        }

        
        /// <summary>
        /// Löscht tote IGameItem aus der Controllees Liste
        /// </summary>
        /// <param name="sender">Das zu löschende Alien</param>
        /// <param name="e">Leere event args</param>
        /// <remarks>
        /// Behandelt das Destroyed Ereignis der Alienklasse
        /// </remarks>
        protected override void Alien_Destroyed(object sender, System.EventArgs e)
        {
            IGameItem item = (IGameItem)sender;

            /* modified by CK 4.7.11
             * Überprüft ob Eventsender ein Alien dieses Controllers ist.Wenn ja,
             * wird Alien aus den Listen dieses Controllers gelöscht und geg. Falls
             * löscht sich der gesammte Controller
            */
            if (this.Controllees.Remove(item))
            {

                // <STST>
                // Alien aus AlienMatrix
                LinkedList<IGameItem> remList = this.AlienMatrix.Where(x => x.Contains(item)).SingleOrDefault();
                if (remList != null)
                    remList.Remove(item);
                // </STST>

                if (this.Controllees.Count == 0)
                {
                    controllerManager.Controllers.Remove(this);
                }
            }
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
            //Suche Tote GameItem und schreibe sie in Liste
            List<IGameItem> deadItems = new List<IGameItem>(this.Controllees.Where(x => x.IsAlive == false));

            //Entferne Tote GameItem
            foreach (var item in deadItems) 
            { 
                this.Controllees.Remove(item);
            }
                


            //modified by CK 
            //foreach (IGameItem item in Controllees.ToArray())
            //{
            //    if (!(item.IsAlive))
            //    {
            //        Controllees.Remove(item);
            //    }
                
            //}

            base.Update(game, gameTime, state);
        }

        // by STST
        // ADDED (by STST): 29.06.2011
        /// <summary>
        /// Ordnet die Aliens in einer Matrix an.
        /// </summary>
        /// <remarks>
        /// Eine Spalte ist ein float-x-Wert.
        /// Der kleinster y-Wert ist unten.
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
