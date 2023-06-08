using System;
using System.Collections.Generic;

public class Calculator
{
    public decimal Calculate(bool autonomo, bool empleado, decimal salary, decimal inversion)
    {
        decimal maxInvestment = 1500;
        if (autonomo) maxInvestment += 4250;
        if (empleado) maxInvestment += 8500;

        decimal TaxPercent = GetBracket(salary);

        if (inversion > maxInvestment)
        {
            return -1m;
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
        throw new Exception("Salario incorrecto.");
    }
}