using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class piececollector : MonoBehaviour
{
    // Start is called before the first frame update
    public int point = 0;
    public Text points;
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coins") 
        
        { 
            Destroy(collision.gameObject);
            point = point + 1;
            
        }
        points.text = point.ToString();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
