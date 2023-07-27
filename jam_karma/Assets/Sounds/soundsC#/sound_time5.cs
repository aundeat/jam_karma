using UnityEngine;
using System.Collections;


public class SoundSearcher : MonoBehaviour
{
    public string audioFilePath; // Путь к звуковому файлу (полный путь или относительный путь от Assets папки)
    public float searchInterval = 5f; // Интервал поиска звука (в секундах)

    public AudioSource soundPlayer;
    private Coroutine searchCoroutine;

    private void Start()
    {
        //soundPlayer = new SoundPlayer(audioFilePath);
        StartSearch();
    }

    private void OnDestroy()
    {
        StopSearch();
    }

    private void StartSearch()
    {
        if (searchCoroutine == null)
        {
            searchCoroutine = StartCoroutine(SearchSoundRoutine());
        }
    }

    private void StopSearch()
    {
        if (searchCoroutine != null)
        {
            StopCoroutine(searchCoroutine);
            searchCoroutine = null;
        }
    }

    private IEnumerator SearchSoundRoutine()
    {
        while (true)
        {
            searchInterval = Random.Range(1,4);
            soundPlayer.Play(); // Воспроизведение звука
            yield return new WaitForSeconds(searchInterval);
        }
    }
}
