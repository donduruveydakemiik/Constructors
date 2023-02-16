using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Constructors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Constructors 1.örnek
            //CustomerManager customerManager = new CustomerManager(10);
            //customerManager.List();
            #endregion

            #region Constructors 2.örnek
            //Product product = new Product("Rüveyda",1); //metodu kullandık.

            #endregion

            #region Constructors Injection

            //EmployeeManager employeeManager = new EmployeeManager(new DataBaseLogger());//nereye log işlemi yapılsın diye sorar
            //employeeManager.Add();
            #endregion

            #region Constructors 4.örnek
            PersonalManager personalManager=new PersonalManager("Product");
            personalManager.Add();


            #endregion


            Console.ReadLine();
        }
    }

    class CustomerManager
    {
        private int _count; //field _ ile isimlendirilir.
        public CustomerManager(int count) 
        { 
            _count=count;
        }
        public void List()
        {
            Console.WriteLine("Listed. İtems {0}",_count);

        }

        public void Add() 
        {
            Console.WriteLine("Added.");
        }
    } //1.örnek class

    class Product
    {
        private string _name;
        private int _id;
        public Product()
        {

        }

        public Product(string name, int id)
        {
            _name = name;
            _id = id;

            Console.WriteLine("{0} - {1}",_id, _name);
        }
        // public int Id { get; set; } //property


    } //2. örnek class

    interface ILogger
    {
        void Log();
    } //3.örnek

    class DataBaseLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine(" Logged to Database");
        }
    }  //3.örnek

    class FileLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine(" Logged to File");
        }
    } //3.örnek

    class EmployeeManager // 3.örnek Çalışanla ilgili iş sınıfı
    {
        private ILogger _logger;
        public EmployeeManager(ILogger logger) //cnst metod.
        {
            _logger = logger;
        }
        public void Add()
        {
            _logger.Log();
            Console.WriteLine("Added to Employee");
        }
    }

    class BaseClass
    {
        private string _entity;
        public BaseClass(string entity)
        {
            _entity = entity;

        }

        public void Message()
        {
            Console.WriteLine("{0} message ",_entity);
        }
    }
    class PersonalManager : BaseClass
    {
        public PersonalManager(string entity):base(entity)
        {

        }

        public void Add()
        {
            Console.WriteLine("Added.");
            Message();
        }
    }
}
