namespace oFurnu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Amministrazione")]
    public partial class Amministrazione
    {
        [Key]
        public int ID_Admin { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [StringLength(10)]
        public string Ruolo { get; set; }
    }
}
