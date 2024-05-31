﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO_Pattern
{
    public interface IDAO <T>
    {
        public HashSet<T> GetAll();
        T GetValue(string abv);
        void Save(T value);
        void Update(string abreviacio, T updatedTeam);
        bool Delete(string id);
        int Count();
        double Promig();

    }
}