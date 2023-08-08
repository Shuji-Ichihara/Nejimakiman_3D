using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public static Scene Instance;

    void Awake()
    {
        CheckInstance();
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (SceneManager.GetActiveScene().name == "Title")
            {
                SoundManager.Instance.PlaySE(SESoundData.SE.Start);
                SceneManager.LoadScene("Tutorial");
            }
            else if(SceneManager.GetActiveScene().name == "Tutorial")
            {
                SoundManager.Instance.PlaySE(SESoundData.SE.Start);
                SceneManager.LoadScene("PlayScene");
            }
            else if(SceneManager.GetActiveScene().name == "Clear" || SceneManager.GetActiveScene().name == "GameOver")
            {
                SoundManager.Instance.PlaySE(SESoundData.SE.Start);
                SceneManager.LoadScene("End");
            }
            else if(SceneManager.GetActiveScene().name == "End")
            {
                SoundManager.Instance.PlaySE(SESoundData.SE.Start);
                SceneManager.LoadScene("Title");
            }
        }

        if(Input.GetMouseButtonDown(1))
        {
            if (SceneManager.GetActiveScene().name == "PlayScene")
            {
                SoundManager.Instance.PlaySE(SESoundData.SE.Start);
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    void CheckInstance()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
