using ImpactaBank.API.Model;
using System;
using ImpactaBank.API.Util;
using ImpactaBank.API.Repository;
using Microsoft.AspNetCore.Http;

namespace ImpactaBank.API.Service
{
    public class AccountService
    {
        AccountRepository _repository = new AccountRepository();

        public BaseResponse Insert(Account request)
        {
            if (request.CustomerId == 0)
                return new BaseResponse() { StatusCode = 400, Message = "Customer is empty" };

            string tokenMd5 = request.CustomerId.ToString() + " - " + DateTime.Now.ToString();
            request.Hash = Util.Util.CreateMD5(tokenMd5);

            int id = _repository.Insert(request);
            var result = Get(id);
            result.Message = "Account was created.";
            result.StatusCode = StatusCodes.Status201Created;
            return result;
        }


        public BaseResponse Get(int id)
        {
            if (id == 0)
                return new BaseResponse() { StatusCode = 400, Message = "Id is empty" };

            var result = _repository.Get(id);
            result.StatusCode = StatusCodes.Status200OK;
            result.Message = "OK";
            return result;
        }       
    }
}
