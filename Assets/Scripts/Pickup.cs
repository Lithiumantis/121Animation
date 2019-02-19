using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pickup : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;
    public AudioSource audioplayer;
    // Start is called before the first frame update
    void Start()
    {
        audioplayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Pickup")
        {
            score++;
            audioplayer.Play();
            scoreText.text = "Score: " + score;
            Debug.Log("Hit pickup");
            Destroy(other.gameObject);

            if(score >= 5)
            {
                StartCoroutine(Delay());
            }
        }
    }

    IEnumerator Delay()
    {
        scoreText.text = "You win! Returning to menu...";
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("MainMenu");
    }
}
