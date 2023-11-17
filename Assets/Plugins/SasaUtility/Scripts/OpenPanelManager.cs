using UnityEngine;
using UnityEngine.UI;
using System.IO;

namespace SasaUtility
{
    public static class OpenPanelManager
    {
        public static Text selectedFolderPathText;

        /// <summary>
        /// �t�H���_�I���p�l����\�����āA�p�X���擾���郁�\�b�h
        /// </summary>
        /// <returns></returns>
        public static string OpenFolderSelectionPanel()
        {
            string selectedFolderPath = OpenFolderPanel();

            if (!string.IsNullOrEmpty(selectedFolderPath))
            {
                return selectedFolderPath;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string OpenFolderPanel()
        {
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures);
            System.Diagnostics.Process.Start(path);

            return path;
        }
    }
}