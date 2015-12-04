using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public GameObject target;
    public GameObject creator;
    private float speed = 10f;
    public int firePower = 0;
    public int range = 0;

    Vector3 startPosition;
    Vector3 direction;
    void Start()
    {
        startPosition = gameObject.transform.position;
        direction = (target.transform.position - startPosition).normalized;
    }

    void Update()
    {
        gameObject.transform.position += direction * Time.deltaTime * speed;
        if ((gameObject.transform.position - startPosition).magnitude > range)
            Destroy(gameObject);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != creator && other.gameObject.tag != "bullet")
        {
            Destroy(gameObject);
        }
    }
    
}
