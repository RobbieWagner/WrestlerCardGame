using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Turn
{
    player,
    enemy
}

public class Game : MonoBehaviour
{
    [SerializeField] private CharacterUI[] characterUIs;
    [SerializeField] private GameObject[] characterPrefabs;
    private GameObject[] characterGOs;
    private Character[] characters;

    [SerializeField] private Vector3 playerStartPosition;
    [SerializeField] private Vector3 enemyStartPosition;

    [HideInInspector] public Character activeCharacter;
    [HideInInspector] public Character targetCharacter;

    [SerializeField] private CardUI cardUI;
    public int handSize;

    int currentTurn;

    [SerializeField] private Card defaultCard;

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
        characterUIs[0].SetCharacter(characters[0]);
        characterGOs[0].transform.position = playerStartPosition;
        characters[0].characterDeck.ShuffleCardDeck();

        characters[0].characterDeck.cardUI = cardUI;

        characterGOs[1] = Instantiate(characterPrefabs[1]);
        characterGOs[1].GetComponent<SpriteRenderer>().flipX = true;
        characters[1] = characterGOs[1].GetComponent<Character>();
        characterUIs[1].SetCharacter(characters[1]);
        characterGOs[1].transform.position = enemyStartPosition;
        characters[1].characterDeck.ShuffleCardDeck();

        currentTurn = (int) Turn.player;
        TakePlayerTurn();
    }

    private void TakePlayerTurn()
    {
        Debug.Log("player");
        characters[0].CurrentStamina += characters[0].maxStamina/4;
        List<Card> hand = characters[0].characterDeck.DrawCards(handSize);
        hand.Add(defaultCard);
        foreach(Card card in hand) cardUI.DisplayCard(card);

        activeCharacter = characters[0];
        targetCharacter = characters[1];
    }

    private void TakeEnemyTurn()
    {
        Debug.Log("enemy");
        StartCoroutine(EnemyTurnCoroutine());
    }

    private void RestCharacter(Character character)
    {
        character.CurrentStamina += character.maxStamina/2;
        character.canAct = true;
        SwapTurns();
    }

    public void SwapTurns()
    {
        cardUI.RemoveCards();

        //Check for end game conditions
        if(FameBar.Instance.Fame == 0 || characters[0].CurrentHealth == 0) EndGame(false);
        else if(FameBar.Instance.Fame == FameBar.Instance.fameNeededForWin || characters[1].CurrentHealth == 0) EndGame(true);

        //have the correct character take their turn
        else if(currentTurn == (int) Turn.player)
        {
            currentTurn = (int) Turn.enemy;
            if(characters[1].canAct)TakeEnemyTurn();
            else RestCharacter(characters[1]);
        }
        else
        {
            currentTurn = (int) Turn.player;
            if(characters[0].canAct)TakePlayerTurn();
            else RestCharacter(characters[0]);
        }
    }

    public void EndGame(bool win)
    {
        if(win)Debug.Log("win");
        else Debug.Log("lose");
    }

    private IEnumerator EnemyTurnCoroutine()
    {
        yield return new WaitForSeconds(1f);

        characters[1].CurrentStamina += characters[1].maxStamina/4;

        activeCharacter = characters[1];
        targetCharacter = characters[0];

        characters[1].characterDeck.ShuffleCardDeck();
        characters[1].characterDeck.deckCards[0].PlayCard();

        StopCoroutine(EnemyTurnCoroutine());
    }

    //changes the fame value of the battle. If called during the enemies turn, lowers the value. If called during the player's turn, raises the value
    public void ChangeFameBar(int value)
    {
        if(currentTurn == (int)Turn.enemy)
        {
            FameBar.Instance.Fame -= value;
        }
        else
        {
            FameBar.Instance.Fame += value;
        }
    }
}
