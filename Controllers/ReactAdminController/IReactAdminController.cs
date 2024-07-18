using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace SidimEsus.Controllers.ReactAdminController
{
    public interface IReactAdminController<T>
    {
        /// <summary>
        /// Obtenha uma lista de modelos de destino.
        /// </summary>
        /// <param name="q">Condições de pesquisa, JSONオブジェクト形式 例) {"Name":"Taro"}</param>
        /// <param name="range">取得範囲条件 (ページング), JSON配列形式 例) [0,9]</param>
        /// <param name="sort">ソート条件, JSON配列形式 例) ["id","ASC"]</param>
        /// <returns>モデルのリスト</returns>
        /// <remarks>
        /// <para>Get list に相当します。</para>
        /// </remarks>
        Task<ActionResult<IEnumerable<T>>> Get(
            string q = "",
            string dateType = "",
            DateTime? startDate = null,
            DateTime? endDate = null,
            int _start = 0,
            int _end = 0,
            string _sort = "",
            string _order = "",
            [FromQuery] int[] id = null,
            bool noFilter = false
            );

        /// <summary>
        /// 対象となるモデルの単一要素を取得します。
        /// </summary>
        /// <param name="id">Id値</param>
        /// <returns>モデル</returns>
        /// <remarks>
        /// <para>Get one record に相当します。</para>
        /// </remarks>
        Task<ActionResult<T>> Get(int id);

        /// <summary>
        /// 対象となるモデルを更新します。
        /// </summary>
        /// <param name="id">Id値</param>
        /// <param name="entity">モデル</param>
        /// <returns>モデル</returns>
        /// <remarks>
        /// <para>Update a record に相当します。</para>
        /// </remarks>
        Task<ActionResult<T>> Put(int id, T entity);

        /// <summary>
        /// 対象となるモデルを登録します。
        /// </summary>
        /// <param name="entity">モデル</param>
        /// <returns>モデル</returns>
        /// <remarks>
        /// <para>Create a record に相当します。</para>
        /// </remarks>
        Task<ActionResult<T>> Post(T entity);

        /// <summary>
        /// 対象となるモデルを削除します。
        /// </summary>
        /// <param name="id">Id値</param>
        /// <returns>モデル</returns>
        /// <remarks>
        /// <para>Delete a record に相当します。</para>
        /// </remarks>
        Task<ActionResult<T>> Delete(int id);
    }
}

