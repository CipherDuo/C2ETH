using CipherDuo.Ethereum.Constants;
using CipherDuo.Ethereum.Constants.SmartContract;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CipherDuo.IPFS.Logger;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3.Accounts;
using BigInteger = System.Numerics.BigInteger;
using Nethereum.Signer;

namespace CipherDuo.Ethereum
{
    public static class ETHUtility
    {
        public static Web3 m_web3;
        public static Chain m_chain;
        
        private static ILog logger = LoggerFactory.GetLogger(nameof(IPFS));

        public static Dictionary<ETHNetworks, string> ETHNetworksList = new Dictionary<ETHNetworks, string>()
        {
            { ETHNetworks.Infura,"https://ropsten.infura.io/v3/4a7f9ac2d8a94efe80d0950aa5913a1d" },
            { ETHNetworks.VPS, "https://ropsten.infura.io/v3/4a7f9ac2d8a94efe80d0950aa5913a1d" },
            { ETHNetworks.RaspPi, "https://ropsten.infura.io/v3/4a7f9ac2d8a94efe80d0950aa5913a1d" },
            { ETHNetworks.CustomETH,"http://127.0.0.0:8080/" }
        };

        public static string ETHPath { get { return Path.Combine(ETHSystemEnvironment, "CipherDuo", "eth"); } }

        static string ETHSystemEnvironment = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public static void SaveProtectedJSON(string encryptedJson, string fileName)
        {
            if (!Directory.Exists(ETHPath))
            {
                Directory.CreateDirectory(ETHPath);
            }

            var path = Path.Combine(ETHPath, fileName);
            File.WriteAllText(path, encryptedJson);
        }

        public static bool TransactionSuccessful(TransactionReceipt receipt)
        {
            if (receipt.Status.Value == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static public async Task<bool> ValidUser(Account account)
        {
            ValidUser function = new ValidUser() { };

            function.FromAddress = account.Address;

            IContractQueryHandler<ValidUser> handler = m_web3.Eth.GetContractQueryHandler<ValidUser>();
            bool isValid = await handler.QueryAsync<bool>(BottegaFactory.contract.Address, function);

            return isValid;
        }

        static public async Task<bool> ValidTopUp()
        {
            logger.Log("CheckTopUp function started");

            ValidTopUp function = new ValidTopUp() { };
            IContractQueryHandler<ValidTopUp> handler = m_web3.Eth.GetContractQueryHandler<ValidTopUp>();
            try
            {
                bool isValid = await handler.QueryAsync<bool>(BottegaFactory.contract.Address, function);
                return isValid;
            }
            catch (Exception)
            {

                logger.Log("User can't top Up");
                return false;
            }
        }

        static public async Task<bool> ValidVote(Vote item)
        {
            logger.Log("CheckVote function started!");
            if (item.Strength == new HexBigInteger(0)) { logger.Log("Can't vote with 0 strength"); return false; };

            ValidVote checkVoteFunction = new ValidVote()
            {
                to = item.AddressTo,
                inventory = item.InventoryAddress,
                tokenID = item.TokenID,
                strenght = item.Strength
            };

            IContractQueryHandler<ValidVote> checkVoteHandler = m_web3.Eth.GetContractQueryHandler<ValidVote>();

            try
            {
                bool isValid = await checkVoteHandler.QueryAsync<bool>(BottegaFactory.contract.Address, checkVoteFunction);
                return isValid;
            }
            catch (Exception e)
            {
                logger.Log("error {0}", e);
                logger.Log("No more votes / User not exist / User Banned");
                return false;
            }
        }

        static public async Task<string> GetVault()
        {
            logger.Log("Vault function started!");

            VaultFunction vaultFunction = new VaultFunction() { };
            IContractQueryHandler<VaultFunction> vaultHandler = m_web3.Eth.GetContractQueryHandler<VaultFunction>();
            string vaultAddress = await vaultHandler.QueryAsync<string>(BottegaFactory.contract.Address, vaultFunction);
            return vaultAddress;
        }

        public static BigInteger GetEpochTimeNow()
        {
            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            BigInteger secondsSinceEpoch = (BigInteger)t.TotalSeconds;
            return secondsSinceEpoch;
        }

        public static async Task<byte[]> GetEncodedInfo(DigitalAssetInfo _itemInfo)
        {
            try
            {

                GetEncodedInfo createInfoFunction = new GetEncodedInfo()
                {
                    itemInfo = _itemInfo
                };

                IContractQueryHandler<GetEncodedInfo> InfoHandler = m_web3.Eth.GetContractQueryHandler<GetEncodedInfo>();
                GetEncodedInfoOutput Info = await InfoHandler.QueryDeserializingToObjectAsync<GetEncodedInfoOutput>(createInfoFunction, BottegaFactory.CONTRACTADDRESS);
                return Info.Info;
            }
            catch (Exception e)
            {
                logger.Log("error {0}", e);
                return null;
            }
        }

        public static async Task<byte[]> GetEncodedStatus(DigitalAssetBase _itemStatus)
        {
            try
            {
                GetEncodedStatus createInfoFunction = new GetEncodedStatus()
                {
                    itemStatus = _itemStatus
                };

                IContractQueryHandler<GetEncodedStatus> InfoHandler = m_web3.Eth.GetContractQueryHandler<GetEncodedStatus>();
                GetEncodedStatusOutput Info = await InfoHandler.QueryDeserializingToObjectAsync<GetEncodedStatusOutput>(createInfoFunction, BottegaFactory.CONTRACTADDRESS);
                return Info.Status;
            }
            catch (Exception e)
            {
                logger.Log("error {0}", e);
                return null;
            }
        }
    }

}