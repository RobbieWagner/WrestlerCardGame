using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    public int fameNeededForWin;

    [SerializeField] CharacterUI[] characterUIs;
    [SerializeField] GameObject[] characterPrefabs;
    GameObject[] characterGOs;
    Character[] characters;

    [SerializeField] Vector3 playerStartPosition;
    [SerializeField] Vector3 enemyStartPosition;

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

        characterGOs[1] = Instantiate(characterPrefabs[1]);
        characters[1] = characterGOs[1].GetComponent<Character>();
        characters[1].ResetStats();
        characterUIs[1].SetCharacter(characters[1]);
        characterGOs[1].transform.position = enemyStartPosition;
    }

    public void EndGame()
    {
        
    }
}
