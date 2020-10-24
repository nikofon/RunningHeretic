using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchMovementAndColout : MonoBehaviour
{
    private float prevFrequency;
    private Vector3 offset;
    public Material myMaterial;
    private float startingDistance;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0.5f, 0.8f, -0.1f);
        startingDistance = Target.instance.ReturnDistance();
        
    }
    private void Update()
    {
        if (PlayerMovement.instance.move.sqrMagnitude < 0.01f)
        {
            transform.position = PlayerMovement.instance.transform.position + offset;
        }
        else
        {
            transform.position = PlayerMovement.instance.transform.position + (Vector3) PlayerMovement.instance.move +0.1f* Vector3.back;
        }
    }
    private void LateUpdate()
    {
        if (Mathf.Abs(prevFrequency - (startingDistance - Target.instance.ReturnDistance()) / startingDistance * 20) > 1)
        {
            Debug.Log((startingDistance - Target.instance.ReturnDistance()) / startingDistance * 20);
            myMaterial.SetFloat("_Multiplier", Mathf.Clamp((startingDistance - Target.instance.ReturnDistance()) / startingDistance * 20, 1f, 20));
            prevFrequency = (startingDistance - Target.instance.ReturnDistance()) / startingDistance * 20;
        }
    }


}
