using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class Bullets : MonoBehaviour
{
    public float lifeTime = 3.0f;

    //Boss Damage Logic
    public int damageAmount = 10;
    void Update()
    {
        if (lifeTime < 0.0f)
        {
            PoolManager.sharedInstance.ReturnObjToPool(this.gameObject);
            lifeTime = 3.0f;
        }

        lifeTime -= Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        BossHealth Bosshealth = other.GetComponent<BossHealth>();
        if (other.gameObject.name == "BossFire")
        {
            Bosshealth.TakeDamage(damageAmount);
        }
  //  else if (Bosshealth != null)
     //   {
            
  //      }
    
}
}