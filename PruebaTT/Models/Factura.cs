using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PruebaTT.Models
{
    public class Factura
    {
        public int Id { get; set; }
        [Display(Name = "Número de Documento")]
        [Required]
        public int Code { get; set; }
        [Display(Name = "Nombre")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "NIT")]
        [Required]
        public string NIT { get; set; }
        [Display(Name = "Descripción")]
        [Required]
        public string Desc { get; set; }
        [Display(Name = "Cantidad")]
        [Required]
        public int Qty { get; set; }
        [Display(Name = "Precio Unitario")]
        [Required]
        public decimal Price { get; set; }
        [Display(Name = "Total")]
        public decimal Total { get; set; }
        [Display(Name = "Fecha")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yyyy}")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
    }
}