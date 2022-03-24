using Nethereum.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CipherDuo.Ethereum.Constants;
using CipherDuo.Ethereum.Constants.SmartContract;
using CipherDuo.IPFS.Logger;
using static CipherDuo.Ethereum.ETHUtility;

namespace CipherDuo.Ethereum.Modules
{

    public class ETHVoteEvents
    {
        private static ILog logger = LoggerFactory.GetLogger(nameof(IPFS));
        public static async Task<List<DigitalAssetVote>> GetDigitalAssetVotes(string address, string _from, byte[] dagCid)
        {
            try
            {

                List<DigitalAssetVote> digitalAssetVotes = new List<DigitalAssetVote>();
                Event<VotedEvent> handler = m_web3.Eth.GetEvent<VotedEvent>(BottegaFactory.CONTRACTADDRESS);
                var filter = handler.CreateFilterInput(address, _from, dagCid);

                var events = await handler.GetAllChangesAsync(filter);

                foreach (var vote in events)
                {
                    var details = await GetItemVotesDetailed(vote.Event.comCid, vote.Event.dagCid);

                    if (details == null) { continue; }
                    else
                    {
                        DigitalAssetVote item = new DigitalAssetVote()
                        {
                            VoteBase = vote.Event,
                            VoteDetail = details.Event
                        };

                        digitalAssetVotes.Add(item);
                    };
                }

                return digitalAssetVotes;
            }
            catch (Exception e)
            {
                logger.Log("error {0}", e);
                return null;
            }
        }
        public static async Task<EventLog<VoteDetails>> GetItemVotesDetailed(byte[] comCid, byte[] dagCid)
        {
            try
            {
                Event<VoteDetails> handler = m_web3.Eth.GetEvent<VoteDetails>(BottegaFactory.CONTRACTADDRESS);
                var filter = handler.CreateFilterInput<byte[], byte[]>(comCid, dagCid);

                var events = await handler.GetAllChangesAsync(filter);

                EventLog<VoteDetails> lastValue = (events.Count > 0) ? events[events.Count - 1] : null;

                return lastValue;
            }
            catch (Exception e)
            {
                logger.Log("error {0}", e);
                return null;
            }
        }


    }
}