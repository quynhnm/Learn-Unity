using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeController : MonoBehaviour {

    private int score;
	public Text countText;
    public Text winText;

    public GameObject spawnItem;

    void Start()
    {
        print(gameObject.name);
        winText.text = "";
        SetCountText();
  //      spawnItem = transform.gameObject.GetComponent<Hitbox>();
    }

    public void ChangeVRmode(){
		Application.LoadLevel ("RollaBall");
	}

	public void ChangeNormalMode(){
		StartCoroutine ("Change");
	}

	IEnumerator Change(){
		yield return new WaitForSeconds (3.0f);
		Application.LoadLevel ("RollaBall_normal");
	}

	public void StopChange(){
		StopCoroutine ("Change");
	}

    public void SetCountText()
    {
        Hitbox hitCheck = GetComponent<Hitbox>();
        score = Hitbox.count;
        Debug.Log("" + score);
        countText.text = "Count: " + score.ToString();
        if (score >= 10)
        {
            winText.text = "You Win!";
        }
    }

    public void Spawn()
    {
        StartCoroutine(TimetoSpawn( spawnItem));
    }

    IEnumerator TimetoSpawn(GameObject item)
    {
        yield return new WaitForSeconds(2.0f);

        item.SetActive(true);
    }


}
