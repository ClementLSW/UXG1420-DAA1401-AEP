using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dynamite : MonoBehaviour
{
    [SerializeField] private SpriteRenderer DynamiteRender;
    [SerializeField] private ParticleSystem explodingParticles = default;
    [SerializeField] private ParticleSystem assistingParticles = default;
    [SerializeField] private Animator animator;
    [SerializeField] private Sprite dynamiteSprite;
    [SerializeField] private GameObject pillar;
    private float t = 5;

    public void PlantDynamite()
    {
        Debug.Log("Bomb has been planted");
        DynamiteRender.sprite = dynamiteSprite;
        StartCoroutine(CountdownTimer());
    }

    IEnumerator CountdownTimer()
    {
        Debug.Log("Time start");
        while (t > 0) {
            t -= Time.deltaTime;
            yield return null;
        }
        Debug.Log("Time End");
        Detonate();
        //DynamiteRender.enabled = false;
    }

    private void Detonate() {
        Debug.Log("Detonate!");
        explodingParticles.Play();
        assistingParticles.Play();
        animator.SetTrigger("Explode");
        Destroy(pillar);
        //yield return new WaitForSeconds(0.5f);
        DynamiteRender.sprite = null;

    }
}
