using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movecam : MonoBehaviour
{
    //Transform cameraPosition;
    public float sensx, sensy, xRotation, yRotation;
    public GameObject gameobj;
    // Start is called before the first frame update
    void Start()
    {
        /*gameobj = GameObject.Find("Capsule");*/
        GameObject gameobj = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = cameraPosition.position;
        float mousex = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensx;
        float mousey = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensy;
        yRotation += mousex;
        xRotation -= mousey;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        Vector3 posi = gameobj.transform.position;
        Debug.Log("Awake:" + SceneManager.GetActiveScene().name);
/*        if (SceneManager.GetActiveScene().name == "classroom")*/
        { posi.y += 0.64f;}
        transform.position = posi;
    }
}