using System;
using System.Collections.Generic;

public class Budget
{
    public int Id { get; set; }
    public string Description { get; set; }
    public double TotalAmount { get; set; }
    public int Customer { get; set; }

    public Budget(int id, double totalAmount, string description, int customer)
    {
        Id = id;
        TotalAmount = totalAmount;
        Description = description;
        Customer = customer;
    }
}