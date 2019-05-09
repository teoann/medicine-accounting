using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicineAccountingAPI.DataLevel
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        [Range(0.01, 999999999.99, ErrorMessage = "Price must look like 0.00 and less than 999999999.99")]
        //[Column(TypeName ="decimal(9,2)")]
        public double Price { get; set; }
    }
}
