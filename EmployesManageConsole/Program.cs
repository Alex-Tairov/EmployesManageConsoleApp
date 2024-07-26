using EmployesManageCommon;
using System.Globalization;

public partial class Program
{
   
    static void Main(string[] args)
    {
        EmployesRepository.CreateFileEmployesIfNotExists();
       
       
        var operation = args[0];
        switch (operation)
        {
            case "-add":
                var firstName = args[1].Split(':')[1];
                var lastName = args[2].Split(':')[1];
                var salaryPerHour = decimal.Parse(args[3].Split(':')[1].TrimEnd('.'),
                    CultureInfo.InvariantCulture);
                EmployesRepository.AddEmployee(firstName, lastName, salaryPerHour);
                break;
            case "-update":
                var updatedId = Convert.ToInt32(args[1].Split(':')[1]);
                var parametr = args[2].Split(':')[0];
                var updatedValue = args[2].Split(':')[1];
                EmployesRepository.UpdateEmployee(updatedId, parametr, updatedValue);
                break;
            case "-get":
                var Id = Convert.ToInt32(args[1].Split(':')[1]);
                EmployesRepository.GetEmployeeById(Id);
                break;
            case "-delete":
                var deletedId = Convert.ToInt32(args[1].Split(':')[1]);
                EmployesRepository.DeleteEmployeeById(deletedId);
                break;
            case "-getall":
                EmployesRepository.GetAllEmployes();
                break;
            default:
                Console.WriteLine("Некорректный ввод");
                break;
        }
    }
}


