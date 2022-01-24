using System;
using System.Collections.Generic;

#nullable disable

namespace FitnessClubLibrary.Models
{
    public partial class Coach
    {
        public Coach()
        {
            Clients = new HashSet<Client>();
        }

        public int Id { get; set; }
        public string Fio { get; set; }
        public string Phone { get; set; }
        public string WorkLevel { get; set; }
        public string Rank { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
