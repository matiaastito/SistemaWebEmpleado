using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SistemaWebEmpleado.Validaciones
{
    public class CheckValidLegajo : ValidationAttribute
    {
        public CheckValidLegajo() 
        {
            ErrorMessage = "El Legajo debe comenzar con AA y seguir con 5 numeros, Ejemplo: 12345";
        }

        public override bool IsValid(object value)
        {
            string check = value as string;
            
            if (check.Length > 7)
            {
                return false;
            }
            else
            {
                if (check[0] == 'A' && check[1] == 'A')
                {
                    string resultString = Regex.Match(check, @"\d+").Value;
                    if(resultString.Length == 5)
                    {
                        return true;
                    }
                }

                    return false;
            }

        }
    }
}
