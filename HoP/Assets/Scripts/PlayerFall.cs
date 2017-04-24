using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerFall : MonoBehaviour
{
    public GameObject player;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y+25 < player.transform.position.y)
        {
            transform.position = new Vector3(0, player.transform.position.y - 25, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("GroundCheck"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
