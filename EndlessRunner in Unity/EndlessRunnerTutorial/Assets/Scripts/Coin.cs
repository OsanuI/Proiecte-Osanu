using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Coin : MonoBehaviour {

    [SerializeField] float turnSpeed = 90f;

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null) {
            Destroy(gameObject);
            return;
        }

        // verifica daca obstacolul intra in coliziune cu jucatorul
        if (other.gameObject.name != "Player2") {
            return;
        }

        // Adaugarea scorului 
        GameManager.inst.IncrementScore();

        // distrugerea banutilor dupa obtinere
        
        
        Destroy(gameObject);
        
    }

    private void Start () {

	}

	private void Update () {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
	}
}