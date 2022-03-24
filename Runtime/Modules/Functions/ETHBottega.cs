using Nethereum.Contracts.ContractHandlers;
using Nethereum.RPC.Eth.DTOs;
using System;
using System.Threading.Tasks;
using CipherDuo.Ethereum.Constants;
using CipherDuo.Ethereum.Constants.SmartContract;
using CipherDuo.IPFS.Logger;
using Nethereum.Web3.Accounts;
using static CipherDuo.Ethereum.ETHUtility;

namespace CipherDuo.Ethereum.Modules
{
    public static class ETHBottega
    {
        private static ILog logger = LoggerFactory.GetLogger(nameof(IPFS));
        static public async Task<string> CreateBottega(Account account)
        {
            try
            {
                IContractTransactionHandler<CreateBottega> txHandler = m_web3.Eth.GetContractTransactionHandler<CreateBottega>();

                CreateBottega function = new CreateBottega() { };
                function.Gas = 1484850;
                function.FromAddress = account.Address;

                TransactionReceipt txReceipt = await txHandler.SendRequestAndWaitForReceiptAsync(BottegaFactory.contract.Address, function);
                logger.Log(txReceipt.TransactionHash);
                
                IContractQueryHandler<CreateBottega> bottegaHandler = m_web3.Eth.GetContractQueryHandler<CreateBottega>();
                string bottega = await bottegaHandler.QueryAsync<string>(BottegaFactory.contract.Address, function);
                
                return bottega;
            }
            catch (Exception error)
            {
                logger.Log("can't create bottega. Error: " + error.Message);
                return null;
            }
        }


    }
}