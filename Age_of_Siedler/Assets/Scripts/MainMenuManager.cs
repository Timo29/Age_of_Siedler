//Autor: Stöckmann Timo
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public int sceneIndex;
    public AudioMixer mixer;
    private int mapSizeIndex;
    public GameObject[] mapSmall;
    public GameObject[] mapMedium;
    public GameObject[] mapLarge;
    public List<GameObject[]> listOfMaps;

    public Canvas loadingCanvas;

    private void Awake()
    {
        //listOfMaps.Add(mapSmall);
        //listOfMaps.Add(mapMedium);
        //listOfMaps.Add(mapLarge);
    }

    public void SetVolume(float volume)
    {
        mixer.SetFloat("volume", volume);
    }

    public void SetMapSize(int mapSize)
    {
        mapSizeIndex = mapSize;
    }

    public void StartGame()
    {
        StartCoroutine(LoadSceneAsync(sceneIndex));
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator LoadSceneAsync (int sceneIn)
    {
        SceneManager.LoadScene(sceneIn, LoadSceneMode.Additive);
        yield return new WaitForSeconds(15f);
        SceneManager.UnloadSceneAsync(sceneIn - 1);

        yield return null;
    }
}
