using EmployesManageCommon;

namespace TestEmployesManage
{
    public class Tests
    {
        [Test]
        public void TestAddEmployee()
        {
            EmployesRepository.CreateFileEmployesIfNotExists();
                       
            EmployesRepository.AddEmployee("Alex", "German", 10.5M);

            var employee=EmployesRepository.GetEmployesFromFile().FirstOrDefault(x=>x.Id==1);

            Assert.AreEqual(1, employee.Id);
            Assert.AreEqual("Alex", employee.FirstName);
            Assert.AreEqual("German", employee.LastName);
            Assert.AreEqual(10.5M,employee.SalaryPerHour);





        }
    }
}