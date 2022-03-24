using Nethereum.Contracts;
using Nethereum.RPC.Eth.DTOs;
using System.Collections.Generic;
using Nethereum.Web3;
using System;
using System.Numerics;
using System.Threading.Tasks;
using CipherDuo.Ethereum.Constants;
using Nethereum.Contracts.ContractHandlers;
using CipherDuo.Ethereum.Constants.SmartContract;
using CipherDuo.IPFS.Logger;
using static CipherDuo.Ethereum.ETHUtility;

namespace CipherDuo.Ethereum.Modules
{

    public static class ETHUserEvents
    {
        private static ILog logger = LoggerFactory.GetLogger(nameof(IPFS));
        public static async Task<EventLog<UserUpdates>> GetUserEdits(string address = null, string peerID = null, byte[] dagCid = null)
        {
            Event<UserUpdates> handler = m_web3.Eth.GetEvent<UserUpdates>(BottegaFactory.CONTRACTADDRESS);
            NewFilterInput filter = handler.CreateFilterInput(address, peerID, dagCid);

            var events = await handler.GetAllChangesAsync(filter);

            EventLog<UserUpdates> lastValue = (events.Count > 0) ? events[events.Count - 1] : null;

            if (lastValue == null) { logger.Log("Error"); return null; };

            return lastValue;
        }

        public static async Task<EventLog<UserInfo>> GetUser(string account)
        {
            Event<UserInfo> handler = m_web3.Eth.GetEvent<UserInfo>(BottegaFactory.CONTRACTADDRESS);
            var firstBlock = BlockParameter.CreateEarliest();
            var lastBlock = BlockParameter.CreateLatest();
            NewFilterInput filter = handler.CreateFilterInput(account, firstBlock, lastBlock);

            var events = await handler.GetAllChangesAsync(filter);

            EventLog<UserInfo> lastValue = (events.Count > 0) ? events[events.Count - 1] : null;

            return lastValue;
        }

    }

}
