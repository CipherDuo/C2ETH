using CipherDuo.Ethereum;
using CipherDuo.Ethereum.Constants;
using CipherDuo.Ethereum.Constants.SmartContract;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Nethereum.RPC;
using Nethereum.Signer;

public static class ETH
{
    public static string provider;
    public static void Init(Account account, Chain chain)
    {
        ETHUtility.m_web3 = new Web3(account, provider);
        ETHUtility.m_chain = chain;
        
        BottegaFactory.contract = ETHUtility.m_web3.Eth.GetContract(BottegaFactory.ABI, BottegaFactory.CONTRACTADDRESS);
        Cyte.contract = ETHUtility.m_web3.Eth.GetContract(Cyte.ABI, Cyte.CONTRACTADDRESS);
    }

}
