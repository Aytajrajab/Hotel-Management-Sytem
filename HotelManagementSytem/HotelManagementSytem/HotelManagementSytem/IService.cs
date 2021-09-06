using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementSytem
{
    interface IService<T>
    {
        List<T> GetAll();
        T Get(int id);
        T Create(T model);
        T Update(T oldModel, T model);
        bool Delete(T model);
    }
}
