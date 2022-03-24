using Nethereum.Contracts.ContractHandlers;
using Nethereum.Web3;
using System.Numerics;
using System.Threading.Tasks;
using CipherDuo.Ethereum.Constants;
using static CipherDuo.Ethereum.ETHUtility;
using CipherDuo.Ethereum.Constants.SmartContract;
using Nethereum.Hex.HexTypes;

namespace CipherDuo.Ethereum.Modules
{
    public static class ETHGenericEvents
    {

        public static async Task<decimal> GetBalanceETH(string address)
        {
            HexBigInteger balance = await m_web3.Eth.GetBalance.SendRequestAsync(address);
            //Logging.Info("actual balance ", balance.ToString());

            return Web3.Convert.FromWei(balance.Value);
        }

        public static async Task<decimal> GetBalanceCoin(string address)
        {
            BalanceOf function = new BalanceOf()
            {
                Owner = address,
            };

            IContractQueryHandler<BalanceOf> handler = m_web3.Eth.GetContractQueryHandler<BalanceOf>();
            BigInteger balance = await handler.QueryAsync<BigInteger>(Cyte.CONTRACTADDRESS, function);

            return Web3.Convert.FromWei(balance);
        }


    }
}
