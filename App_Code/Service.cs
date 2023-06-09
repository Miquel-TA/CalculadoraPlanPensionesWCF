using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class Service : IService
{
	public string Echo(int value)
	{
		return string.Format("You entered: {0}", value);
	}

    public decimal CalculateDesgravacionInversion(PersonType personType, decimal inversion)
    {
        try
        {
            Calculator calculator = new Calculator();
            return calculator.Calculate(personType, inversion);
        } catch (Exception ex)
		{
            Console.WriteLine(ex.ToString());
            // Logger would be here
            return -3;
		}
    }
}
