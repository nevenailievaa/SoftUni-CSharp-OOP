﻿namespace CustomRandomList;

public class RandomList : List<string>
{
    private Random random = new Random();
    public string RandomString()
    {
        int index = random.Next(0, this.Count);
        string removedValue = this[index];
        this.RemoveAt(index);
        return removedValue;
    }
}