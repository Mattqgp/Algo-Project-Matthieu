using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullets : MonoBehaviour
{
    public GameObject Bullet;
    public Transform ShootStart;
    public Transform Camera;

    public int damage = 40;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(Bullet, ShootStart.position, Camera.rotation);

            BulletMove bulletScript = bullet.GetComponent<BulletMove>();

            bulletScript.damage = damage;
        }
    }
}
