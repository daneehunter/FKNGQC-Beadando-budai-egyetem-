using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKNGQC_Beadandó
{
    /// <summary>
    /// Egy személy adatait tartalmazza
    /// </summary>
    /// <remarks>
    /// Ez egy adat modell osztály, adattárolásra getter setterrel.
    /// </remarks>
    public class Szamlatulajdonos
    {
        /// <summary>
        /// A Számla tulajdonosának nevére tárolására használt változó
        /// </summary>
        public string Neve { get; set; }

        /// <summary>
        /// A számla egyenlege tárolására használt változónk
        /// </summary>
        public int Egyenlege { get; set; }

    }
}
