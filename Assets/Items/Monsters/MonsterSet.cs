
[System.Serializable]
public class MonsterSet
{
    public Monster monster;
    public int monsterCount;
    public MonsterSet(Monster mn, int num)
    {
        monster = mn;
        monsterCount = num;
    }
}