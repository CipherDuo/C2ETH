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
    public static class ETHUser
    {
        private static ILog logger = LoggerFactory.GetLogger(nameof(IPFS));
        public static async Task<bool> SetUser(Account account, byte[] _dagCid, string _nickName, byte[] _peerID)
        {
            try
            {
                IContractTransactionHandler<CreateUser> txHandler = m_web3.Eth.GetContractTransactionHandler<CreateUser>();

                CreateUser function = new CreateUser()
                {
                    dagCid = _dagCid,
                    nickName = _nickName,
                    peerID = Convert.ToBase64String(_peerID)
                };
                //function.Gas = 190749;
                function.FromAddress = account.Address;
                
                //TODO Check if user already exists
                TransactionReceipt receipt = await txHandler.SendRequestAndWaitForReceiptAsync(BottegaFactory.contract.Address, function);
                logger.Log(receipt.TransactionHash);
                return ETHUtility.TransactionSuccessful(receipt);

            }
            catch (Exception error)
            {
                logger.Log("Can't create User. Error : " + error);
                throw;
            }
            
        }
    }
}
