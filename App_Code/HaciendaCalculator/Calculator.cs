using System;
using System.Collections.Generic;

public class Calculator
{
    public decimal Calculate(PersonType personType, decimal inversion)
    {
        decimal maxInvestment = 1500;
        if (personType.Autonomo) maxInvestment += 4250;
        if (personType.Empleado) maxInvestment += 8500;


        if (inversion > maxInvestment)
        {
            return -1m;
        }

        decimal TaxPercent = GetBracket(personType.Salary);

        if (TaxPercent == 0m)
        {
            return -2m;
        }

        decimal investmentReturned = inversion * TaxPercent;
        return investmentReturned;
    }

    private decimal GetBracket(decimal salary)
    {
        List<KeyValuePair<decimal, decimal>> taxBrackets = new List<KeyValuePair<decimal, decimal>>()
            {
                new KeyValuePair<decimal, decimal>(300000m, 0.47m),
                new KeyValuePair<decimal, decimal>(60000m, 0.45m),
                new KeyValuePair<decimal, decimal>(35200m, 0.37m),
                new KeyValuePair<decimal, decimal>(20200m, 0.30m),
                new KeyValuePair<decimal, decimal>(12451m, 0.24m),
                new KeyValuePair<decimal, decimal>(0m, 0.19m)
            };
        foreach (KeyValuePair<decimal, decimal> bracket in taxBrackets)
        {
            if (salary > bracket.Key)
            {
                return bracket.Value;
            }
        }
        return 0m;
    }
}