using System;
using System.Collections.Generic;

namespace Capsule_Charles_Marc_Antoine.Modeles
{
    public partial class Graphe
    {
        public Graphe()
        {
            Noeuds = new HashSet<Noeud>();
        }

        public int Id { get; set; }
        public string Nom { get; set; } = null!;
        public string Statut { get; set; } = null!;

        public virtual ICollection<Noeud> Noeuds { get; set; }
    }
}
