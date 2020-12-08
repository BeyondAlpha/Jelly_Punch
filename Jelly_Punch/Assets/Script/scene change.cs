using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenechange : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    public void ChangeFirstScene()
    {
        SceneManager.LoadScene("TitleScene");
    }


    public void ChangeSecondScene()
    {
        SceneManager.LoadScene("Stage_scene");
    }
}
