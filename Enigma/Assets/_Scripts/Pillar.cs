using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    public Renderer PillarRender;
    public Dynamite dynamite;
    //public Explosion E_script;
    private AudioManager audioManager;
    bool interacted = false;
    [SerializeField] private AudioClip explodeClip;

    // Start is called before the first frame update
    private void Start()
    {
        PillarRender = GetComponent<Renderer>();
        PillarRender.enabled = true;
        audioManager = AudioManager.instance;
    }

    public void Plant()
    {
        Debug.Log("start : " + interacted );
        if (interacted == false)
        {
            audioManager.PlaySfx(explodeClip);
            dynamite.PlantDynamite();
            //E_script.Explode();
            //StartCoroutine(Delay());
            interacted = true;
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        D_script.Explode();
    //        StartCoroutine(Delay());
    //    }
    //}

    //IEnumerator Delay()
    //{
    //    yield return new WaitForSeconds(5);
    //    PillarRender.enabled = false;
    //    this.GetComponent<BoxCollider2D>().enabled = false;
    //    Destroy(gameObject);
    //}
}
