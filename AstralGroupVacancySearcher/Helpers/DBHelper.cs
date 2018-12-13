using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AstralGroupVacancySearcher.Helpers
{
    /// <summary>
    /// Класс для упрощения работы с EF
    /// </summary>
    public static class DBHelper
    {
        /// <summary>
        /// Обновляет состояние сущности в контексте базы данных
        /// </summary>
        /// <typeparam name="TEntity">Тип обновляемого значения</typeparam>
        /// <param name="context">Контекст БД, в котором нужно обноыить состояние</param>
        /// <param name="entity">Сущность EF</param>
        public static void UpdateEntityState<TEntity>(this DbContext context, TEntity entity) where TEntity : class
        {
            if (entity != null && !context.IsInChanges(entity))
            {
                DbSet<TEntity> dbSet = context.Set<TEntity>();
                try
                {
                    TEntity dbentity = dbSet.Find(GetKey(context, ref entity));
                    if (dbentity != null)
                    {
                        context.Entry(dbentity).CurrentValues.SetValues(entity);
                    }
                    else
                    {
                        context.Entry(entity).State = EntityState.Added;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Ошибка при обновлении состояния сущности", ex);
                }
            }
        }

        /// <summary>
        /// Возвращает значение первичного ключа сущьности
        /// </summary>
        /// <typeparam name="TEntity">Тип сущности</typeparam>
        /// <param name="context">Контекст БД, в котором нужно найти ключ сущности</param>
        /// <param name="entity">Сущность EF</param>
        /// <returns>Ключ сущности</returns>
        private static object GetKey<TEntity>(this DbContext context, ref TEntity entity) where TEntity : class
        {
            PropertyInfo keyProp = context.GetKeyProperty(ref entity);
            return keyProp.GetValue(entity);
        }

        /// <summary>
        /// Получает свойство, которое хранит первичный ключ
        /// </summary>
        /// <typeparam name="TEntity">Тип сущности</typeparam>
        /// <param name="entity">Сущность EF</param>
        /// <returns>PropertyInfo поля, в котором хранится первичный ключ</returns>
        private static PropertyInfo GetKeyProperty<TEntity>(this DbContext context, ref TEntity entity)
        {
            Type entityType = entity.GetType();
            IEntityType metaEntityType = context.Model.FindEntityType(entityType);
            string keyFieldName = metaEntityType.FindPrimaryKey().Properties.Select(x => x.Name).FirstOrDefault() ?? "id";
            return entityType.GetProperty(keyFieldName);
        }

        /// <summary>
        /// Проверяет, не состаит ли сущность в трекере изменений
        /// </summary>
        /// <typeparam name="TEntity">Тип сущности</typeparam>
        /// <param name="context">Контекст БД, в котором нужно проверить сущность на изменения</param>
        /// <param name="entity">Сущность EF</param>
        /// <returns>Флаг наличия сущности в трекере изменений контекста</returns>
        private static bool IsInChanges<TEntity>(this DbContext context, TEntity entity) where TEntity : class
        {
            PropertyInfo keyProp = GetKeyProperty(context, ref entity);
            IEnumerable<EntityEntry<TEntity>> changes = context.ChangeTracker.Entries<TEntity>();
            return changes.Any(e => keyProp.GetValue(entity) == keyProp.GetValue(e.Entity));
        }
    }
}
