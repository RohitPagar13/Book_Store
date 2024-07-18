﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Entity
{
    public class AdminEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdminId { get; set; }

        [StringLength(50)]
        [Required]
        public string? FirstName { get; set; }

        [StringLength(50)]
        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? PhoneNo { get; set; }

        [Required]
        public string? Password { get; set; }

        public ICollection<BookEntity> AdminBooks { get; set; }
    }
}
