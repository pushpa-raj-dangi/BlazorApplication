using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages
{
    public class DataBindingDemoBase: ComponentBase
    {
        public string Name { get; set; } = "Pushpa";
        public string Gender { get; set; } = "Male";
        public string Background { get; set; } = "red";
        public string Description { get; set; } = string.Empty;
        public int Count { get; set; } 
    }
}
