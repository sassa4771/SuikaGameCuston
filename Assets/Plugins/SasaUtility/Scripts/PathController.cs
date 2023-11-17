using System;
using System.IO;
using UnityEngine;
using System.Collections.Generic;

namespace SasaUtility
{
    /// <summary>
    /// �t�H���_�[��t�@�C�����쐬���A�p�X���Ǘ����邽�߂̃N���X
    /// </summary>
    public static class PathController
    {
        ///  /// <summary>
        /// �ۑ����Application.persistentDataPath���擾���郁�\�b�h
        /// �t�H���_�����݂��Ȃ��ꍇ�͍쐬����
        /// </summary>
        /// <param name="folderName">��؂�̃t�H���_��</param>
        /// <param name="ExtensionName">�g���q��</param>
        /// <returns>�ۑ���̃p�X</returns>
        public static string GetSavePath(string folderName, string ExtensionName, bool persistent = true)
        {
            string directoryPath = Application.persistentDataPath + "/" + folderName + "/";
            
            //���S�ȃp�X�̏ꍇ
            if (!persistent) directoryPath = folderName + "/";

                if (!Directory.Exists(directoryPath))
            {
                //�܂����݂��ĂȂ�������쐬
                Directory.CreateDirectory(directoryPath);
                return directoryPath + GetDateTimeFileName() + "." + ExtensionName;
            }
            string SavedPath = directoryPath + GetDateTimeFileName() + "." + ExtensionName;

            return SavedPath;
        }

        /// <summary>
        /// ���t��t�������j�[�N�ȃt�@�C�����̍쐬�i�~���Z�J���h�܂ŕ\���j
        /// ��F2023.05.28_14.08.01.614
        /// </summary>
        /// <returns>DateTime�̕�����</returns>
        public static string GetDateTimeFileName()
        {
            DateTime TodayNow = DateTime.Now;
            string filename = TodayNow.Year.ToString() + "." + TodayNow.Month.ToString("D2") + "." + TodayNow.Day.ToString("D2") + "_" + TodayNow.Hour.ToString("D2") + "." + TodayNow.Minute.ToString("D2") + "." + TodayNow.Second.ToString("D2") + "." + TodayNow.Millisecond.ToString("D2");
            return filename;
        }

        /// <summary>
        /// sourceFolderPath����destinationFolderPath�Ƀt�H���_�[���ƃR�s�[���郁�\�b�h
        /// </summary>
        /// <param name="sourceFolderPath"></param>
        /// <param name="destinationFolderPath"></param>
        /// <returns>�������̓R�s�[��̃p�X��ԋp</returns>
        public static string CopyDirectory(string sourceFolderPath, string destinationFolderPath)
        {
            string newFolderPath = CreateDirectory(sourceFolderPath, destinationFolderPath);

            string[] files = Directory.GetFiles(sourceFolderPath);
            Debug.Log(files[0]);

            foreach (string file in files)
            {
                Debug.Log(file);
                string fileName = Path.GetFileName(file);
                string newFilePath = Path.Combine(newFolderPath, fileName);
                File.Copy(file, newFilePath, true);
            }

            return newFolderPath;
        }

        public static string CopyOneFile(string sourceFolderPath, string destinationFolderPath, string type)
        {
            string[] files = Directory.GetFiles(sourceFolderPath);
            Debug.Log(files[0]);

            foreach (string file in files)
            {
                string extension = System.IO.Path.GetExtension(file);
                if (extension == type)
                {
                    Debug.Log(file);
                    string fileName = Path.GetFileName(file);
                    string newFilePath = Path.Combine(destinationFolderPath, fileName);
                    File.Copy(file, newFilePath, true);

                    return newFilePath;
                }
            }

            return null;
        }

        /// <summary>
        /// �I�������g���q�Ɠ����t�@�C������擾���郁�\�b�h
        /// ��ԐV�����t�@�C����ԋp
        /// </summary>
        /// <param name="sourceFolderPath">�t�H���_�p�X</param>
        /// <param name="type">�g���q</param>
        /// <returns></returns>
        public static string GetOneFilePath(string sourceFolderPath, string extension)
        {
            string[] files = Directory.GetFiles(sourceFolderPath);
            List<string> videoFilePath = new List<string>();

            foreach (string file in files)
            {
                string type = System.IO.Path.GetExtension(file);
                if (type == extension)
                {
                    Debug.Log(file);
                    string fileName = Path.GetFileName(file);
                    string newFilePath = Path.Combine(sourceFolderPath, fileName);
                    videoFilePath.Add(newFilePath);
                }
            }

            if (videoFilePath.Count > 0) return videoFilePath[videoFilePath.Count - 1];

            return null;
        }

        /// <summary>
        /// �t�H���_��V�����쐬���郁�\�b�h
        /// </summary>
        /// <param name="sourceFolderPath"></param>
        /// <param name="destinationFolderPath"></param>
        /// <returns></returns>
        public static string CreateDirectory(string sourceFolderPath, string destinationFolderPath)
        {
            if (!Directory.Exists(sourceFolderPath))
            {
                Debug.LogError("Source folder does not exist!");
                return null;
            }

            //Debug.Log(sourceFolderPath);
            string newFolderPath = destinationFolderPath + "/" + Path.GetFileName(sourceFolderPath);

            int count = 1;
            string tempPath = newFolderPath;

            // �t�H���_������ꍇ�́A���O��ύX����
            while (Directory.Exists(newFolderPath))
            {
                newFolderPath = tempPath + " (" + count + ")";
                count++;
            }

            Directory.CreateDirectory(newFolderPath);
            return newFolderPath;
        }
    }
}