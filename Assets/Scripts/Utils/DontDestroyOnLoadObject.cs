using UnityEngine;
using System.Collections;

public class DontDestroyOnLoadObject : MonoBehaviour {
  void Awake() {
    DontDestroyOnLoad(gameObject);
  }
}
