using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamite : MonoBehaviour
{
    public Renderer DynamiteRender;
    [SerializeField] private ParticleSystem explodingParticles = default;
    [SerializeField] private ParticleSystem assistingParticles = default;
    // Start is called before the first frame update
    void Start()
    {
        DynamiteRender = GetComponent<Renderer>();
        DynamiteRender.enabled = false;
    }

    public void Explode()
    {
        Debug.Log("Bomb has been planted");
        DynamiteRender.enabled = true;
        StartCoroutine(CountdownTimer());
    }

    IEnumerator CountdownTimer()
    {
        Debug.Log("Time start");
        yield return new WaitForSeconds(5);
        explodingParticles.Play();
        assistingParticles.Play();
        Debug.Log("Time End");
        DynamiteRender.enabled = false;
    }
}
