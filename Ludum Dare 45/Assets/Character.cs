using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject lowSprite;
    public GameObject medSprite;
    public GameObject highSprite;

    public UnlockManager.GraphicsLevel gfx;
    // Start is called before the first frame update
    private void Start()
    {
        gfx = UnlockManager.Instance.Graphics;
    }

    // Update is called once per frame
    void Update()
    {
        if(gfx != UnlockManager.Instance.Graphics){
            gfx = UnlockManager.Instance.Graphics;
            switch(UnlockManager.Instance.Graphics){
                case UnlockManager.GraphicsLevel.Low:
                    lowSprite .SetActive(true);
                    medSprite .SetActive(false);
                    highSprite.SetActive(false);
                break;
                case UnlockManager.GraphicsLevel.Medium:
                    lowSprite .SetActive(false);
                    medSprite .SetActive(true);
                    highSprite.SetActive(false);
                break;
                case UnlockManager.GraphicsLevel.High:
                    lowSprite .SetActive(false);
                    medSprite .SetActive(false);
                    highSprite.SetActive(true);
                break;
            }
        }
    }
}
