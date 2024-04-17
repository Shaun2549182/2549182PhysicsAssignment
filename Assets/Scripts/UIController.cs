using UnityEngine;

public class UiController : MonoBehaviour
{

    [Header("Canvas")]
    public GameObject Canvas;
    public GameObject EndGameState;

    [Header("CanvasRestart")]
    public GameObject WinTxt;
    public GameObject LooseTxt;

    [Header("Other")]

    public ScoreController scoreController;

    public PuckScript puckScript;
    public PlayerController playerController;
    public BlueController BlueController;

    public void ShowRestartCanvas(bool didAiWin)
    {
        Time.timeScale = 0;

        Canvas.SetActive(false);
        EndGameState.SetActive(true);

        if (didAiWin)
        {
            WinTxt.SetActive(false);
            LooseTxt.SetActive(true);
        }
        else
        {
            WinTxt.SetActive(true);
            LooseTxt.SetActive(false);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;

        Canvas.SetActive(true);
        EndGameState.SetActive(false);

        scoreController.ResetScores();
        puckScript.CenterPuck();
        playerController.ResetPosition();
        BlueController.ResetPosition();
    }
}