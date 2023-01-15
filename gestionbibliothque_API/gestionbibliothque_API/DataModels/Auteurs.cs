using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestionbibliothque_API.DataModels
{
    public class Auteurs
    {
        public Guid id_auteur { get; set; }
        public Guid nom { get; set; }



        //navigation property 
        public Guid codeLivre { get; set; }
    }
}
