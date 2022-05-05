using System.Collections;
using UnityEngine;


public class Complete : MonoBehaviour
{
    public int Level;
    public ParticleSystem CompleteAnimet;
    ParticleSystem Anim;

    [Header("SOUND")]
    public AudioSource CompleteSound;

    private void Start()
    {
        Debug.Log(Level);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
           Anim= Instantiate(CompleteAnimet, transform.position, Quaternion.Euler(-90,0,0));
            StartCoroutine(CompleteParticle());
            StartCoroutine(CompleteSoundPlay(other.gameObject));
            //if (!PlayerPrefs.HasKey("StarValue" ))
            //{
            //    PlayerPrefs.SetInt("StarValue", 1);
            //}
            Debug.Log(Level);
        }
    }
    IEnumerator CompleteSoundPlay(GameObject @object)
    {
        CompleteSound.Play();
        yield return new WaitForSeconds(2.5f);
       

    }
    IEnumerator CompleteParticle()
    {
        Anim.Play();
        yield return new WaitForSeconds(3f);
        Anim.Stop();

    }
}
