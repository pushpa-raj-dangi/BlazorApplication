using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeDetailsBase:ComponentBase
    {
        public Employee Employee { get; set; } = new Employee();
        public string BtnText { get; set; } = "Hide Button";


        protected string Coordinates { get; set; }
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        [Parameter]
        public string Id { get; set; }
        public string CssText { get; set; } = null;

        protected override async Task OnInitializedAsync()
        {
            Id = Id ?? "1";
            Employee = await EmployeeService.GetEmployee(int.Parse(Id));

        }

        protected void ShowHideBtn(MouseEventArgs e)
        {
            if(BtnText == "Hide Button")
            {
                CssText = "HideFooter";
                BtnText = "Show Button";
            }
            else
            {
                CssText = null;
                BtnText = "Hide Button";
            }

        }

    }
}
