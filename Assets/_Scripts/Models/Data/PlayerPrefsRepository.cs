using System;

namespace Models.Data
{
    class PlayerPrefsRepository : IRepository<int>, IRepository<float>, IRepository<string>
    {
        #region Private Fields
        private string m_Key;
        #endregion

        public PlayerPrefsRepository(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            m_Key = key;
        }

        #region IRepository<int> implementation Methods
        int IRepository<int>.GetData()
        {
            return UnityEngine.PlayerPrefs.GetInt(m_Key);
        }

        void IRepository<int>.SetData(int data)
        {
            UnityEngine.PlayerPrefs.SetInt(m_Key, data);
            Save();
        }
        #endregion

        #region IRepository<float> implementation Methods
        float IRepository<float>.GetData()
        {
            return UnityEngine.PlayerPrefs.GetFloat(m_Key);
        }

        void IRepository<float>.SetData(float data)
        {
            UnityEngine.PlayerPrefs.SetFloat(m_Key, data);
            Save();
        }
        #endregion

        #region IRepository<string> implementation Methods
        string IRepository<string>.GetData()
        {
            return UnityEngine.PlayerPrefs.GetString(m_Key);
        }

        void IRepository<string>.SetData(string data)
        {
            UnityEngine.PlayerPrefs.SetString(m_Key, data);
            Save();
        }
        #endregion

        #region Private Methods
        private void Save()
        {
            UnityEngine.PlayerPrefs.Save();
        }
        #endregion
    }
}
