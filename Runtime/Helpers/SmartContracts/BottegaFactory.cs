namespace CipherDuo.Ethereum.Constants.SmartContract
{

	public static class BottegaFactory
	{
		public static readonly string ABI = @"[
	{
		'inputs': [
			{
				'internalType': 'address',
				'name': 'inventory',
				'type': 'address'
			},
			{
				'internalType': 'uint256',
				'name': 'assetSupply',
				'type': 'uint256'
			},
			{
				'internalType': 'bytes',
				'name': 'encodedAssetStatus',
				'type': 'bytes'
			},
			{
				'internalType': 'bytes',
				'name': 'encodedAssetInfo',
				'type': 'bytes'
			}
		],
		'name': 'CreateAsset',
		'outputs': [],
		'stateMutability': 'nonpayable',
		'type': 'function'
	},
	{
		'inputs': [],
		'name': 'CreateInventory',
		'outputs': [
			{
				'internalType': 'address',
				'name': '',
				'type': 'address'
			}
		],
		'stateMutability': 'nonpayable',
		'type': 'function'
	},
	{
		'inputs': [
			{
				'internalType': 'bytes32',
				'name': 'dagCid',
				'type': 'bytes32'
			},
			{
				'internalType': 'string',
				'name': 'nickname',
				'type': 'string'
			},
			{
				'internalType': 'string',
				'name': 'peerID',
				'type': 'string'
			}
		],
		'name': 'CreateUser',
		'outputs': [],
		'stateMutability': 'nonpayable',
		'type': 'function'
	},
	{
		'inputs': [
			{
				'internalType': 'address',
				'name': 'to',
				'type': 'address'
			},
			{
				'internalType': 'address',
				'name': 'inventory',
				'type': 'address'
			},
			{
				'internalType': 'uint256',
				'name': 'id',
				'type': 'uint256'
			},
			{
				'internalType': 'uint256',
				'name': 'strength',
				'type': 'uint256'
			},
			{
				'internalType': 'bool',
				'name': 'isPositive',
				'type': 'bool'
			},
			{
				'internalType': 'bytes32',
				'name': 'dagCid',
				'type': 'bytes32'
			},
			{
				'internalType': 'bytes32',
				'name': 'comCid',
				'type': 'bytes32'
			}
		],
		'name': 'EditVote',
		'outputs': [],
		'stateMutability': 'nonpayable',
		'type': 'function'
	},
	{
		'inputs': [],
		'name': 'TopUpUser',
		'outputs': [],
		'stateMutability': 'nonpayable',
		'type': 'function'
	},
	{
		'inputs': [
			{
				'internalType': 'address payable[]',
				'name': '_units',
				'type': 'address[]'
			}
		],
		'stateMutability': 'nonpayable',
		'type': 'constructor'
	},
	{
		'anonymous': false,
		'inputs': [
			{
				'indexed': true,
				'internalType': 'bytes32',
				'name': 'mainTag',
				'type': 'bytes32'
			},
			{
				'indexed': true,
				'internalType': 'address',
				'name': 'inventoryAdr',
				'type': 'address'
			},
			{
				'indexed': true,
				'internalType': 'uint256',
				'name': 'id',
				'type': 'uint256'
			},
			{
				'indexed': false,
				'internalType': 'address',
				'name': 'author',
				'type': 'address'
			},
			{
				'indexed': false,
				'internalType': 'bytes32',
				'name': 'dagNode',
				'type': 'bytes32'
			},
			{
				'indexed': false,
				'internalType': 'string',
				'name': 'assetName',
				'type': 'string'
			}
		],
		'name': 'ItemBases',
		'type': 'event'
	},
	{
		'anonymous': false,
		'inputs': [
			{
				'indexed': true,
				'internalType': 'address',
				'name': 'owner',
				'type': 'address'
			},
			{
				'indexed': true,
				'internalType': 'bytes32',
				'name': 'dagNode',
				'type': 'bytes32'
			},
			{
				'components': [
					{
						'internalType': 'bool',
						'name': 'canEdit',
						'type': 'bool'
					},
					{
						'internalType': 'bool',
						'name': 'canBorrow',
						'type': 'bool'
					},
					{
						'internalType': 'bool',
						'name': 'canBeListed',
						'type': 'bool'
					},
					{
						'internalType': 'bool',
						'name': 'isProtected',
						'type': 'bool'
					}
				],
				'indexed': false,
				'internalType': 'struct Factory.License',
				'name': 'license',
				'type': 'tuple'
			},
			{
				'indexed': false,
				'internalType': 'uint256',
				'name': 'amount',
				'type': 'uint256'
			},
			{
				'indexed': false,
				'internalType': 'enum Factory.State',
				'name': 'state',
				'type': 'uint8'
			},
			{
				'indexed': false,
				'internalType': 'uint256',
				'name': 'soloIntent',
				'type': 'uint256'
			}
		],
		'name': 'ItemUpdates',
		'type': 'event'
	},
	{
		'inputs': [
			{
				'internalType': 'bytes32',
				'name': 'dagCid',
				'type': 'bytes32'
			},
			{
				'internalType': 'string',
				'name': 'peerID',
				'type': 'string'
			}
		],
		'name': 'UpdateUser',
		'outputs': [],
		'stateMutability': 'nonpayable',
		'type': 'function'
	},
	{
		'anonymous': false,
		'inputs': [
			{
				'indexed': true,
				'internalType': 'address',
				'name': 'account',
				'type': 'address'
			},
			{
				'indexed': true,
				'internalType': 'string',
				'name': 'indexNickname',
				'type': 'string'
			},
			{
				'indexed': false,
				'internalType': 'string',
				'name': 'nickname',
				'type': 'string'
			},
			{
				'indexed': true,
				'internalType': 'bool',
				'name': 'banned',
				'type': 'bool'
			},
			{
				'indexed': false,
				'internalType': 'uint256',
				'name': 'timeCreation',
				'type': 'uint256'
			}
		],
		'name': 'UserBases',
		'type': 'event'
	},
	{
		'anonymous': false,
		'inputs': [
			{
				'indexed': true,
				'internalType': 'address',
				'name': 'account',
				'type': 'address'
			},
			{
				'indexed': true,
				'internalType': 'string',
				'name': 'peedID',
				'type': 'string'
			},
			{
				'indexed': true,
				'internalType': 'bytes32',
				'name': 'dagCid',
				'type': 'bytes32'
			}
		],
		'name': 'UserUpdates',
		'type': 'event'
	},
	{
		'inputs': [
			{
				'internalType': 'address',
				'name': 'to',
				'type': 'address'
			},
			{
				'internalType': 'address',
				'name': 'inventory',
				'type': 'address'
			},
			{
				'internalType': 'uint256',
				'name': 'Tokenid',
				'type': 'uint256'
			},
			{
				'internalType': 'uint256',
				'name': 'strength',
				'type': 'uint256'
			},
			{
				'internalType': 'bool',
				'name': 'isPositive',
				'type': 'bool'
			},
			{
				'internalType': 'bytes32',
				'name': 'dagCid',
				'type': 'bytes32'
			},
			{
				'internalType': 'bytes32',
				'name': 'comCid',
				'type': 'bytes32'
			}
		],
		'name': 'Vote',
		'outputs': [],
		'stateMutability': 'nonpayable',
		'type': 'function'
	},
	{
		'anonymous': false,
		'inputs': [
			{
				'indexed': true,
				'internalType': 'bytes32',
				'name': 'comCid',
				'type': 'bytes32'
			},
			{
				'indexed': true,
				'internalType': 'bytes32',
				'name': 'dagCid',
				'type': 'bytes32'
			},
			{
				'indexed': true,
				'internalType': 'uint256',
				'name': 'repo',
				'type': 'uint256'
			},
			{
				'indexed': false,
				'internalType': 'bool',
				'name': 'isPositive',
				'type': 'bool'
			}
		],
		'name': 'VoteDetails',
		'type': 'event'
	},
	{
		'anonymous': false,
		'inputs': [
			{
				'indexed': true,
				'internalType': 'address',
				'name': 'owner',
				'type': 'address'
			},
			{
				'indexed': true,
				'internalType': 'address',
				'name': '_from',
				'type': 'address'
			},
			{
				'indexed': true,
				'internalType': 'bytes32',
				'name': 'dagCid',
				'type': 'bytes32'
			},
			{
				'indexed': false,
				'internalType': 'bytes32',
				'name': 'comCid',
				'type': 'bytes32'
			}
		],
		'name': 'Voted',
		'type': 'event'
	},
	{
		'inputs': [
			{
				'components': [
					{
						'internalType': 'bytes32',
						'name': 'tag',
						'type': 'bytes32'
					},
					{
						'internalType': 'bytes32',
						'name': 'dag',
						'type': 'bytes32'
					},
					{
						'internalType': 'string',
						'name': 'name',
						'type': 'string'
					}
				],
				'internalType': 'struct Factory.ItemInfo',
				'name': 'item',
				'type': 'tuple'
			}
		],
		'name': 'CheckDecodedInfo',
		'outputs': [],
		'stateMutability': 'pure',
		'type': 'function'
	},
	{
		'inputs': [],
		'name': 'CheckTopUp',
		'outputs': [
			{
				'internalType': 'bool',
				'name': '',
				'type': 'bool'
			}
		],
		'stateMutability': 'view',
		'type': 'function'
	},
	{
		'inputs': [],
		'name': 'CheckUser',
		'outputs': [
			{
				'internalType': 'bool',
				'name': '',
				'type': 'bool'
			}
		],
		'stateMutability': 'view',
		'type': 'function'
	},
	{
		'inputs': [
			{
				'internalType': 'address',
				'name': 'to',
				'type': 'address'
			},
			{
				'internalType': 'address',
				'name': 'inventory',
				'type': 'address'
			},
			{
				'internalType': 'uint256',
				'name': 'Tokenid',
				'type': 'uint256'
			},
			{
				'internalType': 'uint256',
				'name': 'strength',
				'type': 'uint256'
			}
		],
		'name': 'CheckVote',
		'outputs': [
			{
				'internalType': 'bool',
				'name': '',
				'type': 'bool'
			}
		],
		'stateMutability': 'view',
		'type': 'function'
	},
	{
		'inputs': [
			{
				'components': [
					{
						'internalType': 'bytes32',
						'name': 'tag',
						'type': 'bytes32'
					},
					{
						'internalType': 'bytes32',
						'name': 'dag',
						'type': 'bytes32'
					},
					{
						'internalType': 'string',
						'name': 'name',
						'type': 'string'
					}
				],
				'internalType': 'struct Factory.ItemInfo',
				'name': 'info',
				'type': 'tuple'
			}
		],
		'name': 'GetEncodedInfo',
		'outputs': [
			{
				'internalType': 'bytes',
				'name': '',
				'type': 'bytes'
			}
		],
		'stateMutability': 'pure',
		'type': 'function'
	},
	{
		'inputs': [
			{
				'components': [
					{
						'internalType': 'uint256',
						'name': 'interest',
						'type': 'uint256'
					},
					{
						'components': [
							{
								'internalType': 'bool',
								'name': 'canEdit',
								'type': 'bool'
							},
							{
								'internalType': 'bool',
								'name': 'canBorrow',
								'type': 'bool'
							},
							{
								'internalType': 'bool',
								'name': 'canBeListed',
								'type': 'bool'
							},
							{
								'internalType': 'bool',
								'name': 'isProtected',
								'type': 'bool'
							}
						],
						'internalType': 'struct Factory.License',
						'name': 'license',
						'type': 'tuple'
					},
					{
						'internalType': 'enum Factory.State',
						'name': 'state',
						'type': 'uint8'
					},
					{
						'internalType': 'bool',
						'name': 'voted',
						'type': 'bool'
					},
					{
						'internalType': 'uint256',
						'name': 'timeCreation',
						'type': 'uint256'
					}
				],
				'internalType': 'struct Factory.Item',
				'name': 'status',
				'type': 'tuple'
			}
		],
		'name': 'GetEncodedStatus',
		'outputs': [
			{
				'internalType': 'bytes',
				'name': '',
				'type': 'bytes'
			}
		],
		'stateMutability': 'pure',
		'type': 'function'
	},
	{
		'inputs': [],
		'name': 'Vault',
		'outputs': [
			{
				'internalType': 'address',
				'name': '',
				'type': 'address'
			}
		],
		'stateMutability': 'view',
		'type': 'function'
	}
]";
		public static readonly string CONTRACTADDRESS = "0xb6bCA9A858585008b8e75079893D0B1C5f8501C2";
		public static Nethereum.Contracts.Contract contract;

	}
}

