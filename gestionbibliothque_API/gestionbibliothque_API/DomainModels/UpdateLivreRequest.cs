

using System;

namespace gestionbibliothque_API.DomainModels
{
    public class UpdateLivreRequest
    {
            public Guid CodeLivre { get; set; }
            public string Titre { get; set; }
            public string Langue { get; set; }
            public string maisonEdition { get; set; }
            public string imageLivreURL { get; set; }
            public int Nbpage { get; set; }
            public int prixAchat { get; set; }
            public int AnneEdition { get; set; }
            public Guid idTypeLivre { get; set; }
            public Guid AuteursId { get; set; }

    }
    }

