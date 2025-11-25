using UnityEngine;

public class Debugger : MonoBehaviour
{
    public string startMsg;
    [SerializeField]
    private string updateMsg = "jo";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(startMsg);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(updateMsg);
    }
}
