using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 move;
    Animator am;
    private float stepTime;
    Rigidbody2D player;
    public static PlayerMovement instance;
    public float movespeed;
    public List<Vector3> inquisitorsPosition = new List<Vector3>();
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Enemy[] es = FindObjectsOfType<Enemy>();
        foreach (Enemy e in es)
        {
            inquisitorsPosition.Add(e.transform.position);
        }
        player = GetComponent<Rigidbody2D>();
        am = GetComponent<Animator>();
        AudioManager.instance.CreateTorch();
        InvokeRepeating("InvokableCallMusic", 0, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
        if(move.sqrMagnitude > 0.01)
        {
            am.Play("PlayerWalking");
        }
        else { am.Play("playerIdle"); }
    }
    public void InvokableCallMusic()
    {
        Enemy[] es = FindObjectsOfType<Enemy>();
        inquisitorsPosition.Clear();
        foreach (Enemy e in es)
        {
            inquisitorsPosition.Add(e.transform.position);
        }
        AudioManager.instance.PlayDynamicMusic(ClosestEnemy());
    }
    private void FixedUpdate()
    {
        player.MovePosition(player.position + movespeed * move);
        if(move.sqrMagnitude > 0.01f && Time.time > stepTime)
        {
            AudioManager.instance.PlaySound("Step");
            stepTime = Time.time + 0.5f;
        }
    }
    public float ClosestEnemy()
    {
        float[] distances = new float[inquisitorsPosition.Count];
        for(int i = 0; i < inquisitorsPosition.Count; i++)
        {
            distances[i] = Vector3.Distance(inquisitorsPosition[i], transform.position);
            Debug.Log(distances[i]);
        }
        return distances.Min();
    }
    private void OnDrawGizmosSelected()
    {
        foreach(float f in AudioManager.instance.proximityValues)
        {
            Gizmos.DrawWireSphere(transform.position, f);
        }
    }
}
