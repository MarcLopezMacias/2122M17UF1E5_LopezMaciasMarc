using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    /*
     * UI: comptador de vides. Comptador d'enemics a l'escena. 
     * Comptador de punts per enemic 5.
     */

    public Text FrameText;
    private int FrameCount;

    public Text PlayerNameText;

    public Text LifesText;
    // public Text EnemiesText;
    public Text MaxScoreText;

    public Text GameOverText;
    [SerializeField]
    private string GameOverString = "GAME OVER";
    [SerializeField]
    private int GameOverScreenTime;

    // Start is called before the first frame update
    void Start()
    {
        FrameCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        FrameCount++;
        FrameText.text = "Frames: " + FrameCount;

        int Lifes = GameManager.Instance.Player.GetComponent<DataPlayer>().Lifes;
        LifesText.text = "Lifes: " + Lifes;

        // EnemiesText.text = "Threats: " + GameManager.Instance.GetNumberOfEnemiesAlive();

        MaxScoreText.text = "Top Score: " + GameManager.Instance.MaxScore;

        GameOverText.text = "";

        PlayerNameText.text = GameManager.Instance.Player.GetComponent<DataPlayer>().GetName();

    }

    public IEnumerator GameOver()
    {
        GameOverText.text = GameOverString;
        yield return new WaitForSeconds(GameOverScreenTime);
    }
}
