using System;
using System.Collections.Generic;

namespace Capsule_Charles_Marc_Antoine.Modeles
{
    public partial class Noeud
    {
        public Noeud()
        {
            InverseLiaisonParentNavigation = new HashSet<Noeud>();
        }

        public int Id { get; set; }
        public string Nom { get; set; } = null!;
        public int GraphId { get; set; }
        public int? LiaisonParent { get; set; }
        public int Posx { get; set; }
        public int Posy { get; set; }
        public int Rayon { get; set; }
        public string Couleur { get; set; } = null!;

        public virtual Graphe Graph { get; set; } = null!;
        public virtual Noeud? LiaisonParentNavigation { get; set; }
        public virtual ICollection<Noeud> InverseLiaisonParentNavigation { get; set; }
    }
}
