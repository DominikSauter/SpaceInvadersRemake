﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Bestimmt die Abfolge der Wellen und besonderer Ereignisse während einer Welle, etwa das Auftauchen eines Mutterschiffs.
    /// </summary>
    /// <remarks>Zählt außerdem die Wellen mit.</remarks>
    public class GameCourse
    {
        /// <summary>
        /// Enthält die GameTime zum Zeitpunkt der Erstellung der letzten Welle.
        /// </summary>
        private GameTime waveStartingTime;

        /// <summary>
        /// Konstruktor
        /// </summary>
        public GameCourse()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Zählt die Wellen mit.
        /// </summary>
        public int WaveCounter
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
        /// Erzeugt eine neue Welle, d.h. eine Liste von Aliens, die durch einen Controller gesteuert werden. Die Abfolge der Wellen ist hier anhand des WaveCounters festgelegt. Die Methode setzt außerdem bei jedem Aufruf die "waveStartingTime" auf die aktuelle "gameTime".
        /// </summary>
        public List<IGameItem> NextWave(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Dient zur Erstellung besonderer Ereignisse während einer Welle, z.B. das Auftauchen eines Mutterschiffs.
        /// </summary>
        /// <remarks>Hierfür wird die "waveStartingTime" benötigt, um Ereignisse zu bestimmten Wellen timen zu können.</remarks>
        public void Update(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }
    }
}
