using System.Collections;
using System.Collections.Generic;

namespace PagedList.Page.PageFactory
{
    /// <summary>
    /// 泛型抽象类，最好实现迭代器
    /// </summary>
    /// <typeparam name="T">协变：是的基类能够 最大程度上输出当前类，这个是这个分页方法的核心所在</typeparam>
    public interface IPagedList<out T>:IPagedList,IEnumerable<T>, IEnumerable
    {
        /// <summary>
        /// 返回索引实体  
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        T this[int index] { get; }
        /// <summary>
        /// 集合数量
        /// </summary>
        int Count { get; }
        /// <summary>
        /// 获取核心数据
        /// </summary>
        /// <returns></returns>
        PagedListMetaData GetMetaData();
    }
}
