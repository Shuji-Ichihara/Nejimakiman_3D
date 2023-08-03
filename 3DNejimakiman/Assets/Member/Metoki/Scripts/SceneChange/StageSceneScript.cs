using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSceneScript : MonoBehaviour
{
    private float next_satge = 0f;
    private bool goal = false;

    void Start()
    {
        next_satge = 0;
        goal = false;
    }

    void Update()
    {
        if (goal)
        {
            next_satge += Time.deltaTime;
        }

        if (next_satge >= 3f)
        {
            SoundManager.Instance.PlaySE(SESoundData.SE.Start);
            SceneManager.LoadScene("PlaySceneTwo");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {           
            SoundManager.Instance.PlaySE(SESoundData.SE.Goal);
            goal = true;
        }
    }
}

