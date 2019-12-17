using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public float initialZ;
    public Transform player;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        initialZ = player.position.z;
    }



    // Update is called once per frame
    void Update()
    {
        scoreText.text = (player.position.z - initialZ).ToString("0");
    }
}
