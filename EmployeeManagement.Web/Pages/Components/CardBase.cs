using EmployeeManagement.Components;
using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages.Components
{
    public class CardBase : ComponentBase
    {
        [Parameter]
        public Employee Employee { get; set; }

        [Parameter]
        public bool ShowFooter { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IEmployeeService  EmployeeService { get; set; }
        [Parameter]
        public EventCallback<bool> OnEmployeeSelection { get; set; }

        [Parameter]
        public EventCallback<int> OnEmployeeDeletion { get; set; }

        protected ConfirmBase DeleteConfrimation { get; set; }





        protected async Task CheckBoxChanged(ChangeEventArgs e)
        {
          await OnEmployeeSelection.InvokeAsync((bool)e.Value);
        }

        protected ConfirmBase DeleteConfirmation { get; set; }

        protected void Delete_Click()
        {
            DeleteConfirmation.Show();
        }

        protected async Task ConfirmDelete_Click(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await EmployeeService.DeleteEmployee(Employee.EmployeeId);
                await OnEmployeeDeletion.InvokeAsync(Employee.EmployeeId);
            }
        }

    }
}
