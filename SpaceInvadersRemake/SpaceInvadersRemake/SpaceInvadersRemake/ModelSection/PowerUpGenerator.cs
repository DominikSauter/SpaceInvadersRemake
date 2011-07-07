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
    /// <remarks>
    /// Diese Klasse wird ausschließlich dazu verwendet zufällige oder ausgewählte <c>PowerUps</c>s zu erzeugen.
    /// Das zufällige auftreten von <c>PowerUps</c>s muss an anderer Stelle gelöst werden.
    /// </remarks>
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
        /// Liste die alle verfügbaren PowerUps speichert
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
        /// Diese Methode ist nur ein Workaround, da statische Konstruktoren erst aufgerufen wird,
        /// sobald zum ersten mal ein Objekt der Klasse instanziert wir, oder einen statischen Member
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
        /// <remarks>Bei zufälliger Generierung wird kein <c>StaticShield</c>-PowerUps erzeugt.</remarks>
        /// <param name="type">Typ des PowerUps</param>
        /// <param name="position">Position, an der das PowerUp erstellt werden soll</param>
        public static void GeneratePowerUp(PowerUpEnum type, Vector2 position)
        {
            Vector2 velocity = GameItemConstants.PowerUpVelocity;

            if (type == PowerUpEnum.Random) 
            {
                double powerUpProbability = GameItemConstants.PowerUpProbability;

                // Erstelle mit vorgegebener Wahrscheinlichkeit ein zufälliges PowerUp
                // Überprüfe ob ein neues Power generiert werden soll, breche ab falls nicht
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

            //UNDONE: Fürs erste auskommentiert, da eine schönere Lösung gefunden wurde
            /*switch (type)
            {
                case PowerUpEnum.Random:

                    double powerUpProbability = GameItemConstants.PowerUpProbability;

                    // Überprüfe ob ein neues Power generiert werden soll, breche ab falls nicht
                    double rand = random.NextDouble();
                    if (powerUpProbability < rand)
                        return;

                    //HACK: Wert muss irgendwo anders gespeichert werden
                    // Wahrscheinlichkeit für einzelnes PowerUp berechnen
                    int numPowerUpTypes = 6;
                    double singleProbabiliy = 1.0 / (double)numPowerUpTypes;

                    // Zufallszahl generieren
                    double generated = random.NextDouble();

                    // Spezielles PowerUp generieren
                    if ((generated > 0.0 * singleProbabiliy) && (generated < 1.0 * singleProbabiliy))
                    {
                        // Deflector generieren
                        GeneratePowerUp(PowerUpEnum.Deflector, position);
                    }
                    if ((generated > 1.0 * singleProbabiliy) && (generated < 2.0 * singleProbabiliy))
                    {
                        // MultiShot generieren
                        GeneratePowerUp(PowerUpEnum.MultiShot, position);
                    }
                    if ((generated > 2.0 * singleProbabiliy) && (generated < 3.0 * singleProbabiliy))
                    {
                        // PiercingShot generieren
                        GeneratePowerUp(PowerUpEnum.PiercingShot, position);
                    }
                    if ((generated > 3.0 * singleProbabiliy) && (generated < 4.0 * singleProbabiliy))
                    {
                        // Rapidfire generieren
                        GeneratePowerUp(PowerUpEnum.Rapidfire, position);
                    }
                    if ((generated > 4.0 * singleProbabiliy) && (generated < 5.0 * singleProbabiliy))
                    {
                        // SlowMotion generieren
                        GeneratePowerUp(PowerUpEnum.SlowMotion, position);
                    }
                    if ((generated > 5.0 * singleProbabiliy) && (generated < 6.0 * singleProbabiliy))
                    {
                        // SpeedBoost generieren
                        GeneratePowerUp(PowerUpEnum.Speedboost, position);
                    }

                    break;

                case PowerUpEnum.Deflector:
                    // Deflector erstellen
                    new Deflector(position, velocity);
                    break;

                case PowerUpEnum.MultiShot:
                    // Multishot erstellen
                    new MultiShot(position, velocity);
                    break;

                case PowerUpEnum.PiercingShot:
                    // PiercingShot erstellen
                    new PiercingShot(position, velocity);
                    break;

                case PowerUpEnum.Rapidfire:
                    // Rapidfire erstellen
                    new Rapidfire(position, velocity);
                    break;

                case PowerUpEnum.SlowMotion:
                    // SlowMotion erstellen
                    new SlowMotion(position, velocity);
                    break;

                case PowerUpEnum.Speedboost:
                    // Speedboost erstellen
                    new Speedboost(position, velocity);
                    break;

                default:
                    throw new Exception("Diese PowerUp kann nicht explizit vom PowerUpGenerator erzeugt werden");*/
        }
    }
}
