using ImpactaBank.API.Model;
using ImpactaBank.API.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpactaBank.API.Service
{
    public class CustomerService
    {
        CustomerRepository _repository = new CustomerRepository();

        public BaseResponse Insert(Customer request)
        {
            if (request.Name == String.Empty || request.Name == null)
                return new BaseResponse() { StatusCode = 400, Message = "Name is empty" };

            if (request.Age == 0 || request.Name == null)
                return new BaseResponse() { StatusCode = 400, Message = "Age is empty" };

            int id = _repository.Insert(request);

            var result = Get(id);
            result.Message = "Customer was inserted.";
            result.StatusCode = StatusCodes.Status201Created;

            return result;
        }

        public BaseResponse Get(int id)
        {
            if (id == 0)
                return new BaseResponse() { StatusCode = 400, Message = "Id is empty" };

            var result = _repository.Get(id);

            if (result == null)
                return new BaseResponse() { StatusCode = 404, Message = "Customer not found." };

            result.Message = "OK";
            result.StatusCode = StatusCodes.Status200OK;
            
            return result;
        }

        public BaseResponse List()
        {
            var result = _repository.List();
            return new CustomerList() { Customers = result, StatusCode = StatusCodes.Status200OK, Message = "OK" };
        }
    }
}
