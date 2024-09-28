using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageGun : MonoBehaviour
{
    public int Damage;
    public float BulletRange;
    [SerializeField] private float amountExtinguishedPS = .1f;

    private Transform PlayerCamera;

    // Start is called before the first frame update
    void Start()
    {
        PlayerCamera = Camera.main.transform;
    }

    public void Shoot()
    {
        Ray gunRay = new Ray(PlayerCamera.position, PlayerCamera.forward);
        if(Physics.Raycast(gunRay, out RaycastHit hitInfo, BulletRange))
        {
            if (hitInfo.collider.gameObject.CompareTag("Fire") && hitInfo.collider.TryGetComponent(out FireScript fire))
            {
                fire.TryExtinguish(amountExtinguishedPS);

                hitInfo.collider.gameObject.GetComponent<FireScript>().TakeDamage(1);
            }
        }
    }
}
