using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SidimEsus.Repos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Linq.Dynamic.Core;
using SidimEsus.Utils;

namespace SidimEsus.Controllers.ReactAdminController
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ReactAdminController<T> : ControllerBase, IReactAdminController<T> where T : class, new()
    {
        protected readonly AppDatabase _context;
        protected DbSet<T> _table;
        protected string tela;
        protected IQueryable<T> entityQuery;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="context"><see cref="AppDatabase"/></param>      
        protected ReactAdminController(AppDatabase context)
        {
            _context = context;

        }

        /// <inheritdoc />
        [HttpDelete("{id:int}")]
        public virtual async Task<ActionResult<T>> Delete(int id)
        {

            var entity = await _table.IgnoreQueryFilters().Where("id = @0", id).FirstOrDefaultAsync();

            if (entity == null)
            {
                return NotFound();
            }

            _table.Remove(entity);
            await _context.SaveChangesAsync();

            return Ok(entity);
        }

        /// <inheritdoc />
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<T>>> Get(
            string q = "",
            string dateType = "",
            DateTime? startDate = null,
            DateTime? endDate = null,
            int _start = 0,
            int _end = 0,
            string _order = "",
            string _sort = "",
            [FromQuery] int[] id = null,
            bool noFilter = false

            )
        {

            if (startDate > endDate)
            {
                var errors = new
                {
                    Message = "Strings.DataFinalMaior",
                    Errors = new
                    {
                        EndDate = "Strings.DataFinalMaior",
                    }
                };

                return BadRequest(errors);
            }

            var dynamicParams = HttpContext.Request.Query
                                .Where(q => q.Key != null && q.Value.Count > 0)
                                .Where(q => !IsStaticParameter(q.Key)) // Filter out static parameters
                                .ToDictionary(q => q.Key, q => (object)q.Value.First());

            //check if no filters
            entityQuery = entityQuery == null ? noFilter ? _table.IgnoreQueryFilters().AsQueryable() : _table.AsQueryable() : entityQuery;

            if (id != null && id.Length > 0)
            {
                entityQuery = entityQuery.Where("Id in @0", id);
            }

            if (!string.IsNullOrEmpty(q))
            {
                var props = typeof(T).GetProperties();
                string query = "1 != 1 ";
                foreach (var prop in props)
                {
                    PropOptions[] customAttributes = (PropOptions[])prop.GetCustomAttributes(typeof(PropOptions), true);
                    if (customAttributes.Length > 0)
                    {
                        PropOptions myAttribute = customAttributes[0];
                        if (myAttribute.Filtravel)
                        {
                            if (prop.PropertyType == typeof(string) && !string.IsNullOrEmpty(q))
                            {
                                query += $" or {prop.Name}.Replace(\".\",\"\").Replace(\"-\",\"\").Contains(@0.Replace(\".\",\"\").Replace(\"-\",\"\"))";
                            }
                            else if (!string.IsNullOrEmpty(q) && (prop.PropertyType == typeof(int) || prop.PropertyType == typeof(int?)))
                            {
                                var isNumeric = int.TryParse(q, out _);
                                if (isNumeric)
                                    query += $" or {prop.Name} == @0";
                            }
                            else if (!string.IsNullOrEmpty(q) && (prop.PropertyType == typeof(double) || prop.PropertyType == typeof(double?)))
                            {
                                q = q.Replace(",", ".");
                                query += $" or {prop.Name}.ToString().Contains(@0)";
                            }
                        }
                    }
                }
                entityQuery = entityQuery.Where(query, q, startDate, endDate);
            }

            if (startDate.HasValue || endDate.HasValue)
            {
                var props = typeof(T).GetProperties();
                string query = "1 = 1 ";
                foreach (var prop in props)
                {
                    PropOptions[] customAttributes = (PropOptions[])prop.GetCustomAttributes(typeof(PropOptions), true);
                    if (customAttributes.Length > 0)
                    {
                        PropOptions myAttribute = customAttributes[0];
                        if (myAttribute.Filtravel)
                        {
                            if ((startDate.HasValue && endDate.HasValue) && (prop.PropertyType == typeof(DateTime?) || prop.PropertyType == typeof(DateTime)))
                            {
                                if (string.IsNullOrEmpty(dateType) || dateType.ToUpper() == prop.Name.ToUpper())
                                    query += $" and ({prop.Name} >= @1 AND {prop.Name} <= @2) ";
                            }
                            else if ((startDate.HasValue) && (prop.PropertyType == typeof(DateTime?) || prop.PropertyType == typeof(DateTime)))
                            {
                                if (string.IsNullOrEmpty(dateType) || dateType.ToUpper() == prop.Name.ToUpper())
                                    query += $" and ({prop.Name} >= @1) ";
                            }
                            else if ((endDate.HasValue) && (prop.PropertyType == typeof(DateTime?) || prop.PropertyType == typeof(DateTime)))
                            {
                                if (string.IsNullOrEmpty(dateType) || dateType.ToUpper() == prop.Name.ToUpper())
                                    query += $" and ({prop.Name} <= @2) ";
                            }
                        }
                    }
                }
                if (endDate != null)
                    endDate = endDate.Value.AddHours(23).AddMinutes(59).AddSeconds(59);
                entityQuery = entityQuery.Where(query, q, startDate, endDate);
            }

            foreach (var kvp in dynamicParams)
            {
                if (kvp.Value.ToString().Contains("<") || kvp.Value.ToString().Contains(">"))
                {
                    var operador = kvp.Value.ToString().Contains("<") ? "<" : ">";
                    var valor = kvp.Value.ToString().Split(new char[] { '<', '>' })[1];

                    entityQuery = entityQuery.Where($"{kvp.Key} {operador} {decimal.Parse(valor)}");
                }
                else if (kvp.Value.ToString().ToUpper() == "NULL")
                {
                    entityQuery = entityQuery.Where($"{kvp.Key} == null");
                }
                else if (kvp.Value.ToString().ToUpper() == "NOT NULL")
                {
                    entityQuery = entityQuery.Where($"{kvp.Key} != null");
                }
                else
                {
                    var query = $"{kvp.Key} == @0";
                    entityQuery = entityQuery.Where(query, kvp.Value);

                }
            };

            var count = entityQuery.Count();

            if (!string.IsNullOrEmpty(_sort))
            {
                entityQuery = entityQuery.OrderBy($"{_sort} {_order}");
            }

            if (_end > 0)
            {
                entityQuery = entityQuery.Skip(_start).Take(_end - _start);
            }

            Response.Headers.Add("X-Total-Count", count.ToString());

            var t = entityQuery.ToQueryString();

            var data = await entityQuery.ToListAsync();

            data = CustomData(data);
            return data;
        }

        public virtual List<T> CustomData(List<T> data)
        {
            return data;
        }

        /// <inheritdoc />
        [HttpGet("{id:int}")]
        public virtual async Task<ActionResult<T>> Get(int id)
        {
            var entity = await _table.IgnoreQueryFilters().Where("id = @0", id).FirstOrDefaultAsync();

            if (entity == null)
            {
                return NotFound();
            }

            entity = CustomData(entity);

            return entity;
        }

        public virtual T CustomData(T data)
        {
            return data;
        }

        /// <inheritdoc />
        [HttpPost]
        public virtual async Task<ActionResult<T>> Post(T entity)
        {
            var entry = _table.Add(entity);
            await _context.SaveChangesAsync();

            var id = (int?)typeof(T).GetProperty("Id")?.GetValue(entry.Entity);

            return Ok(entity);
        }

        /// <inheritdoc />
        [HttpPut("{id:int}")]
        public virtual async Task<ActionResult<T>> Put(int id, T entity)
        {
            var entityId = (int?)typeof(T).GetProperty("Id")?.GetValue(entity);
            if (!entityId.HasValue || id != entityId)
            {
                return BadRequest();
            }

            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await _table.FindAsync(entityId));
        }

        /// <summary>
        /// 対象モデルの存在をチェックします。
        /// </summary>
        /// <param name="id">Id値</param>
        /// <returns>存在する場合: true</returns>
        private bool EntityExists(int id)
        {
            return _table.Any(e => (int)typeof(T).GetProperty("Id").GetValue(e) == id);
        }

        public virtual bool IsStaticParameter(string paramName)
        {
            // Define the names of static parameters
            var staticParameterNames = new List<string>
            {
                "id","q", "dateType", "startDate", "endDate", "_start", "_end", "_sort", "_order","noFilter"
            };

            // Check if paramName is a static parameter
            return staticParameterNames.Contains(paramName, StringComparer.OrdinalIgnoreCase);
        }
    }
}