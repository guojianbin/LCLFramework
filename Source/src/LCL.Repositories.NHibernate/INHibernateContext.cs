﻿using LCL;
using LCL.Domain.Entities;
using LCL.Domain.Repositories;
using LCL.Domain.Specifications;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LCL.Repositories.NHibernate
{
    /// <summary>
    /// Represents that the implemented classes are NHibernate contexts.
    /// </summary>
    public interface INHibernateContext : IRepositoryContext
    {
        #region Methods
        /// <summary>
        /// Gets the aggregate root instance from repository by a given key.
        /// </summary>
        /// <param name="key">The key of the aggregate root.</param>
        /// <returns>The instance of the aggregate root.</returns>
        TEntity Get<TEntity, TPrimaryKey>(TPrimaryKey id)
            where TEntity : class, IEntity<TPrimaryKey>;
        /// <summary>
        /// Finds all the aggregate roots from repository.
        /// </summary>
        /// <param name="specification">The specification with which the aggregate roots should match.</param>
        /// <param name="sortPredicate">The sort predicate which is used for sorting.</param>
        /// <param name="sortOrder">The <see cref="Apworks.Storage.SortOrder"/> enumeration which specifies the sort order.</param>
        /// <returns>The aggregate roots.</returns>
        IQueryable<TEntity> FindAll<TEntity, TPrimaryKey>(ISpecification<TEntity> specification, Expression<Func<TEntity, dynamic>> sortPredicate, SortOrder sortOrder)
            where TEntity : class, IEntity<TPrimaryKey>;
        /// <summary>
        /// Finds all the aggregate roots from repository.
        /// </summary>
        /// <param name="specification">The specification with which the aggregate roots should match.</param>
        /// <param name="sortPredicate">The sort predicate which is used for sorting.</param>
        /// <param name="sortOrder">The <see cref="Apworks.Storage.SortOrder"/> enumeration which specifies the sort order.</param>
        /// <param name="pageNumber">The number of objects per page.</param>
        /// <param name="pageSize">The number of objects per page.</param>
        /// <returns>The aggregate roots.</returns>
        PagedResult<TEntity> FindAll<TEntity, TPrimaryKey>(ISpecification<TEntity> specification, Expression<Func<TEntity, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize)
            where TEntity : class, IEntity<TPrimaryKey>;
        /// <summary>
        /// Finds a single aggregate root from the repository.
        /// </summary>
        /// <param name="specification">The specification with which the aggregate root should match.</param>
        /// <returns>The instance of the aggregate root.</returns>
        TEntity Find<TEntity, TPrimaryKey>(ISpecification<TEntity> specification)
            where TEntity : class, IEntity<TPrimaryKey>;

        #endregion
    }
}