using UnityEngine;
using Random = UnityEngine.Random;

public class PowerUps : MonoBehaviour
{

    private float _speed = 3.0f;

    // Start is called in first frame
    private void Start()
    {
        this.transform.position = new Vector3(Random.Range(-9.5f, 9.5f), 7, 0);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y < -6)
            Destroy(this.gameObject);
    }
    
    // OnTrigerEnter method. if player enter, Power up will be activated
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
            if (this.tag == "PowerUp_TripleShot" && other.tag == "Player")
            {
                other.GetComponent<Player>().SetTripleShot(true);
            }
            else if (this.tag == "PowerUp_Speed" && other.tag == "Player")
            {
                other.GetComponent<Player>().SetSpeedUp(true);
            }
            else if (this.tag == "PowerUP_Shield")
            {
                other.GetComponent<Player>().SetShield(true);
            }
            Destroy(this.gameObject, 0.1f);
        }
    }
}