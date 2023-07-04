using HRAdministrationAPI;
using System;
using System.Collections.Generic;

namespace SchoolHRAdministration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static void SeedData(List<IEmployee> employees)        //IEmployee sınıfını argüman olarak kullanan bir liste SeedData metoduna argüman oldu. Metodun argüman olarak List<IEmployee> kullanmasının sebebi, daha genel bir arayüz olan IEmployee'ı temel alarak herhangi bir sınıfın bu metoda argüman olarak geçilebilmesini sağlamaktır. IEmployee arayüzü, EmployeeBase sınıfı tarafından uygulanmış olduğu için, EmployeeBase sınıfının bir örneği de IEmployee türüne atanabilir. Böylece, SeedData metodunun daha genel bir tipe bağımlı olması sağlanır ve farklı sınıfların uyumlu bir şekilde kullanılabilmesi mümkün hale gelir. Bu da kodun daha esnek ve genişletilebilir olmasını sağlar.
        {
            IEmployee teacher1 = new Teacher    //new Teacher olmasına dikkat edilmelidir.
            {
                Id = 1,
                FirstName = "Bob",
                LastName = "Fisher",
                Salary = 40000
            };

            IEmployee teacher2 = new Teacher
            {
                Id = 2,
                FirstName = "Susan",
                LastName = "Thomas",
                Salary = 42000
            };

            IEmployee headOfDepartment = new HeadOfDepartment
            {
                Id = 3,
                FirstName = "Brenda",
                LastName = "Mullins",
                Salary = 50000
            };

            IEmployee deputyHeadMaster = new DeputyHeadMaster 
            {
                Id = 4,
                FirstName = "Delvin",
                LastName = "Brown",
                Salary = 60000
            };

            IEmployee headMaster = new HeadMaster
            {
                Id = 5,
                FirstName = "Damien",
                LastName = "Jones",
                Salary = 80000
            };

            employees.Add(teacher1);
            employees.Add(teacher2);
            employees.Add(headOfDepartment);
            employees.Add(deputyHeadMaster);
            employees.Add(headMaster);
        }

    }
}

public class Teacher : EmployeeBase
{

}

public class HeadOfDepartment : EmployeeBase
{

}

public class DeputyHeadMaster : EmployeeBase
{

}

public class HeadMaster : EmployeeBase
{

}




/* 
* HRAdministrationAPI class library'si SchoolHRAdministration'a sağ tıklanarak refere edildi.
* Teacher gibi sınıflar tanımlandı.
* Diğer çalışan sınıfları eklendi.
* Yıllık maaş tanımlamamız gerektiği belirlendi.
* SeedData metodu tanımlandı. Böylelikle yıllık maaş verisi oluşturuldu.
* 
* 
* +++++++++++++++++++++++++++
* 
* 
*/