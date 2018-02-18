using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EtherAPI.Controllers
{
    public class TransactionController : ApiController
    {
        string privateKey = "76aa8a6b120fe87965e0922f5bc156261266f95535b57244fb5270dda1db8280";
        // The default account is an account which is mananaged by the user



        // GET: api/Transaction
        public string Get()
        {
            Account account = new Account(privateKey);
            Web3 web3 = new Web3(account);
            return "current address "+account.Address;
        }

        // GET: api/Transaction/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Transaction
        public void AccTo([FromBody]string value)
        {
        }

        // PUT: api/Transaction/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Transaction/5
        public void Delete(int id)
        {
        }
    }
}
