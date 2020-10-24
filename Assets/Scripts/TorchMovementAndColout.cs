using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchMovementAndColout : MonoBehaviour
{
    private Vector3 offset;
    public Material myMaterial;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0.5f, 0.8f, -0.1f);
        
    }
    private void Update()
    {
        myMaterial.SetFloat("_Multiplier", 1f);
        if (PlayerMovement.instance.move.sqrMagnitude < 0.01f)
        {
            transform.position = PlayerMovement.instance.transform.position + offset;
        }
        else
        {
            transform.position = PlayerMovement.instance.transform.position + (Vector3) PlayerMovement.instance.move +0.1f* Vector3.back;
        }
    }


}
