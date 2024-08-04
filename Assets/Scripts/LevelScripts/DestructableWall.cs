using UnityEngine;

public class DestructableWall : MonoBehaviour
{

    public float wallHealth = 50f;

    public void WallTakeDamage(float amount)
    {
        wallHealth -= amount;
        if(wallHealth <= 0f)
        {
            DestroyWall();
        }
    }

    void DestroyWall()
    {
        //play particle effect and/or sfx
        Destroy(gameObject);
    }

}
