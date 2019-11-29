using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTexts : MonoBehaviour
{
    public GameObject[] childs;

    IEnumerator ShowTutorial()
    {
        yield return new WaitForSeconds(5);

        childs[0].SetActive(true);

        for (int i = 1; i <= childs.Length; i++)
        {
            childs[i].SetActive(true);

            yield return new WaitForSeconds(18);

            childs[i].SetActive(false);
        }

        childs[0].SetActive(false);

        yield return null;
    }

    public void ShowTutorialTexts()
    {
        StartCoroutine(ShowTutorial());
    }
}
