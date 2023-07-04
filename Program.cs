using HRAdministrationAPI;
using SchoolHRAdministration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolHRAdministration
{
    public enum EmployeeType
    {
        Teacher,
        HeadOfDepartment,
        DeputyHeadMaster,
        HeadMaster
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal totalSalaries = 0;
            List<IEmployee> employees = new List<IEmployee>();

            SeedData(employees);

            /* #Uzun yoldan toplam maaşı görüntüleme#
             * 
             * foreach (IEmployee employee in employees)
            //{
            //    totalSalaries += employee.Salary;
            //}

            //Console.WriteLine($"Total Annual Salaries (including bonus): {totalSalaries}");
            */

            totalSalaries = employees.Sum(employee => employee.Salary); // nerede.neİslemYapilacak(kim => neyi)
            Console.WriteLine($"Total Annual Salaries (including bonus): {totalSalaries}");
            //Lambda ifadesi (Lambda expression), C# programlama dilinde anonim fonksiyonları ifade etmek için kullanılan bir yapıdır. Bir lambda ifadesi, bir veya daha fazla parametre alabilir, işlem yapabilir ve bir değer döndürebilir. Lambda ifadeleri genellikle LINQ sorguları veya fonksiyonel programlama yaklaşımları gibi durumlarda kullanılır. İşlevsel bir yaklaşımın bir parçası olarak, lambda ifadeleri fonksiyonları veri olarak ele almamızı ve kodumuzda işlevleri daha esnek ve kompakt bir şekilde kullanmamızı sağlar.

            Console.ReadKey();


        }

        public static void SeedData(List<IEmployee> employees)        //IEmployee sınıfını argüman olarak kullanan bir liste SeedData metoduna argüman oldu. Metodun argüman olarak List<IEmployee> kullanmasının sebebi, daha genel bir arayüz olan IEmployee'ı temel alarak herhangi bir sınıfın bu metoda argüman olarak geçilebilmesini sağlamaktır. IEmployee arayüzü, EmployeeBase sınıfı tarafından uygulanmış olduğu için, EmployeeBase sınıfının bir örneği de IEmployee türüne atanabilir. Böylece, SeedData metodunun daha genel bir tipe bağımlı olması sağlanır ve farklı sınıfların uyumlu bir şekilde kullanılabilmesi mümkün hale gelir. Bu da kodun daha esnek ve genişletilebilir olmasını sağlar.
        {
            /*
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
            */


            IEmployee teacher1 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 1, "Bob", "Fisher", 40000);
            employees.Add(teacher1);

            IEmployee teacher2 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 2, "Jenny", "Thomas", 40000);
            employees.Add(teacher2);

            IEmployee headOfDepartment = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadOfDepartment, 3, "Brenda", "Mullins", 50000);
            employees.Add(headOfDepartment);

            IEmployee deputyHeadMaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.DeputyHeadMaster, 4, "Delvin","Brown", 60000);
            employees.Add(deputyHeadMaster);

            IEmployee headMaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadMaster, 5, "Damien", "Jones", 80000);
            employees.Add(headMaster);
        }

    }
}

public class Teacher : EmployeeBase
{
    public override decimal Salary { get => base.Salary + (base.Salary * 0.02m); } //Salary özelliğini geçersiz kılar ve get bloğunda temel sınıftaki Salary özelliğine erişerek buna %2'lik bir bonus ekler. Yani, özelliğe erişildiğinde temel sınıftaki değeri alır ve üzerine %2'lik bir artış yaparak döndürür.
}

public class HeadOfDepartment : EmployeeBase
{
    public override decimal Salary { get => base.Salary + (base.Salary * 0.03m); }
}

public class DeputyHeadMaster : EmployeeBase
{
    public override decimal Salary { get => base.Salary + (base.Salary * 0.04m); }
}

public class HeadMaster : EmployeeBase
{
    public override decimal Salary { get => base.Salary + (base.Salary * 0.05m); }
}

public static class EmployeeFactory
{
    public static IEmployee GetEmployeeInstance(EmployeeType employeeType, int id, string firstName, string lastName, decimal salary)
    {
        IEmployee employee = null;

        switch (employeeType)
        {
            case EmployeeType.Teacher:
                employee = FactoryPattern<IEmployee, Teacher>.GetInstance();
                break;
            case EmployeeType.HeadOfDepartment:
                employee = FactoryPattern<IEmployee, HeadOfDepartment>.GetInstance();
                break;
            case EmployeeType.DeputyHeadMaster:
                employee = FactoryPattern<IEmployee, DeputyHeadMaster>.GetInstance();
                break;
            case EmployeeType.HeadMaster:
                employee = FactoryPattern<IEmployee, HeadMaster>.GetInstance();
                break;
            default:
                break;
        }

        if (employee != null)
        {
            employee.Id = id;
            employee.FirstName = firstName;
            employee.LastName = lastName;
            employee.Salary = salary;
        }
        else
        {
            throw new NullReferenceException();
        }

        return employee;
    }
}




/* 
* HRAdministrationAPI class library'si SchoolHRAdministration'a sağ tıklanarak refere edildi.
* Teacher gibi sınıflar tanımlandı.
* Diğer çalışan sınıfları eklendi.
* Yıllık maaş tanımlamamız gerektiği belirlendi.
* SeedData metodu tanımlandı. Böylelikle yıllık maaş verisi oluşturuldu. SeedData verileri eklendi ve metod içerisinde argüman olarak gelen listeye eklenmesi sağlandı.
* Main metodda bir liste ve değişken oluşturuldu. Liste kayıtların türünden oldu.
* Kayıtlar SeedData metodu ile gerçek listeye eklendi.
* Foreach metodu ile tüm kayıtların toplanması ve değişkene eklenmesi sağlandı.
* Uzun yol olan bu yöntem yorum satırına alındı.
* Kısa yöntem olan LINQ sorgusu için using satırı eklendi.
* Lambda expression yazıldı.
* EmployeeType enumı tanımlandı.
* EmployeeFactory sınıfı oluşturuldu.
* GetEmployeeInstance metodu oluşturuldu ve içeriği argümanları ile birlikte dolduruldu.
* SeedData metodunun içerisi yeni eklenen GetEmployeeInstance metoduna göre yeniden düzenlendi.
* FactoryPattern sınıfı oluşturulup buraya geri gelinmiştir ve SeedData metodu yeniden düzenlenmiştir.
* 
* +++++++++++++++++++++++++++
* 
* FactoryPattern adında bir genel (generic) statik sınıf tanımlanmıştır. Bu sınıf, belirli bir türden nesnelerin oluşturulması için bir yöntem sağlamaktadır. Bu sınıfın içi özelleştirilmiştir.
*/