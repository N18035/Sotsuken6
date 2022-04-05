using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attachmp3 : MonoBehaviour
{
    //パスをもらって、audiosourceにつける

    public AudioImporter importer;
    public AudioSource audioSource;

    [SerializeField] InputField IF;

    public void OnFileSelected()
    {
        string path = IF.text;
        Destroy(audioSource.clip);

        StartCoroutine(Import(path));
    }

    IEnumerator Import(string path)
    {
        importer.Import(path);

        while (!importer.isInitialized && !importer.isError)
            yield return null;

        if (importer.isError)
            Debug.LogError(importer.error);

        audioSource.clip = importer.audioClip;
    }
}
