using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ToyData {
    public Toy ToyPrefab;
    public List<ToyPart> ToyParts;
}

[CreateAssetMenu]
public class ToysCollection : ScriptableObject {

    [SerializeField] public List<ToyData> Toys;
}


