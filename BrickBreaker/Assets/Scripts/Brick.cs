using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public AudioClip crack;
    public static int brickCount =0;
    public int timesHit;
    public Sprite[] hitsSprites;
    public GameObject smoke;
    private LevelManagerScript levelManager;
    private bool isBreakable;
    private ParticleSystem ps;
    // Use this for initialization
    void Start () {
        ps = GetComponent<ParticleSystem>();
        isBreakable = (this.tag == "Breakable");
        // Keep track of breakable bricks
        if (isBreakable)
        {
            brickCount++;
        }
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManagerScript>();
    }
	
	// Update is called once per frame
	void Update () {
        var main = ps.main;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position);
        if (isBreakable)
        {
            handleHits();
        }
        
    }

    void handleHits()
    {
        timesHit++;
        int maxHits = hitsSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            brickCount--;
            levelManager.BrickDestroyed();
            PuffSmoke();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }


    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitsSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitsSprites[spriteIndex];
        }
        else
        {
            Debug.Log("Sprite Missing");
        }
        
    }

    void PuffSmoke()
    {
        var smokePuff = Instantiate(smoke, transform.position, Quaternion.identity);
        var effect = smokePuff.GetComponent<ParticleSystem>().main;
        effect.startColor = GetComponent<SpriteRenderer>().color;
    }
}
