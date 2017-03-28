﻿using DataAccess.Entities;

namespace DataAccess.Repositories.Interfaces
{
    public interface IIterationRepository : IRepository<Iteration>
    {
        void RemoveIterationById(int id);
    }
}
