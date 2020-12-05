using ImpactaBank.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpactaBank.API.Service
{
    public class CustomerService
    {
        public BaseResponse Insert(Customer request)
        {
            if (request.Name == String.Empty || request.Name == null)
                return new BaseResponse() { StatusCode = 400, Message = "Name is empty" };

            if (request.Age == 0 || request.Name == null)
                return new BaseResponse() { StatusCode = 400, Message = "Age is empty" };

            //call repository - get
            //call get


            return new BaseResponse() { StatusCode = 201, Message = "Cystomer was created" };
        }

        public BaseResponse Get(int id)
        {
            if (id == 0)
                return new BaseResponse() { StatusCode = 400, Message = "Id is empty" };

            Customer customer = new Customer();
            customer.Id = 1;
            customer.Name = "John";
            customer.Age = 20;
            return customer;
        }

        public List<Customer> List()
        {
            List<Customer> list = new List<Customer>();

            Customer customer = new Customer();
            customer.Id = 1;
            customer.Name = "John";
            customer.Age = 20;
            list.Add(customer);

            customer = new Customer();
            customer.Id = 2;
            customer.Name = "Mariah";
            customer.Age = 23;
            list.Add(customer);

            customer = new Customer();
            customer.Id = 3;
            customer.Name = "Joseph";
            customer.Age = 40;
            list.Add(customer);

            return list;
        }
    }
}
