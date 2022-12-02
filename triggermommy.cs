using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class triggermommy : MonoBehaviour
{
    public Canvas Pcanvas;
    int Enterb = 0;
    public GameObject gameobj;
    // Start is called before the first frame update
    // Update is called once per frame
    void Start()
    {
        GameObject gameobj = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (Enterb == 1 && Input.GetKey(KeyCode.P))
        {
            if (SceneManager.GetActiveScene().name == "Non_Joint_individual_labs")
                SceneManager.LoadScene("corrido");
            else
            {
                PlayerData playerData = new PlayerData();
                playerData.position = gameobj.transform.position;
                string plpos = JsonUtility.ToJson(playerData);
                File.WriteAllText(Application.dataPath + "/possave.json", plpos);
                Debug.Log(plpos);
                SceneManager.LoadScene("Non_Joint_individual_labs");
            }
        }
    }
    private void OnTriggerEnter(Collider enterer)
    {
        Debug.Log("hello");
        if (enterer.tag == "Player")
        {
            Debug.Log("he is in the area");
            Pcanvas.enabled = true;
            Enterb = 1;
        }
        /*else
        {
            Pcanvas.enabled = false;
        }*/
    }
    private void OnTriggerExit(Collider enterer)
    {
        Debug.Log("bye");
        if (enterer.tag == "Player")
        {
            Debug.Log("he is out of the area");
            Pcanvas.enabled = false;
            Enterb = 0;
        }
        /*else
        {
            Pcanvas.enabled = false;
        }*/
    }
    private class PlayerData
    {
        public Vector3 position;
    }

}