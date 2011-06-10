using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.ModelSection
{
    public class HighscoreManager : SpaceInvadersRemake.StateMachine.IModel
    {
        private System.Collections.Generic.List<HighscoreEntry> highscore;

        public HighscoreManager(int score)
        {
            throw new System.NotImplementedException();
        }

        public HighscoreManager()
        {
            throw new System.NotImplementedException();
        }
        
        public SpaceInvadersRemake.ModelSection.HighscoreEntry[] HighscoreEntries
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public HighscoreEntry NewEntry
        {
            get
            {
                throw new System.NotImplementedException();
            }            
        }

        public bool Save()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Microsoft.Xna.Framework.Game game, Microsoft.Xna.Framework.GameTime gameTime, StateMachine.State state)
        {
            throw new NotImplementedException();
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
