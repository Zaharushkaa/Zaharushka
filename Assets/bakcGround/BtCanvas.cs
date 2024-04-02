using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtCanvas : MonoBehaviour
{
    public void Exit()
    {
        SceneManager.LoadScene("menu");
    }
}
