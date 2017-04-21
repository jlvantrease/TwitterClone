using System.Collections.Generic;

public interface IPlugin<T>
{
    bool Add(T u);
    bool DeleteById(int id);
    List<T> All();
    T UpdateById(int id);

}