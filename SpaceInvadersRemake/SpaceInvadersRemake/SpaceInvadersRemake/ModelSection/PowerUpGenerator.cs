using System;
using Microsoft.Xna.Framework;

// Implementiert von Tobias

namespace SpaceInvadersRemake.ModelSection
{
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
        /// Diese Methode generiert auf Wunsch ein bestimmtes oder zufälliges <c>PowerUps</c>.
        /// </summary>
        /// <remarks>Bei zufälliger Generierung wird kein <c>StaticShield</c>-PowerUps erzeugt.</remarks>
        /// <param name="type">Typ des PowerUps</param>
        /// <param name="position">Position, an der das PowerUp erstellt werden soll</param>
        public static void GeneratePowerUp(PowerUpEnum type, Vector2 position)
        {
            Vector2 velocity = GameItemConstants.PowerUpVelocity;

            switch (type)
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

                case PowerUpEnum.StaticShield:
                    // StaticShield erstellen
                    // WARNUNG! StaticShield ist nicht fertig implementiert, solange es noch keine Minibosse gibt
                    new StaticShield(position, velocity);
                    break;

                default:
                    throw new Exception("Diese PowerUp kann nicht vom PowerUpGenerator erzeugt werden");
            }
        }
    }
}
