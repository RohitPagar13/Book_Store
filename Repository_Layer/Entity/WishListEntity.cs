using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Repository_Layer.Entity
{
    public class WishListEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WishListId { get; set; }

        [Required]
        [ForeignKey("BookEntity")]
        public int BookId {  get; set; }

        [Required]
        [ForeignKey("UserEntity")]
        public int UserId {  get; set; }

        public bool IsInStock { get; set; }

    }
}
