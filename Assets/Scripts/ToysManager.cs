using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;

public class ToysManager : MonoBehaviour {

    [SerializeField] private int CreateToyStep;
    [SerializeField] private ToysCollection _originalToyData;
    [SerializeField] private ToysCollection _toyData;
    [SerializeField] private ToyData _toy;

    [SerializeField] private List<ToyPart> ToyPartsOnShelf; //части игрушки на полке
    [SerializeField] private List<Toy> ToysOnShelf; //игрушки на полке

    [SerializeField] private List<Vector3> ToyFinalPositoin;


    public void StartNewGame() {
        _toyData = null;
        _toy.ToyPrefab = null;
        _toy.ToyParts = null;
        CreateToyStep = 0;
        ClearToysOnShelf();
        ClearToyPartsOnShelf();

        _toyData = Instantiate(_originalToyData);
        _toy = ChooseToy();
    }


    private ToyData ChooseToy() {
        ToyData currentToysData;
        if (_toyData.Toys.Any<ToyData>()) {
            int index = Random.Range(0, _toyData.Toys.Count);
            currentToysData = _toyData.Toys[index];
            _toyData.Toys.RemoveAt(index);
            return currentToysData;
        }
        else {
            currentToysData.ToyPrefab = null;
            currentToysData.ToyParts = null;
        }
        return currentToysData;

    }


    //шаги сборки игрушки
    public void AssemblyToy(Vector3 spawnToy) {
        if (_toy.ToyPrefab == null) return;
        if (CreateToyStep < 3) {
            CreateToysPart(_toy.ToyParts[CreateToyStep], spawnToy);
        }
        else if (CreateToyStep == 3) {
            CreateToy(_toy.ToyPrefab, spawnToy);
        }
        else {
            CreateToyStep = 0;
        }

    }

    //создаю часть игрушки
    public void CreateToysPart(ToyPart toyPrefab, Vector3 spawnToy) {
        ToyPart newToysPart = Instantiate(toyPrefab, spawnToy, Quaternion.identity, transform);
        newToysPart.ToysPartAnimation(ToyFinalPositoin[CreateToyStep]);
        ToyPartsOnShelf.Add(newToysPart);
        CreateToyStep++;
    }

    //создаю игрушку
    public void CreateToy(Toy toyPrefab, Vector3 spawnToy) {
        ClearToyPartsOnShelf(); //убираю части игрушки с полки

        Toy newToy = Instantiate(toyPrefab, spawnToy, Quaternion.identity, transform);
        newToy.ToyAnimation();
        ToysOnShelf.Add(newToy); //добавляю игрушку на полку

        _toy = ChooseToy(); //выбираю новую игрушку
        CreateToyStep = 0;
    }


    private void ClearToyPartsOnShelf() {
        for (int i = 0; i < ToyPartsOnShelf.Count; i++) {            
            ToyPartsOnShelf[i].Die();
        }
        ToyPartsOnShelf.Clear();
    }

    private void ClearToysOnShelf() {
        for (int i = 0; i < ToysOnShelf.Count; i++) {
            ToysOnShelf[i].Die();
        }
        ToysOnShelf.Clear();
    }
}
