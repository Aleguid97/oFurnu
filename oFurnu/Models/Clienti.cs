namespace oFurnu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Clienti")]
    public partial class Clienti
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clienti()
        {
            Ordini = new HashSet<Ordini>();
        }

        [Key]
        public int ID_Cliente { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        public string Cognome { get; set; }

        [Required]
        public string Indirizzo { get; set; }

        [Required]
        [StringLength(50)]
        public string Citta { get; set; }

        [Required]
        [StringLength(5)]
        public string CAP { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(10)]
        public string Ruolo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ordini> Ordini { get; set; }
    }
}
