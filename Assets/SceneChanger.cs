using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string SceneName;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKey(KeyCode.S))
        {
            SceneManager.LoadScene(SceneName);
        }

    }

    public void ChangeLevel(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
