
using UnityEngine;

public class MyCube : BaseBehaviour
{

    Rigidbody rigid;

    public int id;
    
    public void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }


    // Use this for initialization
    void Start()
    {
        Observer.AddListener(TestEvent.CHANGE_COLOR, this, ChangeColor);
    }

    private void ChangeColor(ObservParam obj)
    {
        if (id != 0)
        {
            GetComponent<Renderer>().material.color = new Color(Random.Range(0.0f, 1f), Random.Range(0.0f, 1f), Random.Range(0.0f, 1f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            Observer.SendMessage(TestEvent.CHANGE_COLOR);            
        }
    }

    public void Jump(ObservParam obj)
    {
        float param = (float)obj.data;
        rigid.AddForce(new Vector3(0, param, 0));
    }
}
