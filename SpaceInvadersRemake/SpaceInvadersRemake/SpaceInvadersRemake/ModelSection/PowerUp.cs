using System;
using Microsoft.Xna.Framework;

// Implementiert von Tobias

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese abstrakte Klasse ist die Überklasse aller PowerUps die von abgeschossenen Gegnern erzeugt
    /// werden und vom Spieler eingesammelt werden können.
    /// </summary>
    /// <remarks>
    /// <para>Für jedes abgeleitete PowerUp muss ein neuer Eintrag im <c>PowerUpEnum</c> erstellt werden.</para>
    ///
    /// <para>Um eine abgeleitetes PowerUp zufällig oder explizit vom <c>PowerUpGenerator</c> generieren zu 
    /// lassen muss ein statischer Konstuktor geschrieben werden, der das PowerUp beim <c>PowerUpGenerator</c>
    /// registriert.</para>  
    /// 
    /// <para>WORKAROUND: Ein statischer Konstruktor wird erst aufgerufen, wenn ein Objekt der Klasse erzeugt
    /// wird oder auf einen statischen Member verwiesen wird. Deshalb muss zum Registrieren eines PowerUps noch
    /// ein statischer Member eingefürt werden, der in <c>PowerUpGenerator.InitializePowerUpSystem()</c>
    /// gesetzt wird. Dazu wird <c>public static bool IsRegistered</c> empfohlen.</para>
    /// 
    /// <para>Das beigefügte Bespiel erläutert die Vorgehensweise</para>
    /// </remarks>
    /// <example>
    /// Beispiel für nötigen Code zu registrierung in der PowerUp-Unterklasse:
    /// 
    /// <code>
    /// public MyPowerUp : PowerUp
    /// {
    ///     public MyPowerUp(Vector2 position, Vector2 velocity)
    ///     {
    ///         //...
    ///     }
    ///     
    ///     //Workaround
    ///     public static bool IsRegistered = false;
    /// 
    ///     static MyPowerUp() 
    ///     {
    ///         PowerUpGenerator.AddAvailablePowerUp(PowerUpEnum.MyPowerUpType, 1000, delegate(Vector2 pos, Vector2 vel)
    ///                                                                               {
    ///                                                                                    new MyPowerUp(pos, vel);
    ///                                                                               });
    ///     }
    ///     
    ///     //...
    /// 
    /// }
    /// </code>
    /// 
    /// Beispiel für Initialisierung in PowerUpGenerator.InitializePowerUpSystem
    /// 
    /// <code>
    /// InitializePowerUpSystem()
    /// {
    ///     //...    
    /// 
    ///     //Workaround
    ///     MyPowerUp.IsInitialized = true;
    ///     
    ///     //...
    /// }
    /// </code>
    /// </example>
    public abstract class PowerUp : GameItem
    {
        /// <summary>
        /// Beschreibt um welches PowerUp es sich handelt.
        /// </summary>
        /// <remarks>Wird eigentlich nur verwendet um dem generierten ActivePowerUp übergeben zu werden.</remarks>
        protected PowerUpEnum type;

        /// <summary>
        /// Wirkungszeit des PowerUps
        /// </summary>
        protected float duration;
        /// <summary>
        /// Dieses Event wird ausgelöst, wenn ein Objekt der Klasse mit einem anderen Objekt kollidiert ist.
        /// </summary>
        public static event EventHandler Hit;

        /// <summary>
        /// Dieses Event wird ausgelöst, wenn ein Objekt der Klasse zerstört wurde, d.h. dessen Lebenspunkte auf 0 gesunken sind.
        /// </summary>
        public static event EventHandler Destroyed;

        /// <summary>
        /// Dieses Event wird ausgelöst, wenn ein neues Objekt dieser Klasse erzeugt wurde.
        /// </summary>
        public static event EventHandler Created;

        /// <summary>
        /// Diese Methode wird über ein <c>PowerUpAction</c>-Delegate in der <c>ActivePowerUp</c>-Klasse 
        /// dazu benutzt den Effekt des PowerUps am Spieler anzuwenden.
        /// </summary>
        /// <param name="player">Der Spieler bei dem das PowerUp angewendet werden soll.</param>
        public abstract void Apply(Player player);

        /// <summary>
        /// Diese Methode wird über ein <c>PowerUpAction</c>-Delegate in der <c>ActivePowerUp</c>-Klasse 
        /// dazu benutzt den Effekt des PowerUps am Spieler rückgängig zu machen.
        /// </summary>
        /// <param name="player">Der Spieler bei dem das PowerUp entfernt werden soll.</param>
        public abstract void Remove(Player player);

        /// <summary>
        /// In dieser Methode werden alle Werte aktualisiert, die nicht durch einen Controller beeinflusst werden können.
        /// </summary>
        /// <param name="gameTime">Spielzeit</param>
        public override void Update(GameTime gameTime)
        {
            // Bewegt das PowerUp nach unten
            Position += Velocity * CoordinateConstants.Down * (float)gameTime.ElapsedGameTime.TotalSeconds * GameItem.TimeFactor;

            // Wenn das PowerUp aus dem Spielfeld fliegt, dann wird es Zerstört
            if (Position.Y < 1.25 * CoordinateConstants.BottomBorder)
            {
                Hitpoints = 0;
            }
        }

        /// <summary>
        /// Diese Methode wird bei einer Kollision mit einem anderen Objekt aufgerufen. 
        /// Innerhalb der Methode wird der Schaden am übergebenen Objekt berechnet,
        /// oder PowerUps angewendet. Außerdem wird das <c>Hit</c>-Event ausgelöst.
        /// </summary>
        /// <remarks>
        /// Bei der Kollisionsprüfung wird nur verhindert, dass zwei gleichartige Objekte kollidieren. 
        /// Deshalb muss in dieser Methode geprüft werden, ob eine Kollision mit dem übergebenen Objekt überhaupt sinnvoll ist.
        /// </remarks>
        /// <param name="collisionPartner">Das GameItem mit dem die Kollision stattfand.</param>
        public override void IsCollidedWith(IGameItem collisionPartner)
        {
            // PowerUps können nur mit dem Spieler kollidieren
            if (collisionPartner is Player)
            {
                Player player = (Player)collisionPartner;

                // PowerUp dem Spieler hinzufügen
                player.AddPowerUp(new ActivePowerUp(duration, type, new PowerUpAction(Apply), new PowerUpAction(Remove)));

                // Das Hit-Event auslösen
                if (PowerUp.Hit != null)
                    PowerUp.Hit(this, EventArgs.Empty);

                // Das PowerUp wird zertört, wenn es mit dem Spieler Kollidiert
                Hitpoints = 0;
            }
        }

        /// <summary>
        /// Diese Methode wird aufgerufen, wenn die Lebenspunkte auf den Wert 0 oder darunter sinken.
        /// Sie sorgt dafür, dass das <c>Destroyed</c>-Event ausgelöst wird.
        /// </summary>
        protected override void Destroy()
        {
            IsAlive = false;
            if (PowerUp.Destroyed != null)
                PowerUp.Destroyed(this, EventArgs.Empty);
        }

        /// <summary>
        /// Konstruktor um Redundanz zu vermeiden
        /// </summary>
        /// <param name="position">Startposition</param>
        /// <param name="velocity">Maximale Geschwindigkeit</param>
        public PowerUp(Vector2 position, Vector2 velocity)
            : base(position, velocity, 1, 0)
        {
            if (PowerUp.Created != null)
                PowerUp.Created(this, EventArgs.Empty);
        }
    }
}
