using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.UI.Services
{
    public class ManagerApprovalService : IExpenseApprovalService
    {
        private readonly IEmployeeDataService _employeeDataService;

        public ManagerApprovalService(IEmployeeDataService employeeDataService)
        {
            _employeeDataService = employeeDataService;
        }
        public async Task<ExpenseStatus> GetExpenseStatus(Expense expense)
        {
            var employee = await _employeeDataService.GetEmployeeDetails(expense.EmployeeId);

            if (employee.IsFTE)
            {
                if (expense.Amount < 250)
                {
                    switch (expense.ExpenseType)
                    {
                        case ExpenseType.Training:
                            return ExpenseStatus.Approved;
                        case ExpenseType.Food:
                            return ExpenseStatus.Approved;
                        case ExpenseType.Office:
                            return ExpenseStatus.Approved;
                    }
                }

                if (employee.JobCategory.JobCategoryName == "Sales" && expense.Amount < 250)
                {
                    switch (expense.ExpenseType)
                    {
                        case ExpenseType.Transportation:
                            return ExpenseStatus.Approved;
                        case ExpenseType.Travel:
                            return ExpenseStatus.Approved;
                        case ExpenseType.Hotel:
                            return ExpenseStatus.Approved;
                    }
                }
            }

            if (employee.IsOPEX)
            {
                switch (expense.ExpenseType)
                {
                    case ExpenseType.Conference:
                        return ExpenseStatus.Denied;
                    case ExpenseType.Transportation:
                        return ExpenseStatus.Denied;
                    case ExpenseType.Hotel:
                        return ExpenseStatus.Denied;
                }

                if (expense.Status != ExpenseStatus.Denied)
                {
                    expense.CoveredAmount = expense.Amount / 2;
                }
            }

            if (!employee.IsFTE)
            {
                if (expense.ExpenseType != ExpenseType.Training)
                {
                    return ExpenseStatus.Denied;
                }
            }

            if (expense.ExpenseType == ExpenseType.Food && expense.Amount > 100)
            {
                return ExpenseStatus.Pending;
            }

            if (expense.Amount > 5000)
            {
                return ExpenseStatus.Pending;
            }

            return ExpenseStatus.Pending;
        }
    }
}
