using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    public Renderer PillarRender;
    public Dynamite D_script;
    private AudioManager audioManager;
    [SerializeField] private AudioClip explodeClip;
    [SerializeField] private ParticleSystem explodingParticles = default;

    // Start is called before the first frame update
    private void Start()
    {
        PillarRender = GetComponent<Renderer>();
        PillarRender.enabled = true;
        audioManager = AudioManager.instance;
    }

    public void Plant()
    {
        audioManager.PlaySfx(explodeClip);
        D_script.Explode();
        StartCoroutine(Delay());
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        D_script.Explode();
    //        StartCoroutine(Delay());
    //    }
    //}

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(6);
        explodingParticles.Play();
        PillarRender.enabled = false;
        this.GetComponent<BoxCollider2D>().enabled = false;
        Destroy(gameObject);
    }
}
