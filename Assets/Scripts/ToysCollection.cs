using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ToyData {
    
    public Texture ToyPrint;
    public ToyModel ToyModel;    
    public Toy FinishToy;
        
}

[CreateAssetMenu]
public class ToysCollection : ScriptableObject {

    [SerializeField] public List<ToyData> Toys;
}


