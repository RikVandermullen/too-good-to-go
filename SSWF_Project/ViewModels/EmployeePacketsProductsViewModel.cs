using Domain;

namespace TGTG_Portal.ViewModels
{
    public class EmployeePacketsProductsViewModel
    {
        public Employee Employee { get; set; }

        public IEnumerable<Packet> Packets { get; set; } = Enumerable.Empty<Packet>();

        public IEnumerable<Product> Products { get; set; } = Enumerable.Empty<Product>();
    }
}
