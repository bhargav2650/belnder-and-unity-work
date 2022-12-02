using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
public class moveplayer : MonoBehaviour
{
    Rigidbody rb;
    public GameObject gameobj;
   /* private GameObject gobj;*/
    // Start is called before the first frame update
    public float sensx, sensy, yRotation;
    void Start()
    {
        Debug.Log("Hello  World");
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb.freezeRotation = true;
        gameobj = GameObject.Find("Main Camera");
        if (SceneManager.GetActiveScene().name == "corrido")
        {
            string posit = File.ReadAllText(Application.dataPath + "/possave.json");
            PlayerData data = JsonUtility.FromJson<PlayerData>(posit);
            Debug.Log("loaded:" + data.position);
            rb.transform.position = data.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velo = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.D)) velo.x = 2;
        if (Input.GetKey(KeyCode.A)) velo.x = -2;
        if (Input.GetKey(KeyCode.S)) velo.z = -2;
        if (Input.GetKey(KeyCode.W)) velo.z = 2;
        Vector3 velo2 = gameobj.transform.forward * velo.z + gameobj.transform.right * velo.x;
     /*   if (Input.GetKeyDown("space"))
        {
            rb.velocity = new Vector3(rb.velocity.x, 5, rb.velocity.z);
        }*/
    rb.velocity = velo2;
float mousex = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensx;
yRotation += mousex;
transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
    private class PlayerData
    {
        public Vector3 position;
    }
}