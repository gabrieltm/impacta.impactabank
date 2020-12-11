using ImpactaBank.API.Model;
using ImpactaBank.API.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpactaBank.API.Service
{
    public class OperationService
    {
        OperationRepository _repository = new OperationRepository();
        AccountRepository _repositoryAccount = new AccountRepository();

        public BaseResponse Operation(OperationAccount request)
        {

            Operation operation = new Operation();

            if (request.Hash == "")
                return new BaseResponse() { StatusCode = 400, Message = "Hash is empty" };

            Account account = _repositoryAccount.GetHash(request.Hash);

            if (request.Type == "D")
            {
                operation.Type = request.Type;
                operation.Value = request.Value;
                operation.DateTime = DateTime.Now;
                operation.AccountDestinyId = account.Id;
            }

            if (request.Type == "S")
            {
                operation.Type = request.Type;
                operation.Value = request.Value;
                operation.DateTime = DateTime.Now;
                operation.AccountRootId = account.Id;
            }

            int id = _repository.Insert(operation);
            var result = Get(id);
            result.Message = "Operation was created.";
            result.StatusCode = StatusCodes.Status201Created;
            return result;
        }

        public BaseResponse Balance(string hash)
        {

            if (hash == "")
                return new BaseResponse() { StatusCode = 400, Message = "Hash is empty" };

            Account account = _repositoryAccount.GetHash(hash);
            List<Operation> operationOrigin = _repository.ListOrigin(account.CustomerId);
            List<Operation> operationDestiny = _repository.ListDestiny(account.CustomerId);

            decimal saldo = 0;

            foreach (Operation origin in operationOrigin)
            {
                saldo -= origin.Value;
            }

            foreach (Operation destiny in operationDestiny)
            {
                saldo += destiny.Value;
            }

            return new Balance() { Hash = hash, Value = saldo, StatusCode = StatusCodes.Status200OK, Message = "OK" };
        }

        public BaseResponse Transfer(Transfer request)
        {

            if (request.HashOrigin == "" || request.HashDestiny == "")
                return new BaseResponse() { StatusCode = 400, Message = "Hash is empty" };

            Operation operation = new Operation();

            Account accountOrigin = _repositoryAccount.GetHash(request.HashOrigin);
            Account accountDestiny = _repositoryAccount.GetHash(request.HashDestiny);

            operation.Type = "T";
            operation.AccountDestinyId = accountOrigin.Id;
            operation.AccountRootId = accountDestiny.Id;
            operation.DateTime = DateTime.Now;
            operation.Value = request.Value;

            int id = _repository.Insert(operation);
            var result = Get(id);
            result.Message = "Operation was created.";
            result.StatusCode = StatusCodes.Status201Created;
            return result;

        }

        public BaseResponse Get(int id)
        {
            if (id == 0)
                return new BaseResponse() { StatusCode = 400, Message = "Id is empty" };

            var result = _repository.Get(id);

            if (result == null)
                return new BaseResponse() { StatusCode = 404, Message = "Operation not found." };

            result.Message = "OK";
            result.StatusCode = StatusCodes.Status200OK;

            return result;
        }
    }
}
