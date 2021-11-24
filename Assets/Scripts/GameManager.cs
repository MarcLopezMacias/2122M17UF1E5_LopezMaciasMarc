using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    /*
     * GameManager: que gestiona l'estat del joc, el reinici de partida 
     * i serveix per comunicar els elements de partida.
     */

    public static  GameManager Instance { get { return _instance; } }
    private static GameManager _instance;

    public GameObject Player { get { return _player; } }
    private static GameObject _player;


    public static UIController UIController;

    public int Score { get { return _score; } }
    private int _score;

    public List<GameObject> EnemiesInGame;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            Debug.Log("GameManager DESTROYED");
        }
        _instance = this;
        DontDestroyOnLoad(_instance);
    }

    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
        _player = GameObject.FindWithTag("Player");

        UIController = GameObject.Find("Canvas").GetComponent<UIController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetScore()
    {
        return Score;
    }

    public void IncreaseScore(int value)
    {
        _score += value;
    }

    public int GetNumberOfEnemiesAlive()
    {
        return EnemiesInGame.Count;
    }


    /* PER FER EL CANVI ENTRE SCENES ESCALABLE, ES PODRIA CREAR
     * UN "SCENE_CHANGER" O ALGO AIXI
     */

    public IEnumerator GameOver()
    {
        UIController.GameOver();
        yield return new WaitForSeconds(5);
        GoToStartScreen();
    }

    private void GoToStartScreen()
    {
        
    }

    public void GoToGameScreen()
    {
        
    }

}
