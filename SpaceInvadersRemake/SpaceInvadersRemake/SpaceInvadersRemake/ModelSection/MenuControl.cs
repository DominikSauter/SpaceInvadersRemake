using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.ModelSection
{
    public abstract class MenuControl
    {
        public bool Active
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public String Text
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public abstract void Action();

        // DESIGN: In der Oberklasse deklariert um dem Controller Arbeit abzunehmen und eine bessere
        //         Kapselung und Erweiterbarkeit zu ermöglichen. Dadurch muss der MenuController nicht 
        //         mehr verändert werden.
        /// <summary>
        /// Wählt den vorigen Eintrag des Controls aus, wenn dies möglich ist.
        /// 
        /// </summary>
        public virtual void Prev()
        {
            throw new System.NotImplementedException();
        }

        // DESIGN: In der Oberklasse deklariert um dem Controller Arbeit abzunehmen und eine bessere
        //         Kapselung und Erweiterbarkeit zu ermöglichen. Dadurch muss der MenuController nicht 
        //         mehr verändert werden.
        /// <summary>
        /// Wählt den nächten Eintrag des Controls aus, wenn dies möglich ist.
        /// 
        /// </summary>
        public virtual void Next()
        {
            
            throw new System.NotImplementedException();
        }
    }
}
