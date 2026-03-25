using System;
using System.Collections;
using System.Collections.Generic;

public  class LoopList<T>:IEnumerable
{
    private List<T> _revolvingStorage;
    private int _currentIndex;
    public LoopList()  
    {
        _revolvingStorage = new List<T>();
        _currentIndex = 0;
    }
    public LoopList(List<T> list,int importCurrentIndex=0)
    {
        //from list constructor
        _revolvingStorage=new List<T>(list);
        _currentIndex=importCurrentIndex;
    }
    public IEnumerator<T> GetEnumerator()
    {
        return _revolvingStorage.GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    public void Add(T thing)
    {
        _revolvingStorage.Add(thing);
    }
    public void Remove(T thing)
    {
        _revolvingStorage.Remove(thing);
    }
    public void RemoveAt(int yonder)
    {
        _revolvingStorage.RemoveAt(yonder);
    }
    public T here()
    {
        if(_revolvingStorage.Count<=0){throw new InvalidOperationException("Loop list empty, cannot return any value.");}
        return _revolvingStorage[_currentIndex];
    }
    private void MoveIndex(int pos)
    {
        _currentIndex = (_currentIndex + pos + _revolvingStorage.Count) % _revolvingStorage.Count;
    }
    public T leftRet()
    {
        if(_revolvingStorage.Count<=0){throw new InvalidOperationException("Loop list empty, cannot perform revolving operations.");}
        MoveIndex(-1);
        return _revolvingStorage[_currentIndex];
    }
    public T rightRet()
    {
        if(_revolvingStorage.Count<=0){throw new InvalidOperationException("Loop list empty, cannot perform revolving operations.");}
        MoveIndex(1);
        return _revolvingStorage[_currentIndex];
    }
}
