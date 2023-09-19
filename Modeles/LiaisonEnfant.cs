using System;
using System.Collections.Generic;

namespace Capsule_Charles_Marc_Antoine.Modeles
{
    public partial class LiaisonEnfant
    {
        public int NoeudParent { get; set; }
        public int NoeudEnfant { get; set; }

        public virtual Noeud NoeudEnfantNavigation { get; set; } = null!;
        public virtual Noeud NoeudParentNavigation { get; set; } = null!;
    }
}
