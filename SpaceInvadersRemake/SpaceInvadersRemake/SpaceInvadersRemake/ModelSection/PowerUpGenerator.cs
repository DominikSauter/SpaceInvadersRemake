using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

// Implementiert von Tobias

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Dieses Delegate wird dazu verwendet um ein spezielles PowerUp an vorgegebener Position und mit 
    /// vorgegebener Geschwindigkeit zu erstellen
    /// </summary>
    /// <param name="position">Position des neuen PowerUps</param>
    /// <param name="velocity">Geshwindigkeit des PowerUps</param>
    public delegate void CreatePowerUp(Vector2 position, Vector2 velocity);

    /// <summary>
    /// Diese statische Klasse wird verwendet um <c>PowerUps</c>s zu generieren. Sie bietet eine Fabrik-Methode 
    /// um zufällige oder ausgewählte <c>PowerUps</c>s zu erzeugen.
    /// </summary>
    public static class PowerUpGenerator
    {
        /// <summary>
        /// Random-Objekt zur zufälligen Generierung von <c>PowerUps</c>s
        /// </summary>
        private static Random random = new Random();

        
        /// <summary>
        /// Diese innere Klasse wird dazu verwendet um Informationen verfügbarer PowerUps zu halten
        /// </summary>
        private class AvailablePowerUp
        {
            /// <summary>
            /// Konstruktor
            /// </summary>
            /// <param name="type">Typ des PowerUps</param>
            /// <param name="frequency">Häufigkeit des PowerUps</param>
            /// <param name="create">Delegate, mit dem ein neues PowerUp der angegeben Art erzeugt werden kann</param>
            public AvailablePowerUp(PowerUpEnum type, int frequency, CreatePowerUp create)
            {
                this.Type = type;
                this.Frequency = frequency;
                this.Create = create;
            }

            /// <summary>
            /// Typ des PowerUps
            /// </summary>
            public PowerUpEnum Type { get; private set; }

            /// <summary>
            /// Häufigkeit des PowerUps
            /// </summary>
            public int Frequency { get; private set; }

            /// <summary>
            /// Delegate mit dem ein solches PowerUp erzeugt werden kann
            /// </summary>
            public CreatePowerUp Create { get; private set; }
        }

        /// <summary>
        /// Liste, die alle verfügbaren PowerUps speichert
        /// </summary>
        private static List<AvailablePowerUp> availablePowerUps = new List<AvailablePowerUp>();

        /// <summary>
        /// Speichert die Summe aller Häufigkeiten
        /// </summary>
        private static int frequencySum;

        /// <summary>
        /// Fügt ein PowerUp der Liste hinzu
        /// </summary>
        /// <remarks>
        /// Wenn ein PowerUp nicht zufällig erzeut werden soll, dann muss <c>frequency</c> = 0 gesetzt werden.
        /// Außerdem sollte jede Art von PowerUp nur einmal in der Liste vorkommen.
        /// </remarks>
        /// <param name="type">Typ des PowerUps</param>
        /// <param name="frequency">Häufigkeit des PowerUps, ein absoluter Wert, der in Relation zu anderen PowerUps gesetz sein muss. Standardwert zur Orientierung: 1000</param>
        /// <param name="create">Delegate, dass ein neues PowerUp dieser Art erzeugt</param>
        public static void AddAvailablePowerUp(PowerUpEnum type, int frequency, CreatePowerUp create)
        {
            // Füge das PowerUp der Liste hinzu
            availablePowerUps.Add(new AvailablePowerUp(type, frequency, create));

            // Berechnne die Summe aller PowerUps neu
            int sum = 0;

            foreach (AvailablePowerUp powerUp in availablePowerUps)
            {
                sum += powerUp.Frequency;
            }

            frequencySum = sum;
        }


        /// <summary>
        /// Diese Methode wird bei Start des Spiels aufgerufen, um alle PowerUps zu registrieren
        /// </summary>
        /// <remarks>
        /// Diese Methode ist nur ein Workaround, da statische Konstruktoren erst aufgerufen werden,
        /// sobald zum ersten mal ein Objekt der Klasse instanziert wird, oder auf einen statischen Member
        /// verwiesen wird. Möglicherweise wird noch ein Weg gefunden um PowerUps beim PowerUpGenerator
        /// zu registrieren, ohne diese Methode zu verwenden.
        /// </remarks>
        public static void InitializePowerUpSystem()
        {
            //HACK: Wird nur aufgeführt um das Problem mit statischen Konstruktoren zu umgehen
            Deflector.IsRegistered = true;
            MultiShot.IsRegistered = true;
            PiercingShot.IsRegistered = true;
            Rapidfire.IsRegistered = true;
            SlowMotion.IsRegistered = true;
            Speedboost.IsRegistered = true;
        }

        /// <summary>
        /// Diese Methode generiert auf Wunsch ein bestimmtes oder zufälliges <c>PowerUps</c>.
        /// </summary>
        /// <param name="type">Typ des PowerUps</param>
        /// <param name="position">Position, an der das PowerUp erstellt werden soll</param>
        public static void GeneratePowerUp(PowerUpEnum type, Vector2 position)
        {
            Vector2 velocity = GameItemConstants.PowerUpVelocity;

            if (type == PowerUpEnum.Random) // Zufälliges erscheinen eines PowerUps
            {
                double powerUpProbability = GameItemConstants.PowerUpProbability;

                // Erstelle mit vorgegebener Wahrscheinlichkeit ein zufälliges PowerUp
                // Überprüfe ob ein neues PowerUp generiert werden soll, breche ab falls nicht
                double rand = random.NextDouble();
                if (powerUpProbability < rand)
                    return;

                // Erstelle ein zufälliges PowerUp
                int generated = random.Next(frequencySum);
                int offset = 0;

                foreach (AvailablePowerUp powerUp in availablePowerUps)
                {
                    // Wenn das PowerUp gewürfelt wurde, dann wird es erzeugt und die Schleife abgebrochen
                    if (generated < offset + powerUp.Frequency)
                    {
                        if (powerUp.Create != null)
                            powerUp.Create(position, velocity);
                        break;
                    }

                    offset += powerUp.Frequency;
                }

            }
            else 
            {
                // Suche das angegebene PowerUp in der Liste
                AvailablePowerUp selected = availablePowerUps.Find(delegate(AvailablePowerUp powerUp)
                                                                   {
                                                                       return (type == powerUp.Type);
                                                                   });

                // Wenn das PowerUp nicht gefunden wurde, wird eine Exception geworfen
                if (selected == null)
                {
                    throw new Exception("PowerUp nicht in der Liste verfügbarer PowerUps!");
                }

                // Wurde das PowerUp gefunden, dann wird es erzeugt
                if (selected.Create != null)
                    selected.Create(position, velocity);
            }

        }
    }
}
