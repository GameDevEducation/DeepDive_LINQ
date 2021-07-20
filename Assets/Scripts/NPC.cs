using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] float CurrentHP;

    public float CurrentHealth => CurrentHP;

    void Awake()
    {
        CurrentHP = Random.Range(20f, 100f);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
