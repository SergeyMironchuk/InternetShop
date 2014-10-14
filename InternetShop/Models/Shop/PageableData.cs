using System;
using System.Collections.Generic;
using System.Linq;

namespace InternetShop.Models.Shop
{
    public class PageableData<T> where T : class
    {
        protected int ItemPerPageDefault = 5;

        /// <summary>
        /// Список выводимых объектов
        /// </summary>
        public IEnumerable<T> List { get; set; }

        /// <summary>
        /// Текущий номер страницы
        /// </summary>
        public int PageNo { get; set; }

        /// <summary>
        /// Кол-во страниц
        /// </summary>
        public int CountPage { get; set; }

        /// <summary>
        /// Кол-во объектов на странице
        /// </summary>
        public int ItemPerPage { get; set; } 

        public PageableData(IQueryable<T> queryableSet, Func<T, object> sortKey , int page, int itemPerPage = 0)
        {
            if (itemPerPage == 0)
            {
                itemPerPage = ItemPerPageDefault;
            }
            ItemPerPage = itemPerPage;

            PageNo = page;
            var count = queryableSet.Count(); // считает количество объектов в последовательности

            CountPage = (int)decimal.Remainder(count, itemPerPage) == 0 ? count / itemPerPage : count / itemPerPage + 1;
            List = queryableSet.OrderBy(sortKey).Skip((PageNo - 1) * itemPerPage).Take(itemPerPage);
        }
    }
}
