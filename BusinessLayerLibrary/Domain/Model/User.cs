namespace BusinessLayerLibrary.Domain.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public User()
        {
            Offers = new HashSet<Offer>();
        }

        [Key]
        public int IdUser { get; set; }

        [Required]
        [StringLength(50)]
        public string Login { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(64)]
        public byte[] PasswordHash { get; set; }

        public virtual ICollection<Offer> Offers { get; set; }
    }
}
