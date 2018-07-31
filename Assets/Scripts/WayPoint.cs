using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour {

  private AudioSource audioSource;
  private bool played = false;
  public int index;
  public LineDataCopy lineData;

  [ContextMenu("Play")]
  public void Play()
  {
    if (!played)
    {
      audioSource.Play();
      played = true;
      lineData.ReachIndex(index);
    }
   
  }

	// Use this for initialization
	void Start () {
    audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
