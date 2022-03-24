using Nethereum.Contracts.ContractHandlers;
using Nethereum.RPC.Eth.DTOs;
using System;
using System.Threading.Tasks;
//using Ipfs;
using CipherDuo.Ethereum.Constants;
using CipherDuo.Ethereum.Constants.SmartContract;
using CipherDuo.IPFS.Logger;
using Nethereum.Web3.Accounts;
using static CipherDuo.Ethereum.ETHUtility;
using static CipherDuo.Ethereum.Modules.ETHDigitalAssetEvents;
using BigInteger = Nethereum.Hex.HexTypes.HexBigInteger;

namespace CipherDuo.Ethereum.Modules
{
    public static class ETHDigitalAsset
    {
        private static ILog logger = LoggerFactory.GetLogger(nameof(IPFS));
        static public async Task CreateDigitalAsset(Account account, DigitalAsset digitalAsset, BigInteger _timeCreation)
        {
            try
            {
                byte[] encodedStatus = await GetEncodedStatus(new DigitalAssetBase()
                {
                    interest = digitalAsset.SoloIntent,
                    license = digitalAsset.License,
                    state = digitalAsset.State,
                    voted = digitalAsset.Voted,
                    timeCreation = _timeCreation
                });

                //TODO extrapolate IPFS dependencies
                //var dagByte = digitalAsset.DagNode.ToBytes();

                byte[] encodedInfo = await GetEncodedInfo(new DigitalAssetInfo()
                {
                    dag = Array.Empty<byte>(),//dagByte,
                    name = digitalAsset.AssetName,
                    tag = digitalAsset.MainTag
                });

                //TODO substitute with get bottega
                //var digitalAssets = await GetDigitalAsset();
                //string bottega = "";

                //for (int i = 0; i < digitalAssets.Count; i++)
                //{
                //    if (digitalAssets[i].Event.author == account.Address)
                //    {
                //        Logging.Warn("ETHFunctions", "BottegaAlreadyExists");
                //        bottega = digitalAssets[i].Event.inventoryAddress;
                //    }
                //}
                //if (bottega == null)
                //{
                    var bottega = await ETHBottega.CreateBottega(account);
                //}

                logger.Log("Inventory address: " + bottega);

                IContractTransactionHandler<CreateAssetFunction> handler = m_web3.Eth.GetContractTransactionHandler<CreateAssetFunction>();

                CreateAssetFunction transaction = new CreateAssetFunction()
                {
                    bottega = bottega,
                    assetSupply = digitalAsset.Amount,
                    encodedAssetStatus = encodedStatus,
                    encodedAssetInfo = encodedInfo
                };
                //transaction.Gas = 229336;
                transaction.FromAddress = account.Address;

                logger.Log("Starting Transaction Create Asset");
                TransactionReceipt receipt = await handler.SendRequestAndWaitForReceiptAsync(BottegaFactory.contract.Address, transaction);

                logger.Log("Transaction successfull?: " + TransactionSuccessful(receipt));
                logger.Log("Transaction hash: " + receipt.TransactionHash);
                logger.Log("Finish");

            }
            catch (Exception e)
            {
                logger.Log("error {0}", e);
                logger.Log(e.Message);
                logger.Log("error {0}", e.InnerException);
            }

        }

    }
}