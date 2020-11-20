using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popUpDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    public void DestroyNow()
    {
        Destroy(this.gameObject);
    }
}
