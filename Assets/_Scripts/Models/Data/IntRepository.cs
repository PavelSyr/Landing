using System;

namespace Models.Data
{
    class IntRepository : IRepository<int>
    {
        #region Private Fields
        private IRepository<int> m_Repository;
        #endregion

        [Construct]
        public IntRepository (IRepository<int> repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            m_Repository = repository;
        }

        #region Public Methods
        public int GetData()
        {
            return m_Repository.GetData();
        }

        public void SetData(int data)
        {
            m_Repository.SetData(data);
        }
        #endregion

        #region Private Methods
        #endregion
    }
}
