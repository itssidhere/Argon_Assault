using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    

    void Awake()
    {
        DontDestroyOnLoad(gameObject); 
    }
    void Start()
    {
        
        Invoke("StartGame", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartGame() {
        SceneManager.LoadScene(1);
    }

}
