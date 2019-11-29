//Autor: Maximilian Dorn
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTexts : MonoBehaviour
{
    public GameObject[] childs;
    public GameObject tutorialText;

    IEnumerator ShowTutorial()
    {
        yield return new WaitForSeconds(5);

        tutorialText.SetActive(true);

        for (int i = 0; i < childs.Length; i++)
        {
            childs[i].SetActive(true);

            yield return new WaitForSeconds(18);

            childs[i].SetActive(false);
        }
        Debug.Log("I Am Here");
        tutorialText.SetActive(false);

        yield return null;
    }

    public void ShowTutorialTexts()
    {
        StartCoroutine(ShowTutorial());
    }
}
