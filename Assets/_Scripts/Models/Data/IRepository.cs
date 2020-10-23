namespace Models.Data
{
    interface IRepository<TData>
    {
        TData GetData();
        void SetData(TData data);
    }
}
