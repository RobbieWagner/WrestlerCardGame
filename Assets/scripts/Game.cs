using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    public int fameNeededForWin;

    [SerializeField] private CharacterUI[] characterUIs;
    [SerializeField] private GameObject[] characterPrefabs;
    private GameObject[] characterGOs;
    private Character[] characters;

    [SerializeField] private Vector3 playerStartPosition;
    [SerializeField] private Vector3 enemyStartPosition;

    [HideInInspector] public Character activeCharacter;
    [HideInInspector] public Character targetCharacter;

    [SerializeField] private CardUI cardUI;
    [SerializeField] private int handSize;

    public static Game Instance { get; private set; }

    private void Start()
    {
        StartGame();
    }
    private void Awake() 
    { 
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    public void StartGame()
    {
        characterGOs = new GameObject[2];
        characters = new Character[2];

        characterGOs[0] = Instantiate(characterPrefabs[0]);
        characters[0] = characterGOs[0].GetComponent<Character>();
        characters[0].ResetStats();
        characterUIs[0].SetCharacter(characters[0]);
        characterGOs[0].transform.position = playerStartPosition;

        characters[0].characterDeck.cardUI = cardUI;

        characterGOs[1] = Instantiate(characterPrefabs[1]);
        characters[1] = characterGOs[1].GetComponent<Character>();
        characters[1].ResetStats();
        characterUIs[1].SetCharacter(characters[1]);
        characterGOs[1].transform.position = enemyStartPosition;

        TakePlayerTurn();
    }

    private void TakePlayerTurn()
    {
        characters[0].characterDeck.DrawCards(handSize);

        activeCharacter = characters[0];
        targetCharacter = characters[1];
    }

    private void TakeEnemyTurn()
    {
        activeCharacter = characters[1];
        targetCharacter = characters[0];
    }

    public void EndGame()
    {
        
    }
}
