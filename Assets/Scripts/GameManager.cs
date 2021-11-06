using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool IsPlay;
    [SerializeField] private GameObject winPanel;
    private List<GameObject> fires;
    private GameObject[] _fireWindow;

    private void Start()
    {
        IsPlay = true;

        _fireWindow = GameObject.FindGameObjectsWithTag("FireWindow");
        fires = new List<GameObject>(_fireWindow);

        for (int i = 0; i < _fireWindow.Length; i++)
        {
            int firesRange = Random.Range(0, _fireWindow.Length);
            _fireWindow[firesRange].SetActive(false);
            fires.Remove(_fireWindow[firesRange]);
        }
    }

    private void Update()
    {
        DestroyFireObject();

        if (fires.Count == 0)
        {
            IsPlay = false;
            winPanel.SetActive(true);
        }
    }

    private void DestroyFireObject()
    {
        for (int i = 0; i < fires.Count; i++)
        {
            int firesChildPos = 0;
            ParticleSystem _fireParticle = fires[i].transform.GetChild(firesChildPos).GetComponent<ParticleSystem>();

            if (_fireParticle.maxParticles == 0)
            {
                float destroyTime = 3;
                Destroy(fires[i], destroyTime);
                fires.Remove(fires[i]);
            }
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Game");
    }
}
