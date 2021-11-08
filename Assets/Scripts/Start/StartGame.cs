using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Start
{
    public class StartGame : MonoBehaviour
    {
        [SerializeField] private GameObject[] textsGO;
        private const float fixedDuration = 5f;
        private int levelToLoad = 1;

        private void Start()
        {
            StartCoroutine(ShowStory());
            
        }

        private IEnumerator ShowStory()
        {
            foreach (var t in textsGO)
            {
                t.SetActive(true);
                yield return new WaitForSeconds(fixedDuration);
                t.SetActive(false);
            }
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
