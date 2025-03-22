using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharactersContainer", menuName = "Scriptable Objects/CharactersContainer")]
public class CharactersContainer : ScriptableObject
{
    public List<CharacterResource> Characters;
}
