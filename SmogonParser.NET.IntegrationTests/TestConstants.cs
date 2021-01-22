namespace SmogonParser.NET.IntegrationTests
{
    public class TestConstants
    {
        public const string InjectRpcsJson = @"
{
    ""injectRpcs"": [
        [
            ""[\""dex\"",\""dump-gens\""]"",
            [
                {
                    ""name"": ""TestGeneration1"",
                    ""shorthand"": ""TG1""
                },
                {
                    ""name"": ""TestGeneration2"",
                    ""shorthand"": ""TG2""
                }
            ]
        ],
        [
            ""[\""dex\"",\""dump-basics\"",{\""gen\"":\""ss\""}]"",
            {
                ""pokemon"": [
                    {
                        ""name"": ""TestPokemon1"",
                        ""hp"": 1,
                        ""atk"": 2,
                        ""def"": 3,
                        ""spa"": 4,
                        ""spd"": 5,
                        ""spe"": 6,
                        ""weight"": 7.7,
                        ""height"": 8.8,
                        ""types"": [
                            ""TestType1""
                        ],
                        ""abilities"": [
                            ""TestAbility1"",
                            ""TestAbility2""
                        ],
                        ""formats"": [
                            ""TestFormat1""
                        ],
                        ""isNonstandard"": ""Standard"",
                        ""oob"": {
                            ""dex_number"": 1,
                            ""evos"": [
                                ""TestPokemon2""
                            ],
                            ""alts"": [],
                            ""genfamily"": [
                                ""TestGenFamily1"",
                                ""TestGenFamily2""
                            ]
                        }
                    },
                    {
                        ""name"": ""TestPokemon2"",
                        ""hp"": 10,
                        ""atk"": 20,
                        ""def"": 30,
                        ""spa"": 40,
                        ""spd"": 50,
                        ""spe"": 60,
                        ""weight"": 70.7,
                        ""height"": 80.8,
                        ""types"": [
                            ""TestType1"",
                            ""TestType2""
                        ],
                        ""abilities"": [
                            ""TestAbility1"",
                            ""TestAblity2""
                        ],
                        ""formats"": [
                            ""TestFormat2""
                        ],
                        ""isNonstandard"": ""Standard"",
                        ""oob"": {
                            ""dex_number"": 2,
                            ""evos"": [],
                            ""alts"": [],
                            ""genfamily"": [
                                ""TestGenFamily1"",
                                ""TestGenFamily2""
                            ]
                        }
                    }
                ],
                ""formats"": [
                    {
                        ""name"": ""TestFormat1"",
                        ""shorthand"": ""TF1"",
                        ""genfamily"": [
                            ""TestGenFamily1"",
                            ""TestGenFamily2""
                        ]
                    },
                    {
                        ""name"": ""TestFormat2"",
                        ""shorthand"": ""TF2"",
                        ""genfamily"": [
                            ""TestGenFamily1""
                        ]
                    }
                ],
                ""natures"": [
                    {
                        ""name"": ""TestNature1"",
                        ""hp"": 1,
                        ""atk"": 1.1,
                        ""def"": 1,
                        ""spa"": 0.9,
                        ""spd"": 1,
                        ""spe"": 1,
                        ""summary"": ""+Atk, -SpA"",
                        ""genfamily"": [
                            ""TestGenFamily1"",
                            ""TestGenFamily2""
                        ]
                    },
                    {
                        ""name"": ""TestNature2"",
                        ""hp"": 1,
                        ""atk"": 1,
                        ""def"": 1,
                        ""spa"": 1,
                        ""spd"": 1,
                        ""spe"": 1,
                        ""summary"": """",
                        ""genfamily"": [
                            ""TestGenFamily1"",
                            ""TestGenFamily2""
                        ]
                    }
                ],
                ""abilities"": [
                    {
                        ""name"": ""TestAbility1"",
                        ""description"": ""TestAbility1Description"",
                        ""isNonstandard"": ""Standard"",
                        ""genfamily"": [
                            ""TestGenFamily1"",
                            ""TestGenFamily2""
                        ]
                    },
                    {
                        ""name"": ""TestAbility2"",
                        ""description"": ""TestAbility2Description"",
                        ""isNonstandard"": ""Standard"",
                        ""genfamily"": [
                            ""TestGenFamily1"",
                            ""TestGenFamily2""
                        ]
                    }
                ],
                ""moveflags"": [],
                ""moves"": [
                    {
                        ""name"": ""TestMove1"",
                        ""isNonstandard"": ""Standard"",
                        ""category"": ""Special"",
                        ""power"": 20,
                        ""accuracy"": 100,
                        ""priority"": 0,
                        ""pp"": 25,
                        ""description"": ""TestMove1Description"",
                        ""type"": ""TestMove1Type"",
                        ""flags"": [],
                        ""genfamily"": [
                            ""TestGenFamily1"",
                            ""TestGenFamily2""
                        ]
                    },
                    {
                        ""name"": ""TestMove2"",
                        ""isNonstandard"": ""Standard"",
                        ""category"": ""Special"",
                        ""power"": 40,
                        ""accuracy"": 100,
                        ""priority"": 0,
                        ""pp"": 30,
                        ""description"": ""TestMove2Description"",
                        ""type"": ""TestMove1Type"",
                        ""flags"": [],
                        ""genfamily"": [
                            ""TestGenFamily1"",
                            ""TestGenFamily2""
                        ]
                    }
                ],
                ""types"": [
                    {
                        ""name"": ""TestType1"",
                        ""atk_effectives"": [
                            [
                                ""TestType1"",
                                1
                            ],
                            [
                                ""TestType2"",
                                2
                            ]
                        ],
                        ""genfamily"": [
                            ""TestGenFamily1"",
                            ""TestGenFamily2""
                        ],
                        ""description"": """"
                    },
                    {
                        ""name"": ""TestType2"",
                        ""atk_effectives"": [
                            [
                                ""TestType1"",
                                1
                            ],
                            [
                                ""TestType2"",
                                0.5
                            ]
                        ],
                        ""genfamily"": [
                            ""TestGenFamily1"",
                            ""TestGenFamily2""
                        ],
                        ""description"": ""TestType2Description""
                    }
                ],
                ""items"": [
                    {
                        ""name"": ""TestItem1"",
                        ""description"": ""TestItem1Description"",
                        ""isNonstandard"": ""Standard"",
                        ""genfamily"": [
                            ""TestGenFamily1""
                        ]
                    },
                    {
                        ""name"": ""TestItem2"",
                        ""description"": ""TestItem2Description"",
                        ""isNonstandard"": ""Standard"",
                        ""genfamily"": [
                            ""TestGenFamily1"",
                            ""TestGenFamily2""
                        ]
                    }
		        ]
            }
        ]
    ],
    ""showEditorUI"": null
}";
    }
}
