using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sayac : MonoBehaviour
{
    public Text sayac;
    public float countDown = 3;
    // Start is called before the first frame update
    void Start()
    {
        StartCo();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public IEnumerator SayacCo()
    {
        for(int i =0;i<3;i++)
        {
            sayac.text = "" + countDown;
            yield return new WaitForSeconds(1f);
            countDown = countDown - 1;
        }
        sayac.text = "GO";
        yield return new WaitForSeconds(0.5f);
        if (countDown == 0)
        {
            sayac.gameObject.SetActive(false);
        }
    }
    public void StartCo()
    {
        StartCoroutine("SayacCo");
    }
}
