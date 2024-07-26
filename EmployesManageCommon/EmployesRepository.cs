using Newtonsoft.Json;
using System.Globalization;

namespace EmployesManageCommon
{
    public class EmployesRepository
    {
        private static string employesPath = " employes.json";

        private static int maxId;
        public static void AddEmployee(string FirstName, string LastName, decimal SalaryPerHour)
        {
            if (GetEmployesFromFile().Count == 0)
                maxId = 0;
            else
                maxId = GetEmployesFromFile().Max(x => x.Id);
            var newEmployee = new Employee(maxId + 1, FirstName, LastName, SalaryPerHour);
            var employes = GetEmployesFromFile();
            employes.Add(newEmployee);
            SaveEmployesToFile(employes);
        }
        public static void UpdateEmployee(int Id, string updatedParametr, string argument)
        {
            
            var employes = GetEmployesFromFile();
            var updatedEmployee = employes.FirstOrDefault(x => x.Id == Id);
            if(updatedEmployee == null)
            {
                Console.WriteLine("Сотрудника с данным Id не существует");
            }
            else
            {
                switch (updatedParametr)
                {
                    case "FirstName":
                        updatedEmployee.FirstName = argument;
                        break;
                    case "LastName":
                        updatedEmployee.LastName = argument;
                        break;
                    default:
                        updatedEmployee.SalaryPerHour = decimal.Parse(argument.TrimEnd('.'), CultureInfo.InvariantCulture);
                        break;
                }
                SaveEmployesToFile(employes);
            }
        }

        public static void GetEmployeeById(int Id)
        {
            var employes = GetEmployesFromFile();
            var employee = employes.FirstOrDefault(x => x.Id == Id);
          
            if (employee == null)
            {
                Console.WriteLine("Сотрудника с данным Id не существует");
            }
            else
            {
                Console.WriteLine($"Id = {employee.Id}, " +
                $"FirstName = {employee.FirstName}, " +
                $"LastName = {employee.LastName}, " +
                $"SalaryPerHour = {employee.SalaryPerHour}");
            }    
        }
        public static void DeleteEmployeeById(int Id)
        {
            var employes = GetEmployesFromFile();
            var employee = employes.FirstOrDefault(x => x.Id == Id);

            if (employee == null)
            {
                Console.WriteLine("Сотрудника с данным Id не существует");
            }
            else
            {
                employes.RemoveAll(x => x.Id == Id);
                SaveEmployesToFile(employes);
            }
            
        }
        public static void GetAllEmployes()
        {
            var employes = GetEmployesFromFile();
            foreach (var employee in employes)
            {
                Console.WriteLine($"" +
                    $"Id = {employee.Id}, " +
                    $"FirstName = {employee.FirstName}, " +
                    $"LastName = {employee.LastName}, " +
                    $"SalaryPerHour = {employee.SalaryPerHour}");
            }
        }

        //Считываем список вопросов из файла и дессиреализуем его
        public static List<Employee> GetEmployesFromFile()
        {
            //Считываем содержимое файла
            var serializedEmployes = FileProvider.Get(employesPath);
            //Диссериализация(возвращает указанный тип данных)
            var employes = JsonConvert.DeserializeObject<List<Employee>>(serializedEmployes);
            return employes;
        }

        //Серриализуем вопросы
        private static void SaveEmployesToFile(List<Employee> employes)
        {
            var serializedEmployes = JsonConvert.SerializeObject(employes, Newtonsoft.Json.Formatting.Indented);
            FileProvider.Set(employesPath, serializedEmployes);
        }

        public static void CreateFileEmployesIfNotExists()
        {
            if (!FileProvider.IsExists(employesPath))
            {
                var value = JsonConvert.SerializeObject(new List<Employee>(), Newtonsoft.Json.Formatting.Indented);
                FileProvider.Add(employesPath, value);
            }
        }
    }
}
