using System;
using System.Collections.Generic;

#nullable disable

namespace FitnessClubLibrary.Models
{
    public partial class Client
    {
        public int Id { get; set; }
        public string Fio { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public int Coach { get; set; }

        public virtual Coach CoachNavigation { get; set; }
    }
}
