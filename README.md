EXAMPLE:
    //reference the pool
    
    private ObjectPool muzzleFlashPool;
    private void Awake()
    {
        //creates a new pool
        muzzleFlashPool = new GameObject(gunName + "_PlayerMuzzlePool").AddComponent<ObjectPool>();
        muzzleFlashPool.prefab = muzzleEffect;
        muzzleFlashPool.poolSize = gunAmmo;
    }    
    private void SpawnMuzzleFlash()
    {

        // Spawn muzzle effect
        if (muzzleEffect != null)
        {    
            //replace Instantiate with pool.GetObject();
            //GameObject go = Instantiate(muzzleEffect, firePoint.position, firePoint.rotation);
            GameObject go = muzzleFlashPool.GetObject();
            go.transform.position = firePoint.position; 
            go.transform.rotation = firePoint.rotation;
            go.transform.localScale = new Vector3(muzzleEffectSize, muzzleEffectSize, muzzleEffectSize);
        }

    }
