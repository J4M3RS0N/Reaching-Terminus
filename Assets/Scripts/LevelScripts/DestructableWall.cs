using UnityEngine;

public class DestructableWall : MonoBehaviour
{

    public float wallHealth = 50f;
    public bool wallDead;

    public void WallTakeDamage(float amount)
    {
        wallHealth -= amount;
        if(wallHealth <= 0f)
        {
            wallDead = true;
            DestroyWall();
        }
    }

    void DestroyWall()
    {
        //play particle effect and/or sfx
        Destroy(gameObject);
    }

}
