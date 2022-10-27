using Domain;
using DomainServices.Services;
using System.ComponentModel.DataAnnotations;

namespace TGTG_Portal.ViewModels
{
    public class EmployeePacketProductsViewModel
    {
        public Employee Employee { get; set; }

        public Packet Packet { get; set; } = null!;

        public IList<Product> Products { get; set; }

        public FormatterService fs = new FormatterService();
    }
}
