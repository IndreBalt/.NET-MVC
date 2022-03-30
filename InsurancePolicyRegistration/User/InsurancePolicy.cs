using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace User
{
    public class InsurancePolicy
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Pavadinimas/Poliso nr")]
        [Required]
        public string PolicyTitle { get; set; }

        [DisplayName("Draudimo rūšis")]
        [Required]
        public string InsuranceType { get; set; }

        [DisplayName("Pradžios data")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DisplayName("Pabaigos data")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
  
}
