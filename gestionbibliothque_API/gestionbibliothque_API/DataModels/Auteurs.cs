using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestionbibliothque_API.DataModels
{
    public class Auteurs
    {  
        public Guid Id { get; set; }
        public string Nom { get; set; }



        //navigation property 
        public Guid CodeLivre { get; set; }
    }
}
