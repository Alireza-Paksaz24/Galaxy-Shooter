using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int _speed = 15;

    [SerializeField] private GameObject _Lizer;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_Lizer, this.transform.position,Quaternion.identity);
        }
    }
    
    //move function for player
    void MovePlayer()
    {
        var vector = new Vector3(0, 0, 0);
        //<Study>
        //GetAxis, is a method from Input class that return 0 till 1 float number that shows how much 
        //player press the button.
        //GetKey, is a method that return boolean, shows if player press the key or not.
        //</Study>
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        if (horizontal > 0.0f)
        {
            vector.x = _speed * horizontal *Time.deltaTime;
        }
        else if (horizontal < 0.0f)
        {
            vector.x = _speed * horizontal *Time.deltaTime;
        }

        if (vertical > 0.0f)
        {
            vector.y = _speed * vertical *Time.deltaTime;
        }
        else if (vertical < 0.0f)
        {
            vector.y = _speed * vertical *Time.deltaTime;
        }

        this.transform.Translate(vector);
    }
}
