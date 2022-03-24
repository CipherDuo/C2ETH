using CipherDuo.Ethereum.Constants;
using CipherDuo.Ethereum.Constants.SmartContract;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.RPC.Eth.DTOs;
using System.Threading.Tasks;
using CipherDuo.IPFS.Logger;
using Nethereum.Contracts;
using static CipherDuo.Ethereum.ETHUtility;


namespace CipherDuo.Ethereum.Modules
{
    public class ETHVote
    {
        private static ILog logger = LoggerFactory.GetLogger(nameof(IPFS));
        
        static public async Task Vote(Vote item)
        {
            logger.Log("Vote function started");

            Vote itemToVote = new Vote
            {
                AddressTo = item.AddressTo,
                InventoryAddress = item.InventoryAddress,
                TokenID = item.TokenID,
                Strength = item.Strength
            };

            bool canVote = await ETHUtility.ValidVote(itemToVote);
            logger.Log("can vote{0}",canVote);
            if (canVote == false) { logger.Log("Max votes reached!"); return; };

            IContractTransactionHandler<VoteFunction> voteHandler = m_web3.Eth.GetContractTransactionHandler<VoteFunction>();
            VoteFunction voteTransaction = new VoteFunction()
            {
                to = item.AddressTo,
                inventory = item.InventoryAddress,
                tokenID = item.TokenID,
                strenght = item.Strength,
                isPositive = item.Positive,
                dagCid = item.dagCid,
                comCid = item.comCid
            };

            logger.Log("Starting Transaction for Vote");
            TransactionReceipt receipt = await voteHandler.SendRequestAndWaitForReceiptAsync(BottegaFactory.contract.Address, voteTransaction);
            logger.Log("Transaction successful?: " + ETHUtility.TransactionSuccessful(receipt));
            logger.Log(receipt.TransactionHash);
        }

        static public async Task EditVote(Vote item)
        {
            logger.Log("EditVote function started");
            IContractTransactionHandler<EditVoteFunction> editVodeHandler = m_web3.Eth.GetContractTransactionHandler<EditVoteFunction>();
            EditVoteFunction editVoteTransaction = new EditVoteFunction()
            {
                to = item.AddressTo,
                inventory = item.InventoryAddress,
                id = item.TokenID,
                strenght = item.Strength,
                isPositive = item.Positive,
                dagCid = item.dagCid,
                comCid = item.comCid
            };

            logger.Log("Starting Transaction for editVote");
            TransactionReceipt receipt = await editVodeHandler.SendRequestAndWaitForReceiptAsync(BottegaFactory.contract.Address, editVoteTransaction);
            logger.Log("Transaction successful?: " + ETHUtility.TransactionSuccessful(receipt));
        }

        static public async Task TopUpVoteStrenght()
        {
            logger.Log("TopUpUser function started");
            bool canTopUp = await ETHUtility.ValidTopUp();
            logger.Log("can topup {0}", canTopUp);
            if (canTopUp == false) { logger.Log("Can't TopUp!"); return; };

            IContractTransactionHandler<TopUpUserFunction> TopUpUserHandler = m_web3.Eth.GetContractTransactionHandler<TopUpUserFunction>();
            TopUpUserFunction TopUpUserTransaction = new TopUpUserFunction() { };

            logger.Log("Starting Transaction for TopUpUser");
            TransactionReceipt receipt = await TopUpUserHandler.SendRequestAndWaitForReceiptAsync(BottegaFactory.contract.Address, TopUpUserTransaction);
            logger.Log("Transaction successful?: " + ETHUtility.TransactionSuccessful(receipt));
        }
    }
}
