using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    private Level level;

    void Start(){
        level = FindObjectOfType<Level>();
        level.OnBlockInstantiated();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var ballSound = GetComponent<AudioSource>().clip;
        AudioSource.PlayClipAtPoint(ballSound, transform.position);
        level.OnBlockDestroyed();
        Destroy(gameObject);
    }
}
