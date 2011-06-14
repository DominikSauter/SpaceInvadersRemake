using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese abstrakte Klasse ist die Oberklasse aller Menüeinträge
    /// </summary>
    public abstract class MenuControl
    {
        /// <summary>
        /// Zeigt an, ob das Menüelement derzeit aktiv ist
        /// </summary>
        public virtual bool Active
        {
            public get;
            public set;
        }

        /// <summary>
        /// Die Beschreibung des Menüelements
        /// </summary>
        public String Text
        {
            public get;
            private set;
        }

        /// <summary>
        /// Führt die mit dem Element verbundene Funktion aus.
        /// </summary>
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
            
        }
    }
}
