using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using BigInteger = Nethereum.Hex.HexTypes.HexBigInteger;

namespace CipherDuo.Ethereum.Constants
{

    #region Ethereum Smart Contract's Data Structures


    // CIPHERDUO

    public enum ETHNetworks
    {
        Infura,
        VPS,
        RaspPi,
        CustomETH
    };


    // USER
    
    public class C2UserData
    {
        public string pic;
        public string bio;
        public string charAddress;

        public C2UserData(string _pic, string _bio, string _charAddress)
        {
            pic = _pic;
            bio = _bio;
            charAddress = _charAddress;
        }
    }


    // ITEM

    public struct DigitalAsset
    {
        public string Author;
        public string Owner;
        public string InventoryAddress;
        public string MainTag;
        public string AssetName;
        public string Description;
        public string DagNode;
        public byte State;
        public BigInteger Amount;
        public BigInteger TokenID;
        public BigInteger SoloIntent;
        public DigitalAssetLicense License;
        public bool Voted;
    }

    public class DigitalAssetBase
    {
        [Parameter("uint256", "interest", 1)]
        public BigInteger interest { get; set; }

        [Parameter("tuple", "license", 2)]
        public DigitalAssetLicense license { get; set; }

        [Parameter("uint8", "state", 3)]
        public byte state { get; set; }

        [Parameter("bool", "voted", 4)]
        public bool voted { get; set; }

        [Parameter("uint256", "timeCreation", 5)]
        public BigInteger timeCreation { get; set; }
    }

    public class DigitalAssetInfo
    {
        [Parameter("bytes32", "tag", 1)]
        public string tag { get; set; }

        [Parameter("bytes32", "dag", 2)]
        public byte[] dag { get; set; }

        [Parameter("string", "name", 3)]
        public string name { get; set; }
    }
    
    public class DigitalAssetLicense
    {
        [Parameter("bool", "canEdit", 1)]
        public bool canEdit { get; set; }

        [Parameter("bool", "canBorrow", 2)]
        public bool canBorrow { get; set; }

        [Parameter("bool", "canBeListed", 3)]
        public bool canBeListed { get; set; }

        [Parameter("bool", "isProtected", 4)]
        public bool isProtected { get; set; }
    }

    public class Bottega
    {

        [Parameter("address", "inventory", 1)]
        public byte[] inventoryAddress { get; set; }

        [Parameter("address", "owner", 2)]
        public byte[] Owner { get; set; }

        [Parameter("uint256", "id", 3)]
        public BigInteger id { get; set; }
    }


    // VOTE
    public struct Vote
    {

        public string AddressTo;
        public string AddressFrom;
        public string InventoryAddress;
        public BigInteger TokenID;
        public BigInteger Strength;
        public BigInteger Repo;
        public bool Positive;
        public byte[] dagCid;
        public byte[] comCid;
        public string comment;
    }

    public class DigitalAssetVote
    {
        public VotedEvent VoteBase { get; set; }
        public VoteDetails VoteDetail { get; set; }
    }


    #endregion

    #region Ethereum Smart Contract's Functions


    // CIPHERDUO

    [Function("Vault", "bool")]
    public class VaultFunction : FunctionMessage { }


    // USER

    [Function("CreateUser")]
    public class CreateUser : FunctionMessage
    {
        [Parameter("bytes32", "dagCid", 1)]
        public byte[] dagCid { get; set; }

        [Parameter("string", "nickname", 2)]
        public string nickName { get; set; }

        [Parameter("string", "peerID", 3)]
        public string peerID { get; set; }

    }

    [Function("CheckUser", "bool")]
    public class ValidUser : FunctionMessage { }


    // ITEM

    [Function("GetEncodedInfo", "bytes")]
    public class GetEncodedInfo : FunctionMessage
    {
        [Parameter("tuple", "info", 1)]
        public DigitalAssetInfo itemInfo { get; set; }

    }

    [Function("GetEncodedStatus", "bytes")]
    public class GetEncodedStatus : FunctionMessage
    {
        [Parameter("tuple", "status", 1)]
        public DigitalAssetBase itemStatus { get; set; }

    }

    [Function("CreateAsset")]
    public class CreateAssetFunction : FunctionMessage
    {
        [Parameter("address", "inventory", 1)]
        public string bottega { get; set; }

        [Parameter("uint256", "assetSupply", 2)]
        public BigInteger assetSupply { get; set; }

        [Parameter("bytes", "encodedAssetStatus", 3)]
        public byte[] encodedAssetStatus { get; set; }

        [Parameter("bytes", "encodedAssetInfo", 4)]
        public byte[] encodedAssetInfo { get; set; }

    }

    [Function("CreateInventory", "address")]
    public class CreateBottega : FunctionMessage { }


    // VOTE

    [Function("Vote")]
    public class VoteFunction : FunctionMessage, IEventDTO
    {
        [Parameter("address", "to", 1)]
        public string to { get; set; }

        [Parameter("address", "inventory", 2)]
        public string inventory { get; set; }

        [Parameter("uint", "Tokenid", 3)]
        public BigInteger tokenID { get; set; }

        [Parameter("uint", "strenght", 4)]
        public BigInteger strenght { get; set; }

        [Parameter("bool", "isPositive", 5)]
        public bool isPositive { get; set; }

        [Parameter("bytes32", "dagCid", 6)]
        public byte[] dagCid { get; set; }

        [Parameter("bytes32", "comCid", 7)]
        public byte[] comCid { get; set; }
    }

    [Function("EditVote")]
    public class EditVoteFunction : FunctionMessage
    {
        [Parameter("address", "to", 1)]
        public string to { get; set; }

        [Parameter("address", "inventory", 2)]
        public string inventory { get; set; }

        [Parameter("uint", "id", 3)]
        public BigInteger id { get; set; }

        [Parameter("uint", "strenght", 4)]
        public BigInteger strenght { get; set; }

        [Parameter("bool", "isPositive", 5)]
        public bool isPositive { get; set; }

        [Parameter("bytes32", "dagCid", 6)]
        public byte[] dagCid { get; set; }

        [Parameter("bytes32", "comCid", 7)]
        public byte[] comCid { get; set; }
    }

    [Function("CheckTopUp", "bool")]
    public class ValidTopUp : FunctionMessage { }

    [Function("TopUpUser")]
    public class TopUpUserFunction : FunctionMessage { }

    [Function("CheckVote", "bool")]
    public class ValidVote : FunctionMessage
    {
        [Parameter("address", "to", 1)]
        public string to { get; set; }

        [Parameter("address", "inventory", 2)]
        public string inventory { get; set; }

        [Parameter("uint", "Tokenid", 3)]
        public BigInteger tokenID { get; set; }

        [Parameter("uint", "strenght", 4)]
        public BigInteger strenght { get; set; }
    }


    // STANDARDS

    [Function("balanceOf", "uint256")]
    public class BalanceOf : FunctionMessage
    {
        [Parameter("address", "account", 1)]
        public string Owner { get; set; }
    }


    #endregion

    #region Ethereum Smart Contract's Functions Output


    // CIPHERDUO 

    [FunctionOutput]
    public class VaultOutput : IFunctionOutputDTO
    {
        [Parameter("address", 1)]
        public string address { get; set; }
    }


    // USER 

    [FunctionOutput]
    public class GetEncodedInfoOutput : IFunctionOutputDTO
    {
        [Parameter("bytes", 1)]
        public byte[] Info { get; set; }
    }

    [FunctionOutput]
    public class GetInventoryOutput : IFunctionOutputDTO
    {
        [Parameter("address", "address", 1)]
        public string Address { get; set; }
    }

    [FunctionOutput]
    public class GetUserOutput : IFunctionOutputDTO
    {
        [Parameter("bool", 1)]
        public bool valid { get; set; }
    }


    // ITEM 

    [FunctionOutput]
    public class GetEncodedStatusOutput : IFunctionOutputDTO
    {
        [Parameter("bytes", 1)]
        public byte[] Status { get; set; }
    }


    // VOTE 

    [FunctionOutput]
    public class GetVoteOutput : IFunctionOutputDTO
    {
        [Parameter("bool", 1)]
        public bool valid { get; set; }
    }

    [FunctionOutput]
    public class GetTopUpOutput : IFunctionOutputDTO
    {
        [Parameter("bool", 1)]
        public bool valid { get; set; }
    }


    #endregion

    #region Ethereum Smart Contract's Events


    // USER 

    [Event("UserBases")]
    public class UserInfo : IEventDTO
    {
        [Parameter("address", "account", 1, true)]
        public string account { get; set; }

        [Parameter("string", "indexNickname", 2, true)]
        public string indexNickname { get; set; }

        [Parameter("string", "nickname", 3, false)]
        public string nickname { get; set; }

        [Parameter("bool", "banned", 4, true)]
        public bool banned { get; set; }

        [Parameter("uint", "timeCreation", 5, false)]
        public BigInteger timeCreation { get; set; }
    }

    [Event("UserUpdates")]
    public class UserUpdates : IEventDTO
    {
        [Parameter("address", "account", 1, true)]
        public string account { get; set; }

        [Parameter("string", "peedID", 2, true)]
        public string peerID { get; set; }

        [Parameter("bytes32", "dagCid", 3, true)]
        public byte[] dagCid { get; set; }
    }


    // ITEMS 

    [Event("ItemBases")]
    public class DigitalAssetDetails : IEventDTO
    {
        [Parameter("bytes32", "mainTag", 1, true)]
        public string mainTag { get; set; }

        [Parameter("address", "inventoryAdr", 2, true)]
        public string inventoryAddress { get; set; }

        [Parameter("uint256", "id", 3, true)]
        public BigInteger id { get; set; }

        [Parameter("address", "author", 4, false)]
        public string author { get; set; }

        [Parameter("bytes32", "dagNode", 5, false)]
        public byte[] dagNode { get; set; }

        [Parameter("string", "assetName", 6, false)]
        public string assetName { get; set; }
    }

    [Event("ItemUpdates")]
    public class DigitalAssetUpdate : IEventDTO
    {
        [Parameter("address", "owner", 1, true)]
        public string owner { get; set; }

        [Parameter("bytes32", "dagNode", 2, true)]
        public byte[] dagNode { get; set; }

        [Parameter("tuple", "license", 3, false)]
        public DigitalAssetLicense license { get; set; }

        [Parameter("uint256", "amount", 4, false)]
        public BigInteger amount { get; set; }

        [Parameter("uint8", "state", 5, false)]
        public byte state { get; set; }

        [Parameter("uint256", "soloIntent", 6, false)]
        public BigInteger soloIntent { get; set; }
    }


    // VOTES 

    [Event("Voted")]
    public class VotedEvent : IEventDTO
    {
        [Parameter("address", "owner", 1, true)]
        public string owner { get; set; }

        [Parameter("address", "_from", 2, true)]
        public string from { get; set; }

        [Parameter("bytes32", "dagCid", 3, true)]
        public byte[] dagCid { get; set; }

        [Parameter("bytes32", "comCid", 4, false)]
        public byte[] comCid { get; set; }
    }

    [Event("VoteDetails")]
    public class VoteDetails : IEventDTO
    {
        [Parameter("bytes32", "comCid", 1, true)]
        public byte[] comCid { get; set; }

        [Parameter("bytes32", "dagCid", 2, true)]
        public byte[] dagCid { get; set; }

        [Parameter("uint256", "repo", 3, true)]
        public BigInteger repo { get; set; }

        [Parameter("bool", "isPositive", 4, false)]
        public bool isPositive { get; set; }
    }


    #endregion
}