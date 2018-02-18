using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Numerics;
using System.Threading.Tasks;
using System.Web.Http;

namespace EtherAPI.Controllers
{
    public class EthController : ApiController
    {
        static readonly BigInteger ethToWeiRatio = new BigInteger(1000000000000000000);
        // GET: api/Eth
        public IEnumerable<string> Get()
        {
            Web3 web3 = new Web3();
            var accountsTask = web3.Eth.Accounts.SendRequestAsync();
            accountsTask.Wait();
            var accounts = accountsTask.Result;
            string[] values = new string[accounts.Count()];
            for (int i = 0; i < accounts.Count(); i++)
                values[i] = accounts[i];
            return values;
        }

        // GET: api/Eth/5
        public string Get(string id)
        {
            Web3 web3 = new Web3();
            var balanceTask = web3.Eth.GetBalance.SendRequestAsync(id);
            balanceTask.Wait();
            var balance = balanceTask.Result;
            return "account " + id + " | balance in eth: "
                              + BigInteger.Divide(balance.Value, ethToWeiRatio) + " | " +
                              "balance in wei: "
                                  + balance.Value;
        }

        // POST: api/Eth
        [HttpPost]
        public async Task<string> Post([FromBody]TransactionModel value)
        {
            string responce = "";
            var addressTo = value.To;
            var privateKey = value.From_PrivateKey;
            var amount = value.Amount;
            try
            {
                var account = new Account(privateKey);
                var web3 = new Web3(account);
                var res = await web3.TransactionManager.SendTransactionAsync(account.Address.ToLower(), addressTo, new HexBigInteger(amount));
                responce = "complete!";
            }
            catch(Exception ex)
            {
                responce = ex.Source +", "+ ex.Message;
            }

            return responce;

        }

       

        // PUT: api/Eth/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE: api/Eth/5
        public void Delete(int id)
        {
        }
    }
}
