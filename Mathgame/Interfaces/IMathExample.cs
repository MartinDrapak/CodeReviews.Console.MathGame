using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathgame.Interfaces
{
    interface IMathExample
    {
        #region properties
        string Example { get; set; }
        char Operator {get; set;}
        int Result { get; set; }
        #endregion
        #region methods
        public void Show();
        public void Generate();
        #endregion
    }
}
