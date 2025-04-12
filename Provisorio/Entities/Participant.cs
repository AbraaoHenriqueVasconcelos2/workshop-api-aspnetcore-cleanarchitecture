using System;
using System.Collections.Generic;

#nullable disable

namespace Provisorio.Entities
{
    public partial class Participant
    {
        public Participant()
        {
            Feedbacks = new HashSet<Feedback>();
        }

        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
