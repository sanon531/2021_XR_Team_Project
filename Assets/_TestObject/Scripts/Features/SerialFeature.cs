using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _TestObject
{
    /// <summary>
    /// Defect일시 SerialText가 이상
    /// </summary>
    public class SerialFeature : TestObjectFeature
    {
        private enum TrophyType
        {
            Gold,
            Silver,
            Bronze
        }
        private static readonly string[] SerialType = {"G", "S", "B"};
        [SerializeField] private TrophyType type;
        [SerializeField] private TextMeshPro textMesh;
        private const int MinYear = 2010;
        protected override void OnNormal()
        {
            textMesh.text = GetSerialType() +"_"+ GetYear();
        }
        
        protected override void OnDefect()
        {
            if (Random.Range(0, 2) == 0)
            {
                textMesh.text = GetWrongSerialType() +"_"+ GetYear();
            }
            else
            {
                textMesh.text = GetSerialType() +"_"+ GetWrongYear();
            }
        }

        private string GetSerialType()
        {
            return SerialType[(int)type];
        }
        private string GetWrongSerialType()
        {
            return SerialType[((int)type + 1)%3];
        }
        private string GetYear()
        {
            return type == TrophyType.Silver ? (MinYear + Random.Range(0, 6) * 2).ToString() : (MinYear + Random.Range(1, 5) * 2).ToString();
        }
        private string GetWrongYear()
        {
            return (MinYear + Random.Range(0, 6) * 2 -1).ToString();
        }
    }
}