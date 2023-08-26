using System.ComponentModel.DataAnnotations;

namespace CPW219_eCommerceSite.Models
{
    /// <summary>
    /// Represents a single paint product for purchase
    /// </summary>
    public class Paint
    {
        /// <summary>
        /// The unique identifier for each paint product
        /// </summary>
        [Key]
        public int PaintID { get; set; }

        /// <summary>
        /// The official title of the paint product
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// The sales price of the paint product
        /// </summary>
        [Range(0, 1500)]
        public double Price { get; set; }

        // TODO: Add General Colors
    }
}
