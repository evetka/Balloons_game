using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ToysManager : MonoBehaviour {
    [SerializeField] private ProgressManager _progressManager;
    [SerializeField] private int CreateToyStep; //���� �������� �������
    [SerializeField] private ToysCollection _originalToyData; //�������� ToysCollection
    [SerializeField] private ToysCollection _copyToyData; //����� ToysCollection
    [SerializeField] private ToyData _currentToy; //���������� ������ �������
        
    [SerializeField] private List<Toy> ToysOnShelf; //������� �� �����

    [SerializeField] private Vector3 _toyPrintFinishPosition; //��, ���� ������� ������ �� �����
    [SerializeField] private ParticleSystem _toyCreateEffect;

    [SerializeField] private ToyPrint _toyPrint; //������ �������
    [SerializeField] private ClayModel _toyClayModel; //���������, ������� � ������ �� ������
    [SerializeField] private ToyModel _toyModel; //�������� ������� ��� �����
    [SerializeField] private PaintTool _paintTool; //������
        

    public void StartNewGame() {
        ClearToysOnShelf();
        _toyClayModel.Init(this);
        _paintTool.Init(this);

        _copyToyData = null;
        _copyToyData = Instantiate(_originalToyData);

        CreateToyStep = 0;
        _toyPrint.gameObject.SetActive(false);
        _toyClayModel.gameObject.SetActive(false);
        _paintTool.gameObject.SetActive(false);
        if (_toyModel != null) {
            _toyModel.Die();
            _toyModel = null;
        }

        _currentToy = ChooseToy();
    }


    private ToyData ChooseToy() {
        ToyData currentToysData;
        if (_copyToyData.Toys.Any<ToyData>()) {
            int index = Random.Range(0, _copyToyData.Toys.Count);
            currentToysData = _copyToyData.Toys[index];
            _copyToyData.Toys.RemoveAt(index);
            return currentToysData;
        }
        else {            
            currentToysData.ToyPrint = null;
            currentToysData.ToyModel = null;            
            currentToysData.FinishToy = null;
        }
        return currentToysData;

    }


    //���� ������ �������
    public void AssemblyToy(Vector3 spawnToy) {
        if (_currentToy.ToyPrint == null) return;

        if (CreateToyStep == 0) {            
            CreateToyPrint(spawnToy);
        }
        else if (CreateToyStep == 1) {            
            CreateClayModel(spawnToy);
        }
        else if (CreateToyStep == 2) {
            CreatePaintTool(spawnToy);
        }        
        else {
            CreateToyStep = 0;
        }
        
    }

    //������ ����� � ����� ���������� ������
    public void CreateToyPrint(Vector3 spawnToy) {
        _toyPrint.Init(_currentToy.ToyPrint, spawnToy);
        Instantiate(_toyCreateEffect, spawnToy, Quaternion.identity);
        _toyPrint.gameObject.SetActive(true);
        _toyPrint.ToyModelAnimation(_toyPrintFinishPosition);        
        CreateToyStep++;
    }

    public void CreateClayModel(Vector3 spawnToy) {
        Instantiate(_toyCreateEffect, spawnToy, Quaternion.identity);
        _toyClayModel.gameObject.SetActive(true);
        _toyClayModel.ClayModelAnimation(spawnToy, _toyPrint.transform.position);        
    }


    public void CreateModelToy() {
        _toyModel = null;
        Instantiate(_toyCreateEffect, _toyClayModel.transform.position, Quaternion.identity);
        _toyModel = Instantiate(_currentToy.ToyModel, _toyClayModel.transform.position, Quaternion.identity, transform);
        _toyModel.ToyModelAnimation(transform.position);
        _toyPrint.Die();
        CreateToyStep++;
    }

    public void CreatePaintTool(Vector3 spawnToy) {
        Instantiate(_toyCreateEffect, spawnToy, Quaternion.identity);
        _paintTool.gameObject.SetActive(true);
        _paintTool.PaintToolAnimation(spawnToy, transform.position);
    }

    public void CreatefinishToy() {        
        _toyModel.Die();
        _toyModel = null;

        Instantiate(_toyCreateEffect, _paintTool.transform.position, Quaternion.identity);
        Toy newFinishtoy = Instantiate(_currentToy.FinishToy, _paintTool.transform.position, Quaternion.identity, transform);

        ToysOnShelf.Add(newFinishtoy);
        _progressManager.AddToyScore(ToysOnShelf.Count);

        newFinishtoy.ToyAnimation();
        _currentToy = ChooseToy(); //������� ����� �������
        CreateToyStep = 0;
    }
    


    private void ClearToysOnShelf() {
        for (int i = 0; i < ToysOnShelf.Count; i++) {
            ToysOnShelf[i].Die();
        }
        ToysOnShelf.Clear();
    }
}
