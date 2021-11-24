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

    public Text HeartsText;
    public Text EnemiesText;
    public Text ScoreText;

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

        int Hearts = GameManager.Instance.Player.GetComponent<DataPlayer>().Hearts;
        HeartsText.text = "Hearts: " + Hearts;

        EnemiesText.text = "Threats: " + GameManager.Instance.GetNumberOfEnemiesAlive();

        ScoreText.text = "XP: " + GameManager.Instance.Score;

        GameOverText.text = "";
    }

    public IEnumerator GameOver()
    {
        GameOverText.text = GameOverString;
        yield return new WaitForSeconds(5);
    }
}
