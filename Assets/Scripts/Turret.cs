using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turret : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _instantiationPoint; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject projectile = Instantiate(_bullet, _instantiationPoint.transform.position, _instantiationPoint.transform.rotation);
            projectile.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(-500, 0, 0));
        }*/
        /*if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(0, 15, 0);
        }*/
    }


    public void TurnToLeft()
    {
        transform.Rotate(0, -15, 0);
    }

    public void TurnToRight()
    {
        transform.Rotate(0, 15, 0);
    }

    public void Shoot()
    {
        GameObject projectile = Instantiate(_bullet, _instantiationPoint.transform.position, _instantiationPoint.transform.rotation);
        projectile.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(-500, 0, 0));
    }
}
