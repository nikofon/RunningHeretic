using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class TorchMovementAndColout : MonoBehaviour
{
    private float prevFrequency = 1f;
    public FilmGrain filmGrain;
    private Vector3 offset;
    public Volume volume;
    private Collider2D col;
    public Material myMaterial;
    private float startingDistance;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0.5f, 0.8f, -0.1f);
        startingDistance = Target.instance.ReturnDistance();
        volume = GameObject.FindObjectOfType<Volume>();
        volume.profile.TryGet<FilmGrain>(out filmGrain);
        myMaterial.SetFloat("_Multiplier", Mathf.Clamp((startingDistance - Target.instance.ReturnDistance()) / startingDistance * 20, 1f, 20));
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
            myMaterial.SetFloat("_Multiplier", Mathf.Clamp((startingDistance - Target.instance.ReturnDistance()) / startingDistance * 20, 1f, 20));
            prevFrequency = (startingDistance - Target.instance.ReturnDistance()) / startingDistance * 20;
            AudioManager.instance.torchfrequency = Mathf.Clamp((startingDistance - Target.instance.ReturnDistance()) / startingDistance * 20, 1f, 20);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Enemy")
        {
            StopCoroutine("ChangeIntensityWithTime");
            Debug.Log("colided");
            filmGrain.intensity.value = 1f;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(ChangeIntensityWithTime(1f, 0, 0.6f));
        }
    }
    private IEnumerator ChangeIntensityWithTime(float from, float to, float time)
    {
        float delta = (from - to) / 50;
        for(int i = 0; i < 50; i++)
        {
            filmGrain.intensity.value -= delta;
            yield return new WaitForSeconds(time / 50);
        }
        yield break;
    }



}
