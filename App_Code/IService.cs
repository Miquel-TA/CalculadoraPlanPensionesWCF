using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
[ServiceContract]
public interface IService
{

	[OperationContract]
	string Echo(int value);

	[OperationContract]
	decimal CalculateDesgravacionInversion(PersonType personType, decimal investment);

	// TODO: agregue aquí sus operaciones de servicio
}

// Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
[DataContract]
public class PersonType
{
    [DataMember]
    public bool Autonomo { get; set; }
    [DataMember]
    public bool Empleado { get; set; }
    [DataMember]
	public decimal Salary { get; set; }

    public PersonType(bool autonomo, bool empleado, decimal Salary)
    {
        this.Autonomo = autonomo;
        this.Empleado = empleado;
		this.Salary = Salary;
    }
}
