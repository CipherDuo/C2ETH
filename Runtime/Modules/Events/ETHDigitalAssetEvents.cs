using CipherDuo.Ethereum.Constants;
using CipherDuo.Ethereum.Constants.SmartContract;
using Nethereum.Contracts;
using Nethereum.RPC.Eth.DTOs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using CipherDuo.IPFS.Logger;
using static CipherDuo.Ethereum.ETHUtility;

namespace CipherDuo.Ethereum.Modules
{

    public static class ETHDigitalAssetEvents
    {
        private static ILog logger = LoggerFactory.GetLogger(nameof(IPFS));
        public static async Task<List<EventLog<DigitalAssetDetails>>> GetDigitalAsset(string mainTag = null, string inventoryAdr = null, int ID = 0)
        {
            try
            {
                Event<DigitalAssetDetails> handler = m_web3.Eth.GetEvent<DigitalAssetDetails>(BottegaFactory.CONTRACTADDRESS);
                NewFilterInput filter =
                    ((mainTag == "") && (inventoryAdr == "") && (ID == 0)) ?
                    handler.CreateFilterInput() :
                    ((mainTag != "") && (inventoryAdr == "") && (ID == 0)) ?
                    handler.CreateFilterInput(mainTag) :
                    ((mainTag != "") && (inventoryAdr != "") && (ID == 0)) ?
                    handler.CreateFilterInput(mainTag, inventoryAdr) :
                    handler.CreateFilterInput<string, string, BigInteger>(mainTag, inventoryAdr, ID);

                List<EventLog<DigitalAssetDetails>> events = await handler.GetAllChangesAsync(filter);

                return events;
            }
            catch (Exception e)
            {

                logger.Log("error {0}", e);
                return null;

            }
         }
        public static async Task<List<EventLog<DigitalAssetUpdate>>> GetDigitalAssetUpdate(string address = null, byte[] dagNode = null)
        {
            string _address = (address == "" || address == null) ? null : address;
            byte[] _dagNode = dagNode ?? null; // if dagnode != null ? dagnode : null


            try
            {
                Event<DigitalAssetUpdate> handler = m_web3.Eth.GetEvent<DigitalAssetUpdate>(BottegaFactory.CONTRACTADDRESS);
                NewFilterInput filter = handler.CreateFilterInput<string, byte[]>(_address, _dagNode);

                List<EventLog<DigitalAssetUpdate>> events = await handler.GetAllChangesAsync(filter);

                logger.Log("event count {0}", events.Count);
                return events;
            }
            catch (Exception e)
            {
                logger.Log("error {0}", e);
                return null;
            }
        }

    }
}
