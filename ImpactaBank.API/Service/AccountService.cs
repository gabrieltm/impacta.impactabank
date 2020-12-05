using ImpactaBank.API.Model;
using System;
using ImpactaBank.API.Util;

namespace ImpactaBank.API.Service
{
    public class AccountService
    {
        public BaseResponse Insert(Account request)
        {
            if (request.CustomerId == 0)
                return new BaseResponse() { StatusCode = 400, Message = "Customer is empty" };

            string tokenMd5 = request.CustomerId.ToString() + " - " + DateTime.Now.ToString();


            //call repository - insert
            //call get

            return new Account() { Id = 0, Hash = Util.Util.CreateMD5(tokenMd5), CustomerId = request.CustomerId, StatusCode = 201, Message = "Record created." }; ;
        }


        public BaseResponse Get(int id)
        {
            //call respository - get
            return new BaseResponse();

        }



       
    }
}
