

namespace NLayer.Core.DTOs
{
    public class ProductFeatureDTO:BaseDTO
    {
        public int Id { get; set; }
        public string Color { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public int Width { get; set; }
        public int ProductId { get; set; }
    }
}
