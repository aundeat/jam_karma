using UnityEngine;
using System.Collections;


public class SoundSearcher : MonoBehaviour
{
    public string audioFilePath; // ���� � ��������� ����� (������ ���� ��� ������������� ���� �� Assets �����)
    public float searchInterval = 5f; // �������� ������ ����� (� ��������)

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
            soundPlayer.Play(); // ��������������� �����
            yield return new WaitForSeconds(searchInterval);
        }
    }
}
