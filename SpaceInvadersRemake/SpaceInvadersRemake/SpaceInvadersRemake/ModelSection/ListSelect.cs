using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.ModelSection
{
    public class ListSelect<T> : MenuControl
    {
        private Action<T> action;
        private List<T> list;
    
        public ListSelect(List<T> list, Action<T> action)
        {
            throw new System.NotImplementedException();
        }

        public T SelectedItem
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    
        public override void Action()
        {
            throw new NotImplementedException();
        }

        public override void Prev()
        {
            throw new NotImplementedException();
        }

        public override void Next()
        {
            throw new NotImplementedException();
        }
    }
}
