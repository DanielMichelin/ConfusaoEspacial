using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    public GameObject thing;
    // Start é chamado antes do primeiro frame dar update
    void Start() {
        Instantiate(thing, transform.position, Quaternion.identity);
    }

}
