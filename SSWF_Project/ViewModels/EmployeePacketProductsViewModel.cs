using Domain;
using System.ComponentModel.DataAnnotations;

namespace TGTG_Portal.ViewModels
{
    public class EmployeePacketProductsViewModel
    {
        public Employee Employee { get; set; }

        public Packet Packet { get; set; } = null!;

        public IList<Product> Products { get; set; }
    }
}
