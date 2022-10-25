﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices
{
    public interface ICanteenRepository
    {
        List<Canteen> GetAllCanteens();

        Canteen GetCanteenById(int id);

        Canteen AddCanteen(Canteen canteen);

        Canteen UpdateCanteen(Canteen canteen);

        void DeleteCanteen(Canteen canteen);
    }
}
