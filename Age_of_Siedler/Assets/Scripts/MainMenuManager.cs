using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public AudioMixer mixer;
    private int mapSizeIndex;
    public GameObject[] mapSmall;
    public GameObject[] mapMedium;
    public GameObject[] mapLarge;
    public List<GameObject[]> listOfMaps;

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
        Debug.Log(mapSizeIndex);
        //Instantiate(listOfMaps[mapSizeIndex][Random.Range(0, listOfMaps[mapSizeIndex].Length)]);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
