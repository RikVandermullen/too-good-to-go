using Domain;
using DomainServices;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TGTG_Portal.Extensions
{
    public class SelectListCreator
    {
        public SelectListCreator()
        {

        }

        public SelectList MealTypeSelectList(Canteen canteen)
        {
            List<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem {Selected = false, Text = "Dranken", Value = "DRANKEN"},
                new SelectListItem {Selected = false, Text = "Brood", Value = "BROOD"},
                new SelectListItem {Selected = false, Text = "Gezond", Value = "GEZOND"},
            };
            if (canteen.WarmMeals)
            {
                list.Add(new SelectListItem { Selected = false, Text = "Warm", Value = "WARM" });
            }

            return new SelectList(list, "Value", "Text");
        }

        public SelectList CitySelectList(City city)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (city == City.BREDA)
            {
                list.Add(new SelectListItem { Selected = false, Text = "Breda", Value = "BREDA" });
            }
            else if (city == City.TILBURG)
            {
                list.Add(new SelectListItem { Selected = false, Text = "Tilburg", Value = "TILBURG" });
            }
            else
            {
                list.Add(new SelectListItem { Selected = false, Text = "Den Bosch", Value = "DENBOSCH" });
            }
            return new SelectList(list, "Value", "Text");
        }

        public SelectList AllCitySelectList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem { Selected = false, Text = "Breda", Value = "BREDA" });
            list.Add(new SelectListItem { Selected = false, Text = "Tilburg", Value = "TILBURG" });
            list.Add(new SelectListItem { Selected = false, Text = "Den Bosch", Value = "DENBOSCH" });

            return new SelectList(list, "Value", "Text");
        }

        public SelectList LocationSelectList(List<Canteen> list, City city)
        {
            return new SelectList(list, "Id", "Location");
        }

        public SelectList AllLocationSelectList(List<Canteen> list)
        {
            return new SelectList(list, "Id", "Location");
        }
    }
}
