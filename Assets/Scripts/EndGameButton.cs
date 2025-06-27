using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameButton : MonoBehaviour
{
    //reload game
    public void EndGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
