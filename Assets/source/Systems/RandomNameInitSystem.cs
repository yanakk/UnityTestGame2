using Entitas;
using System.Collections;
using UnityEngine;
using System.Text;

public sealed class RandomNameInitSystem : IInitializeSystem
{
    readonly GameContext _context;
    string[] _db_FNames;
    string[] _db_GNamesM;
    string[] _db_GNamesF;
    int _name_count;

    public RandomNameInitSystem(Contexts contexts, int name_count)
    {
        _context = contexts.game;
        _name_count = name_count;
    }

    public void Initialize()
    {
        TextAsset odb_FNames = Resources.Load("family_names") as TextAsset;
        TextAsset odb_GNamesM = Resources.Load("given_names_m") as TextAsset;
        TextAsset odb_GNamesF = Resources.Load("given_names_f") as TextAsset;
        _db_FNames = odb_FNames.text.Replace("\r", "").Split('\n');
        _db_GNamesM = odb_GNamesM.text.Replace("\r", "").Split('\n');
        _db_GNamesF = odb_GNamesF.text.Replace("\r", "").Split('\n');

        for (int j = 1; j < _name_count + 1; j++)
        {
            var CharacterEntity = _context.CreateEntity();   // 创建随机角色
            CharacterEntity.AddCharacterIndex(j);
            int temp_gender = Random.Range(0, 2); // 0-male 1-female
            if (temp_gender == 0)
            {
                CharacterEntity.AddCharacterName(_db_FNames[Random.Range(0, _db_FNames.Length)], _db_GNamesM[Random.Range(0, _db_GNamesM.Length)]);
            }
            else
            {
                CharacterEntity.AddCharacterName(_db_FNames[Random.Range(0, _db_FNames.Length)], _db_GNamesF[Random.Range(0, _db_GNamesF.Length)]);
            }
            CharacterEntity.AddCharacterGender(temp_gender);
        }
    }
}