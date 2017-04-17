using System.Collections.Generic;

public interface IPlugin<T>
{
    bool Add();
    bool DeleteById(int id);
    List<T> All();

    T CreateById(int id);

}