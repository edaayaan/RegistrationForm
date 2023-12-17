namespace StajProje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Members
    {
        public int id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Name is required.")]
        public string name { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Surname is required.")]
        public string surname { get; set; }

        [StringLength(50)]
        public string age { get; set; }

        [StringLength(10)]
        public string gender { get; set; }

        [Column("email")]
        [StringLength(50)]
        public string email { get; set; }

       
        [StringLength(10)]
        [Required(ErrorMessage = "Password is required.")]
        public string password { get; set; }


        [Column(TypeName = "date")]
        public DateTime date_of_birth { get; set; }
    }
}
