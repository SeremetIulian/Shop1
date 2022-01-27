using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Premium.Data.Models
{
    public class Order
    {
        [BindNever]

        public int id { set; get; }

        [Display(Name = "Introduceti prenumele")]
        [StringLength (20)]
        [Required(ErrorMessage = "Prenumele nu trebue sa depaseasca 20 de simboluri")]
        public string name { set; get; }
        [Display(Name = "Numele")]
        [StringLength(20)]
        [Required(ErrorMessage = "Numele nu trebue sa depaseasca 20 de simboluri")]

        public string surname { set; get; }
        [Display(Name = "adressa")]
        [StringLength(20)]
        [Required(ErrorMessage = "adresa nu trebue sa depaseasca 20 de simboluri")]

        public string adres { set; get; }
        [Display(Name = "Telefonul")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(20)]
        [Required(ErrorMessage = "Telefonul nu trebue sa depaseasca 20 de simboluri")]
        public string phone { set; get; }
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(35)]
        [Required(ErrorMessage = "Numele nu trebue sa depaseasca 35 de simboluri")]
        public string email { set; get; }
        
        
        [BindNever]
        [ScaffoldColumn(false)]
        public  DateTime orderTime { set; get; }

        public List<OrderDetail> orderDetails { get; set; }
    }
}
