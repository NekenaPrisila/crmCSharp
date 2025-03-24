using System;
using System.Collections.Generic;

namespace CRMSharp.Models;

public partial class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Country { get; set; }
    public string Address { get; set; }

    public List<Budget> BudgetList { get; set; }

    public double Budget => BudgetList.Sum(budget => budget.TotalAmount);

    public List<Expense> ExpenseList { get; set; }

    public double Expense => ExpenseList.Sum(expense => expense.Amount);

}
