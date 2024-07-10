﻿namespace NetCleanArchitecture.Application;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken= default);
}
