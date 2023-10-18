using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ShowPrompt : MonoBehaviour
{
    public GameObject spawnLocation;
    public GameObject objectToSpawn;
    public GameObject uiObject;
    bool _CanGetSoda = false;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        SetState(false);
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (_CanGetSoda)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                //Spawn Soda
                Instantiate(objectToSpawn, spawnLocation.transform.position, spawnLocation.transform.rotation);
            }
        }
    }

    /// <summary>
    ///  On Enter - Enable system
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SetState(true);
        }
    }

    /// <summary>
    /// On Exit - Disable system
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SetState(false);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="enable"></param>
    private void SetState(bool enable)
    {
        if (uiObject != null)
        {
            _CanGetSoda = enable;
            uiObject.SetActive(enable);
        }
    }

}
