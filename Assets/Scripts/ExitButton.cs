using System.Collections;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    [SerializeField] private GameObject blackScreen;
    public void ExitApplication()
    {
        StartCoroutine(ExitRoutine());
    }

    private IEnumerator ExitRoutine()
    {
        yield return blackScreen.GetComponent<FadingEffect>().StartCoroutine(blackScreen.GetComponent<FadingEffect>().FadingIn());

        Debug.Log("Quit");
        Application.Quit();
    }
}
